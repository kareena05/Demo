using System.Globalization;

namespace MeraKhata.Models
{
    public class ResponseModel
    {
        public bool Status { get; set; }

        public object Data { get; set; }

        public string  Message { get; set; }

        public ResponseModel()
        {
            Data = new object();
            Message = string.Empty;
        }
    }
}
