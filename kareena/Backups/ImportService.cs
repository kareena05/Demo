using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using OfficeOpenXml.FormulaParsing.Utilities;
using Saakh.Data;
using Saakh.Models;
using Saakh.Models.Zoop;
using Saakh.Repository;
using System.Data;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;


namespace Saakh.Services;

public class ImportService : IImportService
{
    #region Fields
    private readonly IRepository<BusinessImportMapping> _businessMappingRepository;
    private readonly IRepository<ImportMapping> _importMappingRepository;
    private readonly IRepository<Company> _companyRepository;
    private readonly IRepository<ImportCsv> _importCsvRepository;
    private readonly IRepository<ImportHistory> _importHistory;
    private readonly IExcelValidationService _excelVService;
    private readonly IErrorValidationService _errorVService;
    private readonly IMappingService _mappingService;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    #endregion

    #region Ctor
    public ImportService(IRepository<BusinessImportMapping> businessMappingRepository,
                        IRepository<ImportMapping> importMappingRepository,
                        IRepository<Company> companyRepository,
                        IRepository<ImportCsv> importCsvRepository,
                        IRepository<ImportHistory> importHistory,
                        IExcelValidationService excelVService,
                        IErrorValidationService errorVService,
                        IMappingService mappingService,
                        IFileService fileService,
                        IMapper mapper)
    {
        _businessMappingRepository = businessMappingRepository;
        _importMappingRepository = importMappingRepository;
        _companyRepository = companyRepository;
        _importCsvRepository = importCsvRepository;
        _importHistory = importHistory;
        _excelVService = excelVService;
        _errorVService = errorVService;
        _mappingService = mappingService;
        _fileService = fileService;
        _mapper = mapper;
    }
    #endregion

    #region Mapping
    public async Task<IList<ImportMappingModel>> GetMapping(ulong BusinessId, ExcelImportType Type)
    {        
        return (await _mappingService.GetMapping(BusinessId, Type));
    }
    public async Task<IList<MappingModel>> GetDynamicMapping(ImportModel model, ulong businessId)
    {
        return (await _mappingService.GetDynamicMapping(model, businessId));
    }    
    public async Task<List<MappingModel>> GetExcelImportTableNames(ExcelImportType type)
    {
        return (await _mappingService.GetExcelImportTableNames(type));
    }

    #endregion

    #region Validation

    public async Task<ErrorValidateResponseModel> ValidateModel(ImportModel model, ulong businessId)
    {
        return (await _excelVService.ValidateExcel(model, businessId));
    }     
    public async Task<ErrorValidateResponseModel> ErrorValidateModel(ErrorValidateResponseModel model, ulong businessId)
    {
        return (await _errorVService.ValidatError(model, businessId));
    }
    private static async Task<HttpResponseMessage> VerifyGstThroughZoop(Company company, HttpResponseMessage response)
    {
        using (var httpClient = new HttpClient())
        {

            var body = new ZoopRequestModel
            {
                data = new ZoopRequestDataModel
                {
                    business_gstin_number = company.GstNumber,
                    consent = "Y",
                    consent_text = "I hear by declare my consent agreement for fetching my information via ZOOP API"
                }
            };

            httpClient.DefaultRequestHeaders.Add("auth", "false");
            httpClient.DefaultRequestHeaders.Add("api-key", "59JX5RQ-Y3J4K1K-KQFF7XH-T86Y9J5");
            httpClient.DefaultRequestHeaders.Add("app-id", "619b293202f92d001d6aa05b");

            var content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");

            response = await httpClient.PostAsync("https://live.zoop.one/api/v1/in/merchant/gstin/advance", content);


        }

        return response;
    }        
    private static void AddRangeToDictionary(Dictionary<string, object> error, Dictionary<string, object> excelData)
    {
        foreach (var item in excelData)
        {
            error.Add(item.Key, item.Value);
        }
    }

    #endregion

    #region Save 

    public async Task<string> SaveDynamicMapping(ImportMappingModel model)
    {
        if (model.ExcelMappings == null || model.ExcelMappings.Count == 0)
            return null;

        if(string.IsNullOrEmpty(model.Name))
        {
            model.Name = model.ImportType.ToString() + " - " + DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        }
        var business = await _companyRepository.GetEntityByConditionAsync(x => x.Id == model.BusinessId);
        if (business == null)
            return ErrorMessages.BusinessDoesntExist;

        var businessMappingData = new BusinessImportMapping();
        var businessMapping = await _businessMappingRepository.GetAllEntitiesAsync(x => x.Name.Equals(model.Name) && x.BusinessId == model.BusinessId);
        if (businessMapping.Count == 0)
        {
            businessMappingData = _mapper.Map<BusinessImportMapping>(model);
            await _businessMappingRepository.AddEntityAsync(businessMappingData);
        }
        else
            return ErrorMessages.MappingExist;


        var mappings = _mapper.Map<List<ImportMapping>>(model.ExcelMappings);
        foreach (var item in mappings)
        {
            item.BusinessMappingId = businessMappingData.Id;
        }
        await _importMappingRepository.AddEntityAsync(mappings);


        return null;
    }
    public async Task<bool> SaveDataMapping(SaveDataModel FilePaths, ulong businessId, ulong userId)
    {
        try
        {
            if (FilePaths.FileNames.Count > 0)
            {
                var importHistoryData = new ImportHistory();

                importHistoryData.ImportType = (int)FilePaths.ImportType;
                importHistoryData.Time = DateTime.Now;
                importHistoryData.UserId = userId;
                importHistoryData.BusiessId = businessId;

                await _importHistory.AddEntityAsync(importHistoryData);



                //var importH_Id = importHistoryData.Id;
                var data = FilePaths.FileNames.Distinct().
                    Select(x => new ImportCsv()
                    {
                        CompanyId = businessId,
                        UserId = userId,
                        File = x,
                        Uploaded = false,
                        CreatedAt = DateTime.Now,
                        ImportHistoryId = importHistoryData.Id

                    }).ToList();



                await _fileService.CreateFinalJsonFileAsync(importHistoryData.Id, data, businessId);
                await _importCsvRepository.AddEntityAsync(data);
                await SaveDynamicMapping(new ImportMappingModel()
                {
                    ExcelMappings = FilePaths.ExcelMappings,
                    BusinessId = businessId,
                    Name = FilePaths.MappingName,
                    ImportType = FilePaths.ImportType
                });
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    #endregion


    public async Task<IList<ImportHistoryModel>> GetImportHistory(ulong businessId,ulong userId)
    {
        List<ImportHistoryModel> historyModel = new List<ImportHistoryModel>();
        var result = await _importHistory.GetAllEntitiesAsync(x => x.BusiessId == businessId && x.UserId == userId);
        foreach (var entity in result.OrderByDescending(x => x.Id)) 
        {
            var importCsv = await _importCsvRepository.GetAllEntitiesAsync(x => x.ImportHistoryId == entity.Id);
            var importHistory = new ImportHistoryModel();
            importHistory.Id = entity.Id;
            importHistory.UserId = entity.UserId;
            importHistory.BusiessId = entity.BusiessId;
            importHistory.ImportType = entity.ImportType;
            importHistory.Time = entity.Time;
            importHistory.Uploaded = importCsv.Any(x => x.Uploaded == false) ? false : true;

            historyModel.Add(importHistory);
        }
        return historyModel;
    }

    private static void  AddData<TEntity>(Type j, CreateDataModel response,IList<TEntity> entity, MappingModel col,int i) {
        var properties = j.GetProperties().Where(x => x.Name.ToLower() == col.ColumnName.ToString()).ToList();
        foreach (var prop in properties)
        {
            if (prop != null)
            {
                var value = prop.GetValue(entity[i]);
                response.Data.Add(new DataToBeInserted() { ColumnName = col.ColumnName, Value = value });
            }
        }
    }

    public async Task<List<CreateDataModel>> GetImportCustomerData(int importHistoryId)
    {

        //get the import type from import history table
        var importHistoryEntity = await _importHistory.GetEntityByConditionAsync(x => x.Id == importHistoryId);
        var importType = importHistoryEntity.ImportType;

        var model = new List<MappingModel>();
        model = await _fileService.getFileData(model,(ExcelImportType)importType);

        var customers = await _fileService.GetFileJson<Customer>((ulong)importHistoryId, "Customer.json", true);
        var companies = await _fileService.GetFileJson<Company>((ulong)importHistoryId, "Company.json", true);
        var responseList = new List<CreateDataModel>();
      

        for (var i=0; i<customers.Count(); i++)
        {
            var response = new CreateDataModel();
            foreach (var col in model)
            {

                if (col.IsRequired == true)
                {
                    
                    if(col.TableName == "Customer")
                    {
                        var j = typeof(Customer);
                        AddData<Customer>(j, response, customers, col, i);
                        
                    }
                    if (col.TableName == "Company")
                    {
                       
                        var j = typeof(Company);
                        AddData<Company>(j, response, companies, col, i);
                    }


                }
                //when is required = false
                else
                {
                    if (col.TableName == "Customer")
                    {
                        var j = typeof(Customer);
                        var properties = j.GetProperties().Where(x => x.Name.ToLower() == col.ColumnName.ToString()).ToList();
                        foreach (var prop in properties)
                        {
                            if (prop != null)
                            {
                                var value = prop.GetValue(customers[i]);
                                if (value != null)
                                {
                                  
                                    response.Data.Add(new DataToBeInserted() { ColumnName = col.ColumnName, Value = value });
                                }
                                
                               
                            }
                           
                        }
                    }
                    if (col.TableName == "Company")
                    {
                       
                        var j = typeof(Company);
                        var properties = j.GetProperties().Where(x => x.Name.ToLower() == col.ColumnName.ToString()).ToList();
                        foreach (var prop in properties)
                        {
                            if (prop != null)
                            {
                                var value = prop.GetValue(companies[i]);
                                if (value != null)
                                {
                                    if (value.GetType().IsGenericType &&
     value.GetType().GetGenericTypeDefinition() == typeof(List<>))
                                    {
                                        //don't know the logic to check count of list if 0 or >0
                                        continue;
                                    }else if(value is string && value !="")
                                    {
                                        response.Data.Add(new DataToBeInserted() { ColumnName = col.ColumnName, Value = value });
                                    }else if (value.IsNumeric() && !value.Equals((object)0))
                                    {
                                        response.Data.Add(new DataToBeInserted() { ColumnName = col.ColumnName, Value = value });
                                    }
                                }
                               
                               
                               
                            }
                           
                        }
                    }

                }
            }
            responseList.Add(response);
        }
        if( responseList.Count() == 0 )
        {
            responseList[0].Error = "Error: Not able to get the data";
        }
        return responseList ;

    }
}



