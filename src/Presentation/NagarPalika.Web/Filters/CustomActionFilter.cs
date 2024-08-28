using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NagarPalika.Application.Repository;
using Newtonsoft.Json;
using System.Text;

namespace Dalorian.Web.Filters
{
    public class CustomActionFilter : TypeFilterAttribute
    {
        public CustomActionFilter() : base(typeof(CustomActionFilterAttribute))
        {

        }
        private class CustomActionFilterAttribute : ActionFilterAttribute
        {
            private readonly IModuleRepository  _moduleRepository;

            public CustomActionFilterAttribute(IModuleRepository moduleRepository)
            {
                _moduleRepository = moduleRepository;
            }
            public async override void OnActionExecuting(ActionExecutingContext context)
            {
                //if (!context.ModelState.IsValid)
                //{
                //    context.Result = new BadRequestObjectResult(new { msg = context.ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage) });
                //}
                var controllerName = context.RouteData.Values["controller"];
                var actionName = context.RouteData.Values["action"];

                string pageurl = String.Format("/{0}/{1}", controllerName, actionName);
                string jsonrequest = JsonConvert.SerializeObject(pageurl);
                var content = new StringContent(jsonrequest, Encoding.UTF8, "application/json");

                //var response =  _httpClientService.SendRequest(HttpMethod.Post, "ModulePermission", content, null, "").Result;
                //string strcontent =  await response?.Content?.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode)
                //{
                //    var result = JsonConvert.DeserializeObject<ResponseClass<ModulePermissionResponse>>(strcontent);
                //    Controller controller = context.Controller as Controller;
                //    if (result.Data != null)
                //    {
                //        controller.ViewBag.CanAdd = result.Data.CanAdd;
                //        controller.ViewBag.CanEdit = result.Data.CanEdit;
                //        controller.ViewBag.CanDelete = result.Data.CanDelete;
                //        controller.ViewBag.ReadOnly = result.Data.ReadOnly;
                //    }
                //    controller.ViewBag.Message = result.Message;
                //}

                base.OnActionExecuting(context);
            }
        }
    }
}
