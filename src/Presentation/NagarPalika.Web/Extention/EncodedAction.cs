
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace NagarPalika.Model.Helper
{
    public static class EncodedAction
    {
        public static MvcHtmlString EncodedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValue, object htmlAttributes, string classIcon)
        {
            string queryString = string.Empty;
            string htmlAttributesString = string.Empty;
            if (routeValue != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(routeValue);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += "?";
                    }
                    queryString += d.Keys.ToString() + " = " + d.Values.ToString();
                }
            }
            if (htmlAttributes != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(htmlAttributes);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        htmlAttributesString += "?";
                    }
                    htmlAttributesString += d.Keys.ToString() + " = " + d.Values.ToString();
                }
            }

            StringBuilder anchor = new StringBuilder();
            anchor.Append("<a ");
            if (htmlAttributesString != string.Empty)
            {
                anchor.Append(htmlAttributesString);
            }
            anchor.Append("href='");
            if (controllerName != string.Empty)
            {
                anchor.Append("/" + controllerName);
            }
            if (actionName != "Index")
            {
                anchor.Append("/" + actionName);
            }
            if (queryString != string.Empty)
            {
                anchor.Append("?q=" + EncryptUrl(queryString));
            }

            anchor.Append("'");
            anchor.Append("> ");
            if (!string.IsNullOrEmpty(classIcon))
            {
                anchor.Append("<i class='" + classIcon + "'></i> ");
            }
            anchor.Append(linkText);
            anchor.Append("</a>");
            return new MvcHtmlString(anchor.ToString());

        }


        public static string EncryptUrl(string str)
        {
            string result = string.Empty;
            string EncryptionKey = "CfDJ8ApzYX8juMVBn_gg8zQddWxRWlhx_Dalorian_BU3vdnUco0E463HQkR5AOc55gbYkPIzTjhn7T1gFgOIa6HxIHBPC5fhbuDF-_GA3cRoewDln_kmzLKnVqwzRxI0Cw";
            byte[] clearByte = Encoding.Unicode.GetBytes(str);
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
                }
            }
            return result;
        }
    }
}
