using Microsoft.AspNetCore.Http;
using NagarPalika.Application.OtherRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Data.OtherRepository
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public EmployeeProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public int EmployeeId
        {
            get
            {
               string userid =this.httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == "EmployeeId").Value;
                return Convert.ToInt32(userid);
            }          
        }
    }
}
