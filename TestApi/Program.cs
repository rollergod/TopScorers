using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace TestApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Demo demo = new Demo();
            var test = await demo.GetInfo();

            Console.WriteLine(test.query.apikey);
            
            
        }
    }
}
