using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NagarPalika.Application.Commands.TradeCategorys;
using NagarPalika.Application.Commands.TradeDocuments;
using NagarPalika.Application.Commands.TradeRegistrations;
using NagarPalika.Application.Commands.TradeSubCategorys;
using NagarPalika.Application.Queries.TradeCategorys;
using NagarPalika.Application.Queries.TradeDocuments;
using NagarPalika.Application.Queries.TradeRegistrations;
using NagarPalika.Application.Queries.TradeSubCategorys;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;

namespace NagarPalika.Web.Controllers
{
    [CustomAuthorizationAttribute]
    public class TradeLicenceController : Controller
    {
        private readonly ILogger<TradeLicenceController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitofWork _unitofwork;
        public TradeLicenceController(ILogger<TradeLicenceController> logger, IMediator mediator, IUnitofWork unitofwork)
        {
            _logger = logger;
            _mediator = mediator;
            _unitofwork = unitofwork;
        }
       
        #region TradeCategory Section
        public async Task<IActionResult> TradeCategoryList()
        {
            _logger.LogInformation(nameof(TradeCategoryList));
            return View();
        }
        public async Task<IActionResult> BindTradeCategoryList(DTParameters para, GetTradeCategoryByFilterQuery request)
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
                request.SortBy = "TradeCategoryName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(TradeCategoryList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditTradeCategory(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditTradeCategory));
            var request = new CreateTradeCategoryCommand();
            
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetTradeCategoryByIdQuery { TradeCategoryId = Id });
                request = empl.Data.Adapt<CreateTradeCategoryCommand>();
            }
            return PartialView("/views/TradeLicence/_AddEditTradeCategory.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditTradeCategory(CreateTradeCategoryCommand command)
        {
            _logger.LogInformation(nameof(AddEditTradeCategory), command);
            if (command.TradeCategoryId > 0)
            {
                var req = command.Adapt<UpdateTradeCategoryCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteTradeCategory(int TradeCategoryId)
        {
            _logger.LogInformation(nameof(DeleteTradeCategory), TradeCategoryId);
            var empl = await _mediator.Send(new DeleteTradeCategoryCommand { TradeCategoryId = TradeCategoryId });
            return Ok(empl);
        }

        #endregion

        #region TradeDocument Section
        public async Task<IActionResult> TradeDocumentList()
        {
            _logger.LogInformation(nameof(TradeDocumentList));
            return View();
        }
        public async Task<IActionResult> BindTradeDocumentList(DTParameters para, GetTradeDocumentByFilterQuery request)
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
                request.SortBy = "TradeDocumentName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(TradeDocumentList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditTradeDocument(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditTradeDocument));
            var request = new CreateTradeDocumentCommand();

            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetTradeDocumentByIdQuery { TradeDocumentId = Id });
                request = empl.Data.Adapt<CreateTradeDocumentCommand>();
            }
            return PartialView("/views/TradeLicence/_AddEditTradeDocument.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditTradeDocument(CreateTradeDocumentCommand command)
        {
            _logger.LogInformation(nameof(AddEditTradeDocument), command);
            if (command.TradeDocumentId > 0)
            {
                var req = command.Adapt<UpdateTradeDocumentCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteTradeDocument(int TradeDocumentId)
        {
            _logger.LogInformation(nameof(DeleteTradeDocument), TradeDocumentId);
            var empl = await _mediator.Send(new DeleteTradeDocumentCommand { TradeDocumentId = TradeDocumentId });
            return Ok(empl);
        }

        #endregion

        #region TradeSubCategory Section
        public async Task<IActionResult> TradeSubCategoryList()
        {
            _logger.LogInformation(nameof(TradeSubCategoryList));
            return View();
        }
        public async Task<IActionResult> BindTradeSubCategoryList(DTParameters para, GetTradeSubCategoryByFilterQuery request)
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
                request.SortBy = "TradeSubCategoryName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(TradeSubCategoryList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditTradeSubCategory(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditTradeSubCategory));
            var request = new CreateTradeSubCategoryCommand();
            var categoryList = await _unitofwork.TradeCategory.GetALL();
            ViewBag.TradeCate=categoryList.ToList();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetTradeSubCategoryByIdQuery { TradeSubCategoryId = Id });
                request = empl.Data.Adapt<CreateTradeSubCategoryCommand>();
            }
            return PartialView("/views/TradeLicence/_AddEditTradeSubCategory.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditTradeSubCategory(CreateTradeSubCategoryCommand command)
        {
            _logger.LogInformation(nameof(AddEditTradeSubCategory), command);
            if (command.TradeSubCategoryId > 0)
            {
                var req = command.Adapt<UpdateTradeSubCategoryCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteTradeSubCategory(int TradeSubCategoryId)
        {
            _logger.LogInformation(nameof(DeleteTradeSubCategory), TradeSubCategoryId);
            var empl = await _mediator.Send(new DeleteTradeSubCategoryCommand { TradeSubCategoryId = TradeSubCategoryId });
            return Ok(empl);
        }

        #endregion

        #region TradeRegistration Section
        public async Task<IActionResult> TradeRegistrationList()
        {
            _logger.LogInformation(nameof(TradeRegistrationList));
            return View();
        }
        public async Task<IActionResult> BindTradeRegistrationList(DTParameters para, GetTradeRegistrationByFilterQuery request)
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
                request.SortBy = "TradeName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(TradeRegistrationList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditTradeRegistration(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditTradeRegistration));
            var request = new CreateTradeRegistrationCommand();
            var categoryList = await _unitofwork.TradeCategory.GetALL();
            var zones = await _unitofwork.Zones.GetALL();
            var wards = await _unitofwork.Wards.GetALL();
            var localits = await _unitofwork.Locality.GetALL();
            var subcategorys = await _unitofwork.TradeSubCategory.GetALL();


            ViewBag.TradeCate = categoryList.ToList();
            ViewBag.ZoneList = zones.ToList();
            ViewBag.WardList = wards.ToList();
            ViewBag.LocalityList = localits.ToList();
            ViewBag.SubCategory = subcategorys.ToList();


            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetTradeRegistrationByIdQuery { TradeRegistrationId = Id });
                request = empl.Data.Adapt<CreateTradeRegistrationCommand>();
            }
            return View("/views/TradeLicence/AddEditTradeRegistration.cshtml", request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditTradeRegistration(CreateTradeRegistrationCommand command)
        {
            _logger.LogInformation(nameof(AddEditTradeRegistration), command);
            if (command.TradeRegistrationId > 0)
            {
                var req = command.Adapt<UpdateTradeRegistrationCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteTradeRegistration(int TradeRegistrationId)
        {
            _logger.LogInformation(nameof(DeleteTradeRegistration), TradeRegistrationId);
            var empl = await _mediator.Send(new DeleteTradeRegistrationCommand { TradeRegistrationId = TradeRegistrationId });
            return Ok(empl);
        }

        #endregion
    }
}
