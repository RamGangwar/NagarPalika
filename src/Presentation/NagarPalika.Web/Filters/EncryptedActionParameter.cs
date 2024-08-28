using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Dalorian.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class EncryptedActionParameterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            if (filterContext.HttpContext.Request.Query != null && filterContext.HttpContext.Request.Query.Count > 0)
            {
                foreach (var item in filterContext.HttpContext.Request.Query)
                {
                    //string encryptedQry = filterContext.HttpContext.Request.Query[item.Value].ToString();
                    string decryptedString = DecryptUrl(item.Value);
                    int val = 0;
                    if (Int32.TryParse(decryptedString, out val))
                        param.Add(item.Key, Convert.ToInt32(decryptedString));
                    else
                        param.Add(item.Key, decryptedString);
                }
                //string encryptedQry = filterContext.HttpContext.Request.Query["Id"].ToString();
                //string decryptedString = DecryptUrl(encryptedQry);
                //string[] paramArrys = decryptedString.Split('?');
                //for (int i = 0; i < paramArrys.Length; i++)
                //{
                //    string[] paramarry = paramArrys[i].Split('=');
                //int val = 0;
                //if (Int32.TryParse(paramarry[1], out val))
                //    param.Add(paramarry[0], Convert.ToInt32(paramarry[1]));
                //else
                //    param.Add(paramarry[0], paramarry[1]);
                //}


            }

            for (int i = 0; i < param.Count; i++)
            {
                filterContext.ActionArguments[param.Keys.ElementAt(i)] = param.Values.ElementAt(i);
            }
            base.OnActionExecuting(filterContext);
        }

        public string DecryptUrl(string encrypted)
        {
            string result = string.Empty;
            string EncryptionKey = "CfDJ8ApzYX8juMVBn_gg8zQddWxRWlhx_Dalorian_BU3vdnUco0E463HQkR5AOc55gbYkPIzTjhn7T1gFgOIa6HxIHBPC5fhbuDF-_GA3cRoewDln_kmzLKnVqwzRxI0Cw";
            encrypted = encrypted.Replace(" ", "+");
            byte[] clearByte = Convert.FromBase64String(encrypted);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearByte, 0, clearByte.Length);
                        cs.Close();
                    }
                    result = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return result;
        }
    }

}
