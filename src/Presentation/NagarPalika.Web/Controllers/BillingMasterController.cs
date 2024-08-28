using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NagarPalika.Application.Commands.ConstructionTypes;
using NagarPalika.Application.Commands.DepriciationSlabs;
using NagarPalika.Application.Commands.DisabilitySlabs;
using NagarPalika.Application.Commands.DiscountSlabs;
using NagarPalika.Application.Commands.FineCriterias;
using NagarPalika.Application.Commands.MonthlyRentalRates;
using NagarPalika.Application.Commands.MutationTypes;
using NagarPalika.Application.Commands.PropertyTypes;
using NagarPalika.Application.Commands.RecieptBookss;
using NagarPalika.Application.Commands.RoadWidthTypes;
using NagarPalika.Application.Commands.TariffPlans;
using NagarPalika.Application.Commands.TenantSlabs;
using NagarPalika.Application.Commands.User;
using NagarPalika.Application.Queries.ConstructionTypes;
using NagarPalika.Application.Queries.DepriciationSlabs;
using NagarPalika.Application.Queries.DisabilitySlabs;
using NagarPalika.Application.Queries.DiscountSlabs;
using NagarPalika.Application.Queries.FineCriterias;
using NagarPalika.Application.Queries.MonthlyRentalRates;
using NagarPalika.Application.Queries.MutationTypes;
using NagarPalika.Application.Queries.PropertyTypes;
using NagarPalika.Application.Queries.RecieptBookss;
using NagarPalika.Application.Queries.RoadWidthTypes;
using NagarPalika.Application.Queries.TariffPlans;
using NagarPalika.Application.Queries.TenantSlabs;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;

namespace NagarPalika.Web.Controllers
{
    [CustomAuthorizationAttribute]
    public class BillingMasterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitofWork _unitofwork;
        public BillingMasterController(IMediator mediator, ILogger<HomeController> logger, IUnitofWork unitofwork)
        {
            _mediator = mediator;
            _logger = logger;
            _unitofwork = unitofwork;
        }
        #region PropertyType Section
        public async Task<IActionResult> PropertyTypeList()
        {
            _logger.LogInformation(nameof(PropertyTypeList));
            return View();
        }
        public async Task<IActionResult> BindPropertyTypeList(DTParameters para, GetPropertyTypeByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "PropertyTypeName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(PropertyTypeList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditPropertyType(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditPropertyType));
            var request = new CreatePropertyTypeCommand();
            var gradeList = new List<SelectItem>();
            for (int i = 1; i <= 10; i++)
            {
                var grade = new SelectItem();
                grade.Text = grade.Value = "Grade " + i;
                gradeList.Add(grade);
            }
            ViewBag.GradeList = gradeList;
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetPropertyTypeByIdQuery { PropertyTypeId = Id });
                empl.Data.IconUrl = null;
                request = empl.Data.Adapt<CreatePropertyTypeCommand>();
            }
            return PartialView("/views/BillingMaster/_AddEditPropertyType.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditPropertyType(CreatePropertyTypeCommand command)
        {
            _logger.LogInformation(nameof(AddEditPropertyType), command);
            //if (command.PropertyTypeId > 0)
            //{
            //    var req = command.Adapt<UpdatePropertyTypeCommand>();
            //    var empl = await _mediator.Send(req);
            //    return Json(empl);
            //}
            //else
            //{
            var empl = await _mediator.Send(command);
            return Json(empl);
            //}
        }
        public async Task<IActionResult> DeletePropertyType(int PropertyTypeId)
        {
            _logger.LogInformation(nameof(DeletePropertyType), PropertyTypeId);
            var empl = await _mediator.Send(new DeletePropertyTypeCommand { PropertyTypeId = PropertyTypeId });
            return Ok(empl);
        }

        #endregion

        #region RoadWidthType Section
        public async Task<IActionResult> RoadWidthTypeList()
        {
            _logger.LogInformation(nameof(RoadWidthTypeList));
            return View();
        }
        public async Task<IActionResult> BindRoadWidthTypeList(DTParameters para, GetRoadWidthTypeByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "RoadWidthTypeName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(RoadWidthTypeList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditRoadWidthType(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditRoadWidthType));
            var request = new CreateRoadWidthTypeCommand();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetRoadWidthTypeByIdQuery { RoadWidthTypeId = Id });
                request = empl.Data.Adapt<CreateRoadWidthTypeCommand>();
            }
            return PartialView("/views/BillingMaster/_AddEditRoadWidthType.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditRoadWidthType(CreateRoadWidthTypeCommand command)
        {
            _logger.LogInformation(nameof(AddEditRoadWidthType), command);
            if (command.RoadWidthTypeId > 0)
            {
                var req = command.Adapt<UpdateRoadWidthTypeCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteRoadWidthType(int RoadWidthTypeId)
        {
            _logger.LogInformation(nameof(DeleteRoadWidthType), RoadWidthTypeId);
            var empl = await _mediator.Send(new DeleteRoadWidthTypeCommand { RoadWidthTypeId = RoadWidthTypeId });
            return Ok(empl);
        }

        #endregion

        #region ConstructionType Section
        public async Task<IActionResult> ConstructionTypeList()
        {
            _logger.LogInformation(nameof(ConstructionTypeList));
            return View();
        }
        public async Task<IActionResult> BindConstructionTypeList(DTParameters para, GetConstructionTypeByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "ConstructionTypeName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(ConstructionTypeList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditConstructionType(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditConstructionType));
            var request = new CreateConstructionTypeCommand();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetConstructionTypeByIdQuery { ConstructionTypeId = Id });
                request = empl.Data.Adapt<CreateConstructionTypeCommand>();
            }
            return PartialView("/views/BillingMaster/_AddEditConstructionType.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditConstructionType(CreateConstructionTypeCommand command)
        {
            _logger.LogInformation(nameof(AddEditConstructionType), command);
            if (command.ConstructionTypeId > 0)
            {
                var req = command.Adapt<UpdateConstructionTypeCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteConstructionType(int ConstructionTypeId)
        {
            _logger.LogInformation(nameof(DeleteConstructionType), ConstructionTypeId);
            var empl = await _mediator.Send(new DeleteConstructionTypeCommand { ConstructionTypeId = ConstructionTypeId });
            return Ok(empl);
        }

        #endregion
        #region MonthlyRentalRate Section
        public async Task<IActionResult> MonthlyRentalRateList()
        {
            _logger.LogInformation(nameof(MonthlyRentalRateList));
            return View();
        }
        public async Task<IActionResult> BindMonthlyRentalRateList(DTParameters para, GetMonthlyRentalRateByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "W.WardName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(MonthlyRentalRateList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditMonthlyRentalRate(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditMonthlyRentalRate));
            var request = new CreateMonthlyRentalRateCommand();
            var roadwidth = await _unitofwork.RoadWidthType.GetALL();
            var construction = await _unitofwork.ConstructionType.GetALL();
            var ward = await _unitofwork.Wards.GetALL();
            var locality = await _unitofwork.Locality.GetALL();
            ViewBag.RoadWidthList = roadwidth.Select(s => new { Id = s.RoadWidthTypeId, Name = s.RoadWidthTypeName }).ToList();
            ViewBag.ConstructionList = construction.Select(s => new { Id = s.ConstructionTypeId, Name = s.ConstructionTypeName }).ToList();
            ViewBag.WardList = ward.Select(s => new { Id = s.WardId, Name = s.WardName }).ToList();
            ViewBag.LocalityList = locality.Select(s => new { Id = s.LocalityId, Name = s.LocalityCode + " " + s.LocalityName }).ToList();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetMonthlyRentalRateByIdQuery { MonthlyRentalRateId = Id });
                request = empl.Data.Adapt<CreateMonthlyRentalRateCommand>();
            }
            return View("/views/BillingMaster/AddEditMonthlyRentalRate.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditMonthlyRentalRate(CreateMonthlyRentalRateCommand command)
        {
            _logger.LogInformation(nameof(AddEditMonthlyRentalRate), command);
            if (command.MonthlyRentalRateId > 0)
            {
                var req = command.Adapt<UpdateMonthlyRentalRateCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteMonthlyRentalRate(int MonthlyRentalRateId)
        {
            _logger.LogInformation(nameof(DeleteMonthlyRentalRate), MonthlyRentalRateId);
            var empl = await _mediator.Send(new DeleteMonthlyRentalRateCommand { MonthlyRentalRateId = MonthlyRentalRateId });
            return Ok(empl);
        }

        #endregion

        #region TariffPlan Section
        public async Task<IActionResult> TariffPlanList()
        {
            _logger.LogInformation(nameof(TariffPlanList));
            return View();
        }
        public async Task<IActionResult> BindTariffPlanList(DTParameters para, GetTariffPlanByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "PropertyType";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(TariffPlanList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditTariffPlan(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditTariffPlan));
            var request = new CreateTariffPlanCommand();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetTariffPlanByIdQuery { TariffPlanId = Id });
                request = empl.Data.Adapt<CreateTariffPlanCommand>();
            }
            return View("/views/BillingMaster/AddEditTariffPlan.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditTariffPlan(CreateTariffPlanCommand command)
        {
            _logger.LogInformation(nameof(AddEditTariffPlan), command);
            if (command.TariffPlanId > 0)
            {
                var req = command.Adapt<UpdateTariffPlanCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteTariffPlan(int TariffPlanId)
        {
            _logger.LogInformation(nameof(DeleteTariffPlan), TariffPlanId);
            var empl = await _mediator.Send(new DeleteTariffPlanCommand { TariffPlanId = TariffPlanId });
            return Ok(empl);
        }

        #endregion

        #region DepriciationSlab Section
        public async Task<IActionResult> DepriciationSlabList()
        {
            _logger.LogInformation(nameof(DepriciationSlabList));
            return View();
        }
        public async Task<IActionResult> BindDepriciationSlabList(DTParameters para, GetDepriciationSlabByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "DS.PropertyType";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(DepriciationSlabList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditDepriciationSlab(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditDepriciationSlab));
            var request = new CreateDepriciationSlabCommand();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetDepriciationSlabByIdQuery { DepriciationSlabId = Id });
                request = empl.Data.Adapt<CreateDepriciationSlabCommand>();
            }
            return PartialView("/views/BillingMaster/_AddEditDepriciationSlab.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditDepriciationSlab(CreateDepriciationSlabCommand command)
        {
            _logger.LogInformation(nameof(AddEditDepriciationSlab), command);
            if (command.DepriciationSlabId > 0)
            {
                var req = command.Adapt<UpdateDepriciationSlabCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteDepriciationSlab(int DepriciationSlabId)
        {
            _logger.LogInformation(nameof(DeleteDepriciationSlab), DepriciationSlabId);
            var empl = await _mediator.Send(new DeleteDepriciationSlabCommand { DepriciationSlabId = DepriciationSlabId });
            return Ok(empl);
        }

        #endregion

        #region DisabilitySlab Section
        public async Task<IActionResult> DisabilitySlabList()
        {
            _logger.LogInformation(nameof(DisabilitySlabList));
            return View();
        }
        public async Task<IActionResult> BindDisabilitySlabList(DTParameters para, GetDisabilitySlabByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "DS.PropertyType";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(DisabilitySlabList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditDisabilitySlab(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditDisabilitySlab));
            var request = new CreateDisabilitySlabCommand();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetDisabilitySlabByIdQuery { DisabilitySlabId = Id });
                request = empl.Data.Adapt<CreateDisabilitySlabCommand>();
            }
            return PartialView("/views/BillingMaster/_AddEditDisabilitySlab.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditDisabilitySlab(CreateDisabilitySlabCommand command)
        {
            _logger.LogInformation(nameof(AddEditDisabilitySlab), command);
            if (command.DisabilitySlabId > 0)
            {
                var req = command.Adapt<UpdateDisabilitySlabCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteDisabilitySlab(int DisabilitySlabId)
        {
            _logger.LogInformation(nameof(DeleteDisabilitySlab), DisabilitySlabId);
            var empl = await _mediator.Send(new DeleteDisabilitySlabCommand { DisabilitySlabId = DisabilitySlabId });
            return Ok(empl);
        }

        #endregion
        #region DiscountSlab Section
        public async Task<IActionResult> DiscountSlabList()
        {
            _logger.LogInformation(nameof(DiscountSlabList));
            return View();
        }
        public async Task<IActionResult> BindDiscountSlabList(DTParameters para, GetDiscountSlabByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "DS.PropertyType";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(DiscountSlabList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditDiscountSlab(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditDiscountSlab));
            var request = new CreateDiscountSlabCommand();
            request.StartDate = DateTime.Now;
            request.EndDate = DateTime.Now.AddDays(7);
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetDiscountSlabByIdQuery { DiscountSlabId = Id });
                request.DiscountSlabId = empl.Data.DiscountSlabId;
                request.PropertyType = empl.Data.PropertyType;
                request.StartDate = empl.Data.StartDate;
                request.EndDate = empl.Data.EndDate;
                request.Value = empl.Data.Value;
                request.SkipCondition = empl.Data.SkipCondition;
                //request = empl.Data.Adapt<CreateDiscountSlabCommand>();
            }
            return PartialView("/views/BillingMaster/_AddEditDiscountSlab.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditDiscountSlab(CreateDiscountSlabCommand command)
        {
            _logger.LogInformation(nameof(AddEditDiscountSlab), command);
            if (command.DiscountSlabId > 0)
            {
                var req = command.Adapt<UpdateDiscountSlabCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteDiscountSlab(int DiscountSlabId)
        {
            _logger.LogInformation(nameof(DeleteDiscountSlab), DiscountSlabId);
            var empl = await _mediator.Send(new DeleteDiscountSlabCommand { DiscountSlabId = DiscountSlabId });
            return Ok(empl);
        }

        #endregion

        #region FineCriteria Section
        public async Task<IActionResult> FineCriteriaList()
        {
            _logger.LogInformation(nameof(FineCriteriaList));
            return View();
        }
        public async Task<IActionResult> BindFineCriteriaList(DTParameters para, GetFineCriteriaByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "PropertyType";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(FineCriteriaList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditFineCriteria(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditFineCriteria));
            var request = new CreateFineCriteriaCommand();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetFineCriteriaByIdQuery { FineCriteriaId = Id });
                request = empl.Data.Adapt<CreateFineCriteriaCommand>();
            }
            return View("/views/BillingMaster/AddEditFineCriteria.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditFineCriteria(CreateFineCriteriaCommand command)
        {
            _logger.LogInformation(nameof(AddEditFineCriteria), command);
            if (command.FineCriteriaId > 0)
            {
                var req = command.Adapt<UpdateFineCriteriaCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteFineCriteria(int FineCriteriaId)
        {
            _logger.LogInformation(nameof(DeleteFineCriteria), FineCriteriaId);
            var empl = await _mediator.Send(new DeleteFineCriteriaCommand { FineCriteriaId = FineCriteriaId });
            return Ok(empl);
        }

        #endregion

        #region TenantSlab Section
        public async Task<IActionResult> TenantSlabList()
        {
            _logger.LogInformation(nameof(TenantSlabList));
            return View();
        }
        public async Task<IActionResult> BindTenantSlabList(DTParameters para, GetTenantSlabByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "TS.PropertyType";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(TenantSlabList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditTenantSlab(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditTenantSlab));
            var request = new CreateTenantSlabCommand();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetTenantSlabByIdQuery { TenantSlabId = Id });
                request = empl.Data.Adapt<CreateTenantSlabCommand>();
            }
            return PartialView("/views/BillingMaster/_AddEditTenantSlab.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditTenantSlab(CreateTenantSlabCommand command)
        {
            _logger.LogInformation(nameof(AddEditTenantSlab), command);
            if (command.TenantSlabId > 0)
            {
                var req = command.Adapt<UpdateTenantSlabCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteTenantSlab(int TenantSlabId)
        {
            _logger.LogInformation(nameof(DeleteTenantSlab), TenantSlabId);
            var empl = await _mediator.Send(new DeleteTenantSlabCommand { TenantSlabId = TenantSlabId });
            return Ok(empl);
        }

        #endregion

        #region RecieptBooks Section
        public async Task<IActionResult> RecieptBooksList(string t)
        {
            _logger.LogInformation(nameof(RecieptBooksList));
            ViewBag.type = t;
            return View();
        }
        public async Task<IActionResult> BindRecieptBooksList(DTParameters para, GetRecieptBooksByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "RB.RecieptBook";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(RecieptBooksList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditRecieptBooks(string bookType , int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditRecieptBooks));
            var request = new CreateRecieptBooksCommand();
            request.BookType = bookType;
            var employeeList = await _unitofwork.Employee.GetALL();
            ViewBag.EmpList = employeeList.ToList();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetRecieptBooksByIdQuery { RecieptBookId = Id });
                request = empl.Data.Adapt<CreateRecieptBooksCommand>();
            }
            return PartialView("/views/BillingMaster/_AddEditRecieptBooks.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditRecieptBooks(CreateRecieptBooksCommand command)
        {
            _logger.LogInformation(nameof(AddEditRecieptBooks), command);
            if (command.RecieptBookId > 0)
            {
                var req = command.Adapt<UpdateRecieptBooksCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteRecieptBooks(int RecieptBooksId)
        {
            _logger.LogInformation(nameof(DeleteRecieptBooks), RecieptBooksId);
            var empl = await _mediator.Send(new DeleteRecieptBooksCommand { RecieptBookId = RecieptBooksId });
            return Ok(empl);
        }

        #endregion


        #region MutationType Section
        public async Task<IActionResult> MutationTypeList()
        {
            _logger.LogInformation(nameof(MutationTypeList));
            return View();
        }
        public async Task<IActionResult> BindMutationTypeList(DTParameters para, GetMutationTypeByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "MutationTypeName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(MutationTypeList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditMutationType(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditMutationType));
            var request = new CreateMutationTypeCommand();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetMutationTypeByIdQuery { MutationTypeId = Id });
                request = empl.Data.Adapt<CreateMutationTypeCommand>();
            }
            return PartialView("/views/BillingMaster/_AddEditMutationType.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditMutationType(CreateMutationTypeCommand command)
        {
            _logger.LogInformation(nameof(AddEditMutationType), command);
            if (command.MutationTypeId > 0)
            {
                var req = command.Adapt<UpdateMutationTypeCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteMutationType(int MutationTypeId)
        {
            _logger.LogInformation(nameof(DeleteMutationType), MutationTypeId);
            var empl = await _mediator.Send(new DeleteMutationTypeCommand { MutationTypeId = MutationTypeId });
            return Ok(empl);
        }

        #endregion
    }
}
