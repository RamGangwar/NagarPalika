using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace Dalorian.Web.Extention
{
    public static class HtmlHelperViewExtensions
    {
        public static IHtmlContent Action(this IHtmlHelper helper, string action, object parameters = null)
        {
            var controller = (string)helper.ViewContext.RouteData.Values["controller"];
            return Action(helper, action, controller, parameters);
        }

        public static IHtmlContent Action(this IHtmlHelper helper, string action, string controller, object parameters = null)
        {
            var area = (string)helper.ViewContext.RouteData.Values["area"];
            return Action(helper, action, controller, area, parameters);
        }

        public static IHtmlContent Action(this IHtmlHelper helper, string action, string controller, string area, object parameters = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(controller));
            if (controller == null)
                throw new ArgumentNullException(nameof(action));

            var task = ActionAsync(helper, action, controller, area, parameters);
            return task.Result;
        }

        private static async Task<IHtmlContent> ActionAsync(this IHtmlHelper helper, string action, string controller, string area, object parameters = null)
        {
            // fetching required services for invocation
            var currentHttpContext = helper.ViewContext.HttpContext;
            var httpContextFactory = GetServiceOrFail<IHttpContextFactory>(currentHttpContext);
            var actionInvokerFactory = GetServiceOrFail<IActionInvokerFactory>(currentHttpContext);
            var actionSelector = GetServiceOrFail<IActionDescriptorCollectionProvider>(currentHttpContext);

            // creating new action invocation context
            var routeData = new RouteData();
            var routeParams = new RouteValueDictionary(parameters ?? new { });
            var routeValues = new RouteValueDictionary(new { area, controller, action });
            var newHttpContext = httpContextFactory.Create(currentHttpContext.Features);

            newHttpContext.Response.Body = new MemoryStream();

            foreach (var router in helper.ViewContext.RouteData.Routers)
                routeData.PushState(router, null, null);

            routeData.PushState(null, routeValues, null);
            routeData.PushState(null, routeParams, null);

            var actionDescriptor = actionSelector.ActionDescriptors.Items.First(i => i.RouteValues["Controller"] == controller && i.RouteValues["Action"] == action);
            var actionContext = new ActionContext(newHttpContext, routeData, actionDescriptor);

            // invoke action and retreive the response body
            var invoker = actionInvokerFactory.CreateInvoker(actionContext);
            string content = null;

            await invoker.InvokeAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    content = task.Exception.Message;
                }
                else if (task.IsCompleted)
                {
                    newHttpContext.Response.Body.Position = 0;
                    using (var reader = new StreamReader(newHttpContext.Response.Body))
                        content = reader.ReadToEnd();
                }
            });

            return new HtmlString(content);
        }
        public static IHtmlContent EncodedActionLink(this IHtmlHelper htmlHelper, string linkText_Ram, string actionName_Ram, string controllerName_Ram, object routeValue_Ram, object htmlAttributes_Ram, string classIcon_Ram)
        {
            string queryString = string.Empty;
            string htmlAttributesString = string.Empty;
            if (routeValue_Ram != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(routeValue_Ram);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += "?";
                    }
                    queryString += d.Keys.ElementAt(i) + " = " + d.Values.ElementAt(i);
                }
            }
            if (htmlAttributes_Ram != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(htmlAttributes_Ram);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        htmlAttributesString += "?";
                    }
                    htmlAttributesString += d.Keys.ElementAt(i) + " = '" + d.Values.ElementAt(i) + "'";
                }
            }

            StringBuilder anchor = new StringBuilder();
            anchor.Append("<a ");
            if (htmlAttributesString != string.Empty)
            {
                anchor.Append(htmlAttributesString);
            }
            anchor.Append(" href='");
            if (controllerName_Ram != string.Empty)
            {
                anchor.Append("/" + controllerName_Ram);
            }
            if (actionName_Ram != "Index")
            {
                anchor.Append("/" + actionName_Ram);
            }
            if (queryString != string.Empty)
            {
                anchor.Append("?q=" + EncryptUrl(queryString));
            }

            anchor.Append("'");
            anchor.Append("> ");
            if (!string.IsNullOrEmpty(classIcon_Ram))
            {
                //anchor.Append("<i class='" + classIcon_Ram + "'></i> ");

                anchor.Append("<img src ='"+ classIcon_Ram + "' alt = ''>");
            }
            //anchor.Append(linkText_Ram);
            anchor.Append("</a>");
            return new HtmlString(anchor.ToString());

        }

        public static IHtmlContent ActionLinkEncrypted(this IHtmlHelper htmlHelper, string linkText_Ram, string actionName_Ram, string controllerName_Ram, object routeValue_Ram, object htmlAttributes_Ram, string classIcon_Ram)
        {
            string queryString = string.Empty;
            string htmlAttributesString = string.Empty;
            if (routeValue_Ram != null)
            {
                //RouteValueDictionary d = new RouteValueDictionary(routeValue_Ram);
                //for (int i = 0; i < d.Keys.Count; i++)
                //{
                //    if (i > 0)
                //    {
                //        queryString += "?";
                //    }
                //    queryString += d.Keys.ElementAt(i) + " = " + d.Values.ElementAt(i);
                //}
                queryString = routeValue_Ram.ToString();
            }
            if (htmlAttributes_Ram != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(htmlAttributes_Ram);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        htmlAttributesString += "?";
                    }
                    htmlAttributesString += d.Keys.ElementAt(i) + " = '" + d.Values.ElementAt(i) + "'";
                }
            }

            StringBuilder anchor = new StringBuilder();
            anchor.Append("<a ");
            if (htmlAttributesString != string.Empty)
            {
                anchor.Append(htmlAttributesString);
            }
            anchor.Append(" href='");
            if (controllerName_Ram != string.Empty)
            {
                anchor.Append("/" + controllerName_Ram);
            }
            if (actionName_Ram != "Index")
            {
                anchor.Append("/" + actionName_Ram);
            }
            if (queryString != string.Empty)
            {
                anchor.Append("?Id=" + EncryptUrl(queryString));
            }

            anchor.Append("'");
            anchor.Append("> ");
            if (!string.IsNullOrEmpty(classIcon_Ram))
            {
                anchor.Append("<i class='" + classIcon_Ram + "'></i> ");

                //anchor.Append("<img src ='" + classIcon_Ram + "' alt = ''>");
            }
            anchor.Append(linkText_Ram);
            anchor.Append("</a>");
            return new HtmlString(anchor.ToString());

        }
        public static string EncryptUrl(object str)
        {
            string result = string.Empty;
            string EncryptionKey = "CfDJ8ApzYX8juMVBn_gg8zQddWxRWlhx_Dalorian_BU3vdnUco0E463HQkR5AOc55gbYkPIzTjhn7T1gFgOIa6HxIHBPC5fhbuDF-_GA3cRoewDln_kmzLKnVqwzRxI0Cw";
            byte[] clearByte = Encoding.Unicode.GetBytes(str.ToString());
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearByte, 0, clearByte.Length);
                        cs.Close();
                    }
                    result = Convert.ToBase64String(ms.ToArray());
                    result = result.Replace(" ", "+");
                }
            }
            return result;
        }

        private static TService GetServiceOrFail<TService>(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            var service = httpContext.RequestServices.GetService(typeof(TService));

            if (service == null)
                throw new InvalidOperationException($"Could not locate service: {nameof(TService)}");

            return (TService)service;
        }
    }
}
