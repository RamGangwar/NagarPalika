using System.Text.Json.Serialization; 
 namespace NagarPalika.Domain.ViewModels 
{
 public class UserTypeVM 
{
public int UserTypeId {get; set;}
public string UserTypeName {get; set;}
public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
