using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using U02B40_HFT_2021221.Models;

namespace U02B40_HFT_2021221.Client
{
    public class HttpServices
    {
        string controllerName;

        Uri baseAddress;

        JsonSerializerOptions serializerOptions;

        public HttpServices(string controllerName, string baseAddress)
        {
            this.controllerName = controllerName;
            this.baseAddress = new Uri(baseAddress);
            serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        }

        public List<T> GetAllCustom<T>(string actionName)
        {
            using (var client = new HttpClient())
            {
                InitClient(client);

                var response = client.GetAsync(GetActionName(actionName)).GetAwaiter().GetResult(); // Block here
                return JsonSerializer.Deserialize<List<T>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
        }

        public List<T> GetDecimalTreshold<T>(decimal amount)
        {
            using (var client = new HttpClient())
            {
                InitClient(client);

                var response = client.GetAsync(GetActionName("GetOverThreshold")).GetAwaiter().GetResult(); // Block here
                return JsonSerializer.Deserialize<List<T>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
        }

        public List<T> GetSumInPeriod<T>(DateTime periodbegin, DateTime periodend)
        {
            using (var client = new HttpClient())
            {
                InitClient(client);

                var response = client.GetAsync(GetActionName("GetSumInPeriod")).GetAwaiter().GetResult(); // Block here
                return JsonSerializer.Deserialize<List<T>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
        }


        public List<T> GetAll<T>(string actionName = null)
        {
            using (var client = new HttpClient())
            {
                InitClient(client);

                var response = client.GetAsync(GetActionName(actionName ?? nameof(GetAll))).GetAwaiter().GetResult(); // Block here
                return JsonSerializer.Deserialize<List<T>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
        }

        public T Get<T, TKey>(TKey id, string actionName = null)
        {
            using (var client = new HttpClient())
            {
                InitClient(client);

                var response = client.GetAsync($"{GetActionName(actionName ?? nameof(Get))}/{id}").GetAwaiter().GetResult(); // Block here
                return JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
        }

        public ApiResult Create<T>(T entity, string actionName = null)
        {
            using (var client = new HttpClient())
            {
                InitClient(client);

                var response = client.PostAsJsonAsync(GetActionName(actionName ?? nameof(Create)), entity).GetAwaiter().GetResult(); // Block here
                return JsonSerializer.Deserialize<ApiResult>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
        }

        public ApiResult Update<T>(T entity, string actionName = null)
        {
            using (var client = new HttpClient())
            {
                InitClient(client);

                var response = client.PutAsJsonAsync(GetActionName(actionName ?? nameof(Update)), entity).GetAwaiter().GetResult(); // Block here
                return JsonSerializer.Deserialize<ApiResult>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
        }

        public ApiResult Delete<TKey>(TKey id, string actionName = null)
        {
            using (var client = new HttpClient())
            {
                InitClient(client);

                var response = client.DeleteAsync($"{GetActionName(actionName ?? nameof(Delete))}/{id}").GetAwaiter().GetResult(); // Block here
                return JsonSerializer.Deserialize<ApiResult>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
        }

        public string GetActionName(string actionName) => $"{controllerName}/{actionName}";

         void InitClient(HttpClient client)
        {
            client.BaseAddress = baseAddress;
        }
    }
}
