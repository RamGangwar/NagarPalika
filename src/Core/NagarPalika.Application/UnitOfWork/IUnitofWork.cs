using NagarPalika.Application.Repository;

namespace NagarPalika.Application.UnitOfWork
{
    public interface IUnitofWork : IBaseUnitOfWork
    {
        IDepartmentRepository Departments { get; }
        IDesignationRepository Designations { get; }
        IEmployeeRepository Employee { get; }
        IModuleRepository Modules { get; }
        IRefreshTokensRepository RefreshToken { get; }
        IRolesRepository Roles { get; }
        IWardsRepository Wards { get; }
        IAccessPermissionRepository Permissions { get; }
        IDistrictsRepository Districts { get; }
        ILocalityRepository Locality { get; }
        IOrganizationsRepository Organizations { get; }
        IZonesRepository Zones { get; }
        IConstructionTypeRepository ConstructionType { get; }
        IDepriciationSlabRepository DepriciationSlab { get; }
        IDisabilitySlabRepository DisabilitySlab { get; }
        IDiscountSlabRepository DiscountSlab { get; }
        IFineCriteriaRepository FineCriteria { get; }
        IMonthlyRentalRateRepository MonthlyRentalRate { get; }
        IMutationTypeRepository MutationType { get; }
        IPropertyTypeRepository PropertyType { get; }
        IRecieptBooksRepository RecieptBooks { get; }
        IRoadWidthTypeRepository RoadWidthType { get; }
        ITariffPlanRepository TariffPlan { get; }
        ITenantSlabRepository TenantSlab { get; }
        IAssetCategoryRepository AssetCategorys { get; }
        IAssetSubCategoryRepository AssetSubCategorys { get; }
        IPosessonModeRepository PosessonModes { get; }
        IRNLAllotmentRepository RNLAllotments { get; }
        IRNLArrearRepository RNLArrears { get; }
        IRNLPropertyRepository RNLPropertys { get; }
        IPropertyRepository Property { get; }
        ISessionMasterRepository SessionMaster { get; }
        ITradeCategoryRepository TradeCategory { get; }
        ITradeDocumentRepository TradeDocuments { get; }
        ITradeRegistrationRepository TradeRegistration { get; }
        ITradeSubCategoryRepository TradeSubCategory { get; }
        IUserTypeRepository UserType { get; }
    }
}
