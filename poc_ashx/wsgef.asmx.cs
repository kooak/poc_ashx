using System;
using System.IO;
using System.Net;
using System.Web.Services;
using Newtonsoft.Json;


namespace poc_ashx
{
    /// <summary>
    /// Description résumée de wsgef
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class wsgef : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            

            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50530/getJSON.ashx?param1=65");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
            MyData tmp = JsonConvert.DeserializeObject<MyData>(json);
            return tmp.suggestions[0]; ;

        }
    }

    class MyData
    {
        public string query;
        public string[] suggestions;
        public string[] data;
    }
}
