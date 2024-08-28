using Dapper.Contrib.Extensions;
using System;
using NagarPalika.Domain;
namespace NagarPalika.Domain.Entity
{
    [Table("Employee")]
    public class Employee : BaseEntity
    {
        [Key]
        public int EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string MobileNo { get; set; }
        public string AlternateMobileNo { get; set; }
        public string EmailId { get; set; }
        public string FullAddress { get; set; }
        public int OrganizationId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public string Level { get; set; }
        public int ReportingEmployeeId { get; set; }
        public int RoleId { get; set; }
        public int UserTypeId { get; set; }
        public string ProfilePicURL { get; set; }

    }
}
