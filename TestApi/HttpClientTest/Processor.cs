using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.HttpClientTest
{
    public class Processor
    {
        public async Task<Root> Load()
        {
            string url = "https://app.sportdataapi.com/api/v1/soccer/topscorers?apikey=3983ad80-d775-11ec-b10a-b1449bbed000&season_id=2100";
            using(HttpResponseMessage response = await ApiHerlper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var root = JsonConvert.DeserializeObject<Root>(content);
                    return root;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
