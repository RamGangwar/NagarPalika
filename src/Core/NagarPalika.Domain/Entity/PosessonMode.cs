using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("PosessonMode")]
    public class PosessonMode : BaseEntity
    {
        [Key]public int PosessonModeId {get; set;}
public string PosessonModeName {get; set;}
}
}
