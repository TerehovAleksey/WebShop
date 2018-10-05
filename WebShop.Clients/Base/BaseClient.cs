using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebShop.Clients.Base
{
    public abstract class BaseClient
    {
        protected HttpClient client;

        protected abstract string ServiceAddress { get; set; }

        protected BaseClient(IConfiguration confuguration)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(confuguration["ClientAddress"])
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
