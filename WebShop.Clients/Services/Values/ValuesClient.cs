using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebShop.Clients.Base;
using WebShop.Interfaces.Api;

namespace WebShop.Clients.Services.Values
{
    public class ValuesClient : BaseClient, IValuesService
    {
        protected sealed override string ServiceAddress { get; set; }

        public ValuesClient(IConfiguration configuration) : base(configuration)
        {
            ServiceAddress = "api/values";
        }

        public IEnumerable<string> Get()
        {
            var list = new List<string>();
            var response = client.GetAsync($"{ServiceAddress}").Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<string>>().Result;
            }
            return list;
        }

        public async Task<IEnumerable<string>> GetAsync()
        {
            var list = new List<string>();
            var response = await client.GetAsync($"{ServiceAddress}");
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<string>>().Result;
            }
            return list;
        }

        public string Get(int id)
        {
            var result = string.Empty;
            var response = client.GetAsync($"{ServiceAddress}/get/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<string>().Result;
            }
            return result;
        }

        public async Task<string> GetAsync(int id)
        {
            var result = string.Empty;
            var response = await client.GetAsync($"{ServiceAddress}/get/{id}");
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<string>().Result;
            }
            return result;
        }

        public Uri Post(string value)
        {
            var response = client.PostAsJsonAsync($"{ServiceAddress}/post", value).Result;
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public async Task<Uri> PostAsync(string value)
        {
            var response = await client.PostAsJsonAsync($"{ServiceAddress}/post", value);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public HttpStatusCode Put(int id, string value)
        {
            var response = client.PostAsJsonAsync($"{ServiceAddress}/put/{id}", value).Result;
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> PutAsync(int id, string value)
        {
            var response = await client.PostAsJsonAsync($"{ServiceAddress}/put/{id}", value);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }

        public HttpStatusCode Delete(int id)
        {
            var response = client.DeleteAsync($"{ServiceAddress}/delete/{id}").Result;
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"{ServiceAddress}/delete/{id}");
            return response.StatusCode;
        }
    }
}
