using MediatR;
using Microsoft.AspNetCore.Mvc;
using NagarPalika.Application.Queries.Modules;

namespace NagarPalika.Web
{
    [ViewComponentAttribute]
    public class LeftmenuViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        public LeftmenuViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IViewComponentResult Invoke()
        {
            var result = _mediator.Send(new GetModulesByFilterQuery { RoleId = 0, EmployeeId = 0 }).Result;
            return View(result);
        }

    }
}
