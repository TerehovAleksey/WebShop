using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebShop.Clients.Base
{
    /// <summary>
    /// Базовый клиент
    /// </summary>
    public abstract class BaseClient
    {
        /// <summary>
        /// HTTP-клиент
        /// </summary>
        protected HttpClient client;

        /// <summary>
        /// адрес сервиса
        /// </summary>
        protected abstract string ServiceAddress { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="confuguration">конфигурация приложения</param>
        protected BaseClient(IConfiguration confuguration)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(confuguration["ClientAddress"])
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected T Get<T>(string url) where T : new()
        {
            var result = new T();
            var responce = client.GetAsync(url).Result;
            if (responce.IsSuccessStatusCode)
            {
                result = responce.Content.ReadAsAsync<T>().Result;
            }
            return result;
        }

        protected async Task<T> GetAsync<T>(string url) where T : new()
        {
            var result = new T();
            var responce = await client.GetAsync(url);
            if (responce.IsSuccessStatusCode)
            {
                result = await responce.Content.ReadAsAsync<T>();
            }
            return result;
        }

        protected HttpResponseMessage Post<T>(string url, T value)
        {
            var responce = client.PostAsJsonAsync(url, value).Result;
            responce.EnsureSuccessStatusCode();
            return responce;
        }

        protected async Task<HttpResponseMessage> PostAsync<T>(string url, T value)
        {
            var responce = await client.PostAsJsonAsync(url, value);
            responce.EnsureSuccessStatusCode();
            return responce;
        }

        protected HttpResponseMessage Put<T>(string url, T value)
        {
            var responce = client.PutAsJsonAsync(url, value).Result;
            responce.EnsureSuccessStatusCode();
            return responce;
        }

        protected async Task<HttpResponseMessage> PutAsync<T>(string url, T value)
        {
            var responce = await client.PutAsJsonAsync(url, value);
            responce.EnsureSuccessStatusCode();
            return responce;
        }

        protected HttpResponseMessage Delete(string url)
        {
            var responce = client.DeleteAsync(url).Result;
            return responce;
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            var responce = await client.DeleteAsync(url);
            return responce;
        }
    }
}
