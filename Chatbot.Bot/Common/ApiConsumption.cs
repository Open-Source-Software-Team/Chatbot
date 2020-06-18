using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

                var vObjResponse = JsonConvert.DeserializeObject(response.Content);
                return vObjResponse.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ApiWorkCertificate(string pApi, string pData)
        {
            try
            {
                var client = new RestClient("http://localhost:4969");
                var request = new RestRequest("api/Ophelia_Kactus_Certificado", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                var vd = JsonConvert.SerializeObject(pData);
                request.AddParameter("application/json", vd, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                var vObjResponse = JsonConvert.DeserializeObject(response.Content);

                return vObjResponse.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String ApiWorkCertificateByte(string pApi, string pData)
        {
            try
            {
                Document vDoc = new Document();
                var client = new RestClient("http://localhost:4969");
                var request = new RestRequest("api/Ophelia_Kactus_Certificado", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                var vd = JsonConvert.SerializeObject(pData);
                request.AddParameter("application/json", vd, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                vDoc = JsonConvert.DeserializeObject<Document>(response.Content);
                //var vObjResponse = JsonConvert.DeserializeObject(response.Content.Replace("\"",""));

                return Convert.ToBase64String(vDoc.BytesFileObject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public class Document
        {
            public byte[] BytesFileObject { get; set; }
        }
    }
}
