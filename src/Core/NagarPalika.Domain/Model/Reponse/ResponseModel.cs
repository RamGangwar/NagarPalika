using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Model
{
    public class ResponseModel
    {        
        public string Message { get; set; }
        public int StatusCode { get; set; }       
        public bool Succeeded { get; set; }       
    }
    public class ResponseModel<entity> where entity : class
    {
        public entity Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Succeeded { get; set; }

    }

}
