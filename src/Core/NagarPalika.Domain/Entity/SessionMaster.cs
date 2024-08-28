using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("SessionMaster")]
    public class SessionMaster : BaseEntity
    {
        [Key] public int SessionMasterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionName { get; set; }
    }
}
