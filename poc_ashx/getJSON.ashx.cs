using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace poc_ashx
{
    /// <summary>
    /// Description résumée de getJSON
    /// </summary>
    public class getJSON : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string param1 = context.Request.QueryString["param1"];


            context.Response.ContentType = "text/json";
            //context.Response.Write("Hello World");

            context.Response.Write(
                JsonConvert.SerializeObject(
                    new
                    {
                        query = "Li",
                        suggestions = new[] { param1, "Libyan Arab Jamahiriya", "Liechtenstein", "Lithuania" },
                        data = new[] { "LR", "LY", "LI", "LT" }
                    }
                )
            );
           

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}