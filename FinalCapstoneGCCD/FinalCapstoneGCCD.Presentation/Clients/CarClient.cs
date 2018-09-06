using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FinalCapstoneGCCD.Domain.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FinalCapstoneGCCD.Presentation.Clients
{
    public class CarClient
    {
        private readonly IRestClient _client;
        public CarClient()
        {
            _client = new RestClient(ConfigurationManager.AppSettings["CarApiBaseUrl"]);
        }
        public async Task<ICollection<Car>> GetCar(string make, string model, int? year, string color)
        {
            var request = new RestRequest("api/Cars", Method.GET);
            if (!string.IsNullOrWhiteSpace(make))
            {
                request.Parameters.Add(new Parameter()
                {
                    Name = "make",
                    Type = ParameterType.QueryString,
                    Value = make
                });
            }
            if (!string.IsNullOrWhiteSpace(model))
            {
                request.Parameters.Add(new Parameter()
                {
                    Name = "model",
                    Type = ParameterType.QueryString,
                    Value = model
                });
            }
            if (year.HasValue)
            {
                request.Parameters.Add(new Parameter()
                {
                    Name = "year",
                    Type = ParameterType.QueryString,
                    Value = year
                });
            }
            if (!string.IsNullOrWhiteSpace(color))
            {
                request.Parameters.Add(new Parameter()
                {
                    Name = "color",
                    Type = ParameterType.QueryString,
                    Value = color
                });
            }

            var response = await _client.ExecuteTaskAsync(request);
            return JsonConvert.DeserializeObject<List<Car>>(response.Content);
        }
    }
}