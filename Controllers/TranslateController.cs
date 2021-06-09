using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranslationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslatorController : ControllerBase
    {

        private readonly ILogger<TranslatorController> _logger;

        public TranslatorController(ILogger<TranslatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Translate(string text)
        {
            var client = new RestClient("https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&from=en&to=fil");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", "4ecfc9c224fa41b8918351d8f7a73963");
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");
            request.AddHeader("Ocp-Apim-Subscription-Region", "southeastasia");



            var json = JsonConvert.SerializeObject(new List<TranslatePart>()
                {
                    new TranslatePart{ Text = text}
                });

            request.AddParameter("application/json; charset=UTF-8", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var value =  JsonConvert.DeserializeObject<List<TranslationResult>>(response.Content);
            return value.FirstOrDefault()?.Translations.FirstOrDefault()?.Text;
        }
    }
}
