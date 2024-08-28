using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("AssetSubCategory")]
    public class AssetSubCategory : BaseEntity
    {
        [Key]public int AssetSubCategoryId {get; set;}
public string AssetSubCategoryName {get; set;}
public int AssetCategoryId {get; set;}
}
}
