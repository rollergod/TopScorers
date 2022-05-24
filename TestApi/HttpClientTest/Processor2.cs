using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.HttpClientTest
{
    public class Processor2
    {
        public async Task<Root> Load()
        {
            Root root = new Root();
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://app.sportdataapi.com/api/v1/soccer/topscorers?apikey=3983ad80-d775-11ec-b10a-b1449bbed000&season_id=2100");
                var result = client.GetAsync(endpoint).Result;

                var json = await result.Content.ReadAsStringAsync();
                root = JsonConvert.DeserializeObject<Root>(json);
                
            }
            return root;
        }
    }
}
