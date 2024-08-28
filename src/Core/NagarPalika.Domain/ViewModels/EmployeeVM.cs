using System.Text.Json.Serialization;

namespace NagarPalika.Domain.ViewModels
{
    public class EmployeeVM
    {
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
        public string DepartmentName { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string Level { get; set; }
        public int ReportingEmployeeId { get; set; }
        public int RoleId { get; set; }
        public int UserTypeId { get; set; }
        public string ProfilePicURL { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }

    }
}
