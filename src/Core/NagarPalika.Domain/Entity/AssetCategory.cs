using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("AssetCategory")]
    public class AssetCategory : BaseEntity
    {
        [Key]public int AssetCategoryId {get; set;}
public string AssetCategoryName {get; set;}
}
}
