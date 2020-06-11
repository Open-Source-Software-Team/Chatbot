using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Chatbot.Bot.Common
{
    public class ApiConsumption
    {
        public ApiConsumption()
        {

        }

        public string ApiFactory(string pApi, string pData)
        {
            try
            {
                var client = new RestClient("http://localhost:4969");
                var request = new RestRequest("api/Ophelia_Kactus_Cuentas", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                var vd = JsonConvert.SerializeObject(pData);
                request.AddParameter("application/json", vd, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                //var vObjResponse = JsonConvert.DeserializeObject(response.Content);
                return response.Content;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
