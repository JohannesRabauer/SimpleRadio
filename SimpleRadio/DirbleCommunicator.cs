using Newtonsoft.Json;
using SimpleRadio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRadio
{
    class DirbleCommunicator : IDisposable
    {
        private HttpClient _client;
        private const String TOKEN_STRING = "?token=72f7b8b9b12326b85fd3943157";
        public DirbleCommunicator()
        {
            this._client = new HttpClient();
            this._client.BaseAddress = new Uri("http://api.dirble.com/v2/");
            this._client.DefaultRequestHeaders.Accept.Clear();
            this._client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            this._client.Timeout = new TimeSpan(0, 0, 5);
        }

        public IEnumerable<Station> getStations()
        {
            HttpResponseMessage response = this._client.GetAsync("stations" + TOKEN_STRING).Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<Station>>().Result;
            return null;
        }

        public IEnumerable<Station> searchStations(String stationToSearch)
        {
            String queryString = Newtonsoft.Json.JsonConvert.SerializeObject(new Dictionary<String, String> { { "query", stationToSearch } });
            HttpContent content = new StringContent(queryString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = this._client.PostAsync("search" + TOKEN_STRING, content).Result;
            if (response.IsSuccessStatusCode)
                try
                {
                    return response.Content.ReadAsAsync<IEnumerable<Station>>().Result;
                }
                catch (Exception)
                {
                }
            return null;
        }

        public void Dispose()
        {
            if (this._client != null)
            {
                this._client.Dispose();
            }
        }
    }
}
