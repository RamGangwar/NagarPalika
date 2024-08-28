using MediatR;
using Microsoft.AspNetCore.Mvc;
using NagarPalika.Application.Commands.AssetCategorys;
using NagarPalika.Application.Queries.AssetCategorys;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using Mapster;
using NagarPalika.Application.Queries.AssetSubCategorys;
using NagarPalika.Application.Commands.AssetSubCategorys;

namespace NagarPalika.Web.Controllers
{
    [CustomAuthorizationAttribute]
    public class RentLeaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitofWork _unitofwork;

        public RentLeaseController(ILogger<HomeController> logger, IMediator mediator, IUnitofWork unitofwork)
        {
            _logger = logger;
            _mediator = mediator;
            _unitofwork = unitofwork;
        }

        #region AssetCategory Section
        public async Task<IActionResult> AssetCategoryList()
        {
            _logger.LogInformation(nameof(AssetCategoryList));
            return View();
        }
        public async Task<IActionResult> BindAssetCategoryList(DTParameters para, GetAssetCategoryByFilterQuery request)
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
                request.SortBy = "AssetCategoryName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindAssetCategoryList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditAssetCategory(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditAssetCategory), Id);
            var req = new CreateAssetCategoryCommand();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetAssetCategoryByIdQuery { AssetCategoryId = Id });
                req = empl.Data.Adapt<CreateAssetCategoryCommand>();
            }
            return PartialView("/views/RentLease/_addeditAssetCategory.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditAssetCategory(CreateAssetCategoryCommand command)
        {
            _logger.LogInformation(nameof(AddEditAssetCategory), command);
            if (command.AssetCategoryId > 0)
            {
                var req = command.Adapt<UpdateAssetCategoryCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteAssetCategory(int AssetCategoryId)
        {
            _logger.LogInformation(nameof(DeleteAssetCategory), AssetCategoryId);
            var empl = await _mediator.Send(new DeleteAssetCategoryCommand { AssetCategoryId = AssetCategoryId });
            return Json(empl);
        }

        #endregion

        #region AssetSubCategory Section
        public async Task<IActionResult> AssetSubCategoryList()
        {
            _logger.LogInformation(nameof(AssetSubCategoryList));
            return View();
        }
        public async Task<IActionResult> BindAssetSubCategoryList(DTParameters para, GetAssetSubCategoryByFilterQuery request)
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
                request.SortBy = "AssetSubCategoryName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindAssetSubCategoryList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditAssetSubCategory(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditAssetSubCategory), Id);
            var req = new CreateAssetSubCategoryCommand();
            var categlist = await _unitofwork.AssetCategorys.GetALL();
            ViewBag.CategoryList = categlist.Where(w => w.IsActive == true).ToList();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetAssetSubCategoryByIdQuery { AssetSubCategoryId = Id });
                req = empl.Data.Adapt<CreateAssetSubCategoryCommand>();
            }
            return PartialView("/views/RentLease/_addeditAssetSubCategory.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditAssetSubCategory(CreateAssetSubCategoryCommand command)
        {
            _logger.LogInformation(nameof(AddEditAssetSubCategory), command);
            if (command.AssetSubCategoryId > 0)
            {
                var req = command.Adapt<UpdateAssetSubCategoryCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteAssetSubCategory(int AssetSubCategoryId)
        {
            _logger.LogInformation(nameof(DeleteAssetSubCategory), AssetSubCategoryId);
            var empl = await _mediator.Send(new DeleteAssetSubCategoryCommand { AssetSubCategoryId = AssetSubCategoryId });
            return Json(empl);
        }

        #endregion
    }
}
