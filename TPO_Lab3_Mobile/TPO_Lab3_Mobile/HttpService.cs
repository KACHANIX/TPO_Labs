using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TPO_Lab3_Mobile
{
    public static class HttpService
    {
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<TResult> Post<TResult, TInput>(TInput input, string link)
        {
            var json = JsonConvert.SerializeObject(input);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync(link, httpContent);
            return JsonConvert.DeserializeObject<TResult>(httpResponse.Content.ReadAsStringAsync().Result);
        }
        public static TResult Get<TResult>(string link)
        {
            var httpResponse = Client.GetAsync(link).Result;
            return JsonConvert.DeserializeObject<TResult>(httpResponse.Content.ReadAsStringAsync().Result);
        }
    }
}
