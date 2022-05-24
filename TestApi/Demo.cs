using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApi
{
    public class Demo
    {
        public async Task<Root> GetInfo()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var client = new RestClient("https://app.sportdataapi.com/api/v1/soccer/topscorers?apikey=3983ad80-d775-11ec-b10a-b1449bbed000&season_id=2100");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = await  client.ExecuteAsync(request,cancellationTokenSource.Token);
            var content = response.Content;
            var root = JsonConvert.DeserializeObject<Root>(content);
            return root;
        }

    }
}
