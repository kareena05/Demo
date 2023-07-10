using AutoMapper;
using Saakh.Data;
using Saakh.Models;
using Saakh.Repository;

namespace Saakh.Services
{    
    public class ExcelValidationService: IExcelValidationService
    {
        #region Fields
        
        private readonly IRepository<ImportMapping> _importMappingRepository;
        private readonly IRepository<Company> _companyRepository;      
        private readonly IFileService _fileService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor
        public ExcelValidationService(IRepository<ImportMapping> importMappingRepository,
                            IRepository<Company> companyRepository,
                            IFileService fileService,
                            ICommonService commonService,
                            IMapper mapper)
        {
            _importMappingRepository = importMappingRepository;
            _companyRepository = companyRepository;
            _fileService = fileService;
            _commonService = commonService;
            _mapper = mapper;
        }
        #endregion
        public async Task<ErrorValidateResponseModel> ValidateExcel(ImportModel model, ulong businessId)
        {
            var errorDatas = new List<ErrorValidateExcelModel>();
            var c_data = new List<CorrectDataModel>();
            var createData = new List<CreateDataModel>();
            var errorResponseModel = new ErrorValidateResponseModel() { ExcelImportType = model.ImportSpecificationModel.ImportType, ErrorModel = errorDatas, CorrectData = c_data, CreateData = createData, Mappings = model.Mapping };

            if (model.Excel == null)
            {
                errorDatas.Add(new ErrorValidateExcelModel() { Data = new List<EditErrorExcelDataModel>(), Error = ErrorMessages.Error + ErrorMessages.NoFile });
                return errorResponseModel;
            }
            if (!(Path.GetExtension(model.Excel.FileName) == ".xlsx" || Path.GetExtension(model.Excel.FileName) == ".csv"))
            {
                errorDatas.Add(new ErrorValidateExcelModel() { Data = new List<EditErrorExcelDataModel>(), Error = ErrorMessages.Error + ErrorMessages.WrongFile });
                return errorResponseModel;
            }
            //error for no row selected.
            if (model.StartRow == 0)
            {
                errorDatas.Add(new ErrorValidateExcelModel() { Data = new List<EditErrorExcelDataModel>(), Error = ErrorMessages.Error + ErrorMessages.NoRow });
                return errorResponseModel;
            }
            var company = await _companyRepository.GetEntityByConditionAsync(x => x.Id == businessId);
            if (company == null)
                return null;

            FileData fileData = new FileData();
            await _commonService.GetFileType(model, fileData);

            //show error for having no data.
            if (model.StartRow == fileData.RowCount)
            {
                errorDatas.Add(new ErrorValidateExcelModel() { Data = new List<EditErrorExcelDataModel>(), Error = ErrorMessages.Error + ErrorMessages.NoData });
                return errorResponseModel;
            }




            if (model.MappingId != 0)
                model.Mapping = _mapper.Map<List<MappingModel>>
                    (await _importMappingRepository.GetAllEntitiesAsync(x => x.BusinessMappingId.Equals(model.MappingId)));

            var isSupplier = ExcelImportType.Supplier == model.ImportSpecificationModel.ImportType;
            var IsSalesInvoice = ExcelImportType.SalesInvoice == model.ImportSpecificationModel.ImportType;
            var IsPayment = ExcelImportType.Payment == model.ImportSpecificationModel.ImportType;

            var companys = new List<Company>();
            var companyDetails = new List<CompanyDetail>();
            var customers = new List<Customer>();
            var invoices = new List<Invoice>();
            var payments = new List<Payment>();

            switch (model.ImportSpecificationModel.ImportType)
            {
                case ExcelImportType.Customer or ExcelImportType.Supplier:

                    await ValidateCustomerImportModel(model, businessId, companys, companyDetails, customers, errorDatas, c_data, isSupplier, fileData);

                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, companys, 0, true));
                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, customers, 0, true));
                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, companyDetails, 0, true));
                    break;
                case ExcelImportType.SalesInvoice or ExcelImportType.PurchaseInvoice:

                    await ValidateSalesInvoice(model, businessId, companys, companyDetails, customers, invoices, errorDatas, c_data, createData, IsSalesInvoice, fileData);
                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, companys, 0, true));
                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, customers, 0, true));
                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, companyDetails, 0, true));
                    //errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, compHistory, 0));
                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, invoices, 0, true));
                    //errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, payment, 0));
                    break;

                case ExcelImportType.Payment or ExcelImportType.Receipt:

                    await ValidatePayment(model, businessId, companys, companyDetails, invoices, payments, errorDatas, c_data, createData, IsPayment, fileData);
                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, companys, 0, true));
                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, companyDetails, 0, true));
                    errorResponseModel.FilePaths.Add(await _fileService.TranferDataAsync(businessId, model.ImportSpecificationModel.ImportType, payments, 0, true));

                    break;
                case ExcelImportType.JournalContra:
                    break;
                default:
                    break;
            }



            ///FILE NAMING CONVENTION
            ///STRUCTORE : FOLDER -> BUSINESSID-FOLDER -> IMPORTTYPE FOLDER -> JSONFILE
            ///NAMING CONVENTION OF FILE -> {0}_{TIME}.JSON
            ///IF 0 -> NOT SAVED  : ELSEIF 1 -> SAVED : ELSEIF 2 -> INCOMPLETE


            errorResponseModel.Mappings = model.Mapping;
            return errorResponseModel;

        }

        private async Task ValidateCustomerImportModel(ImportModel model, ulong businessId, List<Company> companys, List<CompanyDetail> companyDetails, List<Customer> customers, List<ErrorValidateExcelModel> errorDatas, List<CorrectDataModel> AllCorrectData, bool IsSupplier, FileData fileData)
        {

            var errorRow = 0;
            var errorMessage = "";

            for (int row = 1; row < fileData.RowCount; row++)
            {
               
                errorRow = 0;
                var company = new Company();
                var companyDetail = new CompanyDetail();
                //var user = new User();
                var customer = new Customer();
                var errorData = new List<EditErrorExcelDataModel>();
             
                

                var temp = fileData.Rows[row];
                //checking if the entire row is null
                if (temp.Count(x => x == null) == temp.Count()) { continue; }
               
                

                for (int col = 1; col <= fileData.ColumnCount; col++)
                {
                  
                    var value = fileData.Rows[row][col-1];
                    //triming the string values

                    if (value != null)
                    {
                        if (value.GetType() == typeof(string))
                        {
                            value = value.ToString().Trim();
                        }
                    }
                    var map = model.Mapping.Where(x => x.ExcelAddrress == col).FirstOrDefault();

                    if (map != null && col == map.ExcelAddrress)
                    {
                       _commonService.CustomerValidation(ref errorRow, ref errorMessage, row, company, companyDetail, customer, errorData, value, map);                        
                    }
                }
                await _commonService.CustomerDataEntity(businessId, companys, companyDetails, customers, errorDatas, AllCorrectData, IsSupplier, errorRow, errorMessage, company, companyDetail, customer, errorData);               
            }
            if (errorDatas.Count == 0 && AllCorrectData.Count == 0)
            {
                errorDatas.Add(new ErrorValidateExcelModel() { Data = new List<EditErrorExcelDataModel>(), Error = ErrorMessages.Error + ErrorMessages.NullDataError });
                return;
            }

        }
        private async Task ValidateSalesInvoice(ImportModel model, ulong businessId, List<Company> companys, List<CompanyDetail> companyDetails,
            List<Customer> customers, List<Invoice> invoices, List<ErrorValidateExcelModel> errorDatas, List<CorrectDataModel> AllCorrectData,
            List<CreateDataModel> CreateData, bool IsSalesInvoice, FileData fileData)
        {

            var errorRow = 0;
            var errorMessage = "";


            for (int row = 1; row < fileData.RowCount; row++)
            {
                errorRow = 0;
                var company = new Company();
                var companyDetail = new CompanyDetail();
                var customer = new Customer();
                var invoice = new Invoice();


                var errorData = new List<EditErrorExcelDataModel>();
                var insertData = new List<DataToBeInserted>();
            

                var temp = fileData.Rows[row];
                if (temp.Count(x => x == null) == temp.Count()) { continue; }
                for (int col = 1; col <= fileData.ColumnCount; col++)
                {
                    var value = fileData.Rows[row][col - 1];
                    var map = model.Mapping.Where(x => x.ExcelAddrress == col).FirstOrDefault();
                    if (value.GetType() == typeof(string))
                    {
                        value = value.ToString().Trim();
                    }
                    if (map != null && col == map.ExcelAddrress)
                    {
                        _commonService.InvoiceValidation(ref errorRow, ref errorMessage, 0, company, companyDetail, customer, invoice, errorData, value, map);
                        _commonService.InsertData(model.ImportSpecificationModel.ImportType, insertData, value, map);                       
                    }
                }
                await _commonService.InvoiceDataEntity(businessId, companys, companyDetails, customers, invoices, errorDatas, AllCorrectData, CreateData, IsSalesInvoice, errorRow, errorMessage, company, companyDetail, customer, invoice, errorData, insertData);
            }
            if (errorDatas.Count == 0 && AllCorrectData.Count == 0 && CreateData.Count == 0)
            {
                errorDatas.Add(new ErrorValidateExcelModel() { Data = new List<EditErrorExcelDataModel>(), Error = ErrorMessages.Error + ErrorMessages.NullDataError });
                return;
            }

        }
        private async Task ValidatePayment(ImportModel model, ulong businessId, List<Company> companys, List<CompanyDetail> companyDetails, List<Invoice> invoices, List<Payment> payments, List<ErrorValidateExcelModel> errorDatas, List<CorrectDataModel> AllCorrectData, List<CreateDataModel> CreateData, bool IsPayment, FileData fileData)
        {
            var errorRow = 0;
            var errorMessage = "";

            for (int row = 1; row < fileData.RowCount; row++)
            {
                errorRow = 0;
                var company = new Company();
                var companyDetail = new CompanyDetail();
                var payment = new Payment();
                var invoice = new Invoice();

                var errorData = new List<EditErrorExcelDataModel>();
                var insertData = new List<DataToBeInserted>();

             

                var temp = fileData.Rows[row];

                var te = temp.Where(x => x != null && x.GetType() == typeof(string)).Select(x => x.ToString().Trim()).Where(x => string.IsNullOrEmpty(x)).Count();
                var te2 = temp.Count(x => x == null);
                if (te + te2 == temp.Count()) { continue; }

                for (int col = 1; col <= fileData.ColumnCount; col++)
                {

                    var value = temp[col - 1];
                    var map = model.Mapping.Where(x => x.ExcelAddrress == col).FirstOrDefault();
                    if (value is not null)
                    {
                        if (value.GetType() == typeof(string))
                        {
                            value = value.ToString().Trim();
                        }
                    }
                    if (map != null && col == map.ExcelAddrress)
                    {
                        _commonService.PaymentValidation(ref errorRow, ref errorMessage, 0, company, companyDetail, invoice, payment, errorData, value, map);

                    }
                }

                await _commonService.PaymentDataEntity(businessId, companys, companyDetails, payments, errorDatas, AllCorrectData, IsPayment, errorRow, errorMessage, company, companyDetail, payment, invoice, errorData);
                
            }

            if (errorDatas.Count == 0 && AllCorrectData.Count == 0 && CreateData.Count == 0)
            {
                errorDatas.Add(new ErrorValidateExcelModel() { Data = new List<EditErrorExcelDataModel>(), Error = ErrorMessages.Error + ErrorMessages.NullDataError });
                return;
            }


        }

    }
}
