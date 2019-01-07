using Newtonsoft.Json;
using projetoWhois.Models;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace projetoWhois.APIs.Whois
{
    public class WhoisClient : HttpClient
    {
        private readonly HttpClient _httpClient;

        public WhoisClient()
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri("https://jsonwhoisapi.com/api/v1/") };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["ApiWhoisKey"]);
        }

        public WhoisInfo BuscarInfo(string dominio)
        {
            var result = _httpClient.GetAsync($"whois?identifier={dominio}").Result;
            return JsonConvert.DeserializeObject<WhoisInfo>(result.Content.ReadAsStringAsync().Result);
        }
    }
}