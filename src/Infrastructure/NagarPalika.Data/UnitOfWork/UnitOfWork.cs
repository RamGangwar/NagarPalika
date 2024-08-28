using Microsoft.Extensions.Configuration;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Data.Repository;

namespace NagarPalika.Data.UnitOfWork
{
    public class UnitofWork : BaseUnitOfWork, IUnitofWork
    {

        public UnitofWork(IConfiguration configuration) : base(configuration)
        {

        }

        public IEmployeeRepository Employee => new EmployeeRepository(this);
        public IRefreshTokensRepository RefreshToken => new RefreshTokensRepository(this);
        public IDepartmentRepository Departments => new DepartmentRepository(this);
        public IDesignationRepository Designations => new DesignationRepository(this);
        public IModuleRepository Modules => new ModulesRepository(this);
        public IRolesRepository Roles => new RolesRepository(this);
        public IWardsRepository Wards => new WardsRepository(this);
        public IAccessPermissionRepository Permissions => new AccessPermissionRepository(this);
        public IDistrictsRepository Districts => new DistrictsRepository(this);
        public ILocalityRepository Locality => new LocalityRepository(this);
        public IOrganizationsRepository Organizations => new OrganizationsRepository(this);
        public IZonesRepository Zones => new ZonesRepository(this);
        public IConstructionTypeRepository ConstructionType => new ConstructionTypeRepository(this);
        public IDepriciationSlabRepository DepriciationSlab => new DepriciationSlabRepository(this);
        public IDisabilitySlabRepository DisabilitySlab => new DisabilitySlabRepository(this);
        public IDiscountSlabRepository DiscountSlab => new DiscountSlabRepository(this);
        public IFineCriteriaRepository FineCriteria => new FineCriteriaRepository(this);
        public IMonthlyRentalRateRepository MonthlyRentalRate => new MonthlyRentalRateRepository(this);
        public IMutationTypeRepository MutationType => new MutationTypeRepository(this);
        public IPropertyTypeRepository PropertyType => new PropertyTypeRepository(this);
        public IRecieptBooksRepository RecieptBooks => new RecieptBooksRepository(this);
        public IRoadWidthTypeRepository RoadWidthType => new RoadWidthTypeRepository(this);
        public ITariffPlanRepository TariffPlan => new TariffPlanRepository(this);
        public ITenantSlabRepository TenantSlab => new TenantSlabRepository(this);
        public IAssetCategoryRepository AssetCategorys => new AssetCategoryRepository(this);
        public IAssetSubCategoryRepository AssetSubCategorys => new AssetSubCategoryRepository(this);
        public IPosessonModeRepository PosessonModes => new PosessonModeRepository(this);
        public IRNLAllotmentRepository RNLAllotments => new RNLAllotmentRepository(this);
        public IRNLArrearRepository RNLArrears => new RNLArrearRepository(this);
        public IRNLPropertyRepository RNLPropertys => new RNLPropertyRepository(this);
        public IPropertyRepository Property => new PropertyRepository(this);
        public ISessionMasterRepository SessionMaster => new SessionMasterRepository(this);
        public ITradeCategoryRepository TradeCategory => new TradeCategoryRepository(this);
        public ITradeDocumentRepository TradeDocuments => new TradeDocumentRepository(this);
        public ITradeRegistrationRepository TradeRegistration => new TradeRegistrationRepository(this);
        public ITradeSubCategoryRepository TradeSubCategory => new TradeSubCategoryRepository(this);
        public IUserTypeRepository UserType => new UserTypeRepository(this);
    }
}
