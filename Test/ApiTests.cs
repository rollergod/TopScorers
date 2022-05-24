using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject_TopScorers.Service.Implementations;
using System.Threading.Tasks;
using TestApi;
using TestApi.HttpClientTest;

namespace Test
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async Task Test_HttpClient()
        {
            ApiHerlper.InitializeClient();
            Processor processor = new Processor();

            var test = await processor.Load();

            Assert.AreEqual("Ciro Immobile", test.data[0].player.player_name);
            //Assert.AreEqual(258, test.data.Count);
        }

        [TestMethod]
        public async Task Test_RestClient()
        {
            Demo demo = new Demo();
            var test = await demo.GetInfo();

            Assert.AreEqual("Ciro Immobile", test.data[0].player.player_name);
            //Assert.AreEqual(258, test.data.Count);
        }

        [TestMethod]
        public async Task Test_HttpClient2()
        {
            Processor2 processor = new Processor2();

            var test = await processor.Load();

            Assert.AreEqual("Ciro Immobile", test.data[0].player.player_name);
            //Assert.AreEqual(258, test.data.Count);
        }

        //[TestMethod]
        //public async Task Test_RestClient_GetPicuter()
        //{
        //    TopScorers top = new TopScorers();

        //    var test = await top.GetTopScorersSeriaA();
        //    var result = await top.GetPictures(test); 


        //    Assert.AreEqual("https://s5o.ru/storage/simple/ru/edt/5e/b1/88/73/rue1fec74a657.jpg", result[0].team.CrestUrl.ToString());
        //    //Assert.AreEqual(258, test.data.Count);
        //}

        //[TestMethod]
        //public async Task Test_HttpClient_GetPicuter()
        //{
        //    TopScorers top = new TopScorers();

        //    var test = await top.Load();
        //    var result = await top.GetPictures(test);


        //    Assert.AreEqual("https://s5o.ru/storage/simple/ru/edt/5e/b1/88/73/rue1fec74a657.jpg", result[0].team.CrestUrl.ToString());
             //Assert.AreEqual(258, test.data.Count);
        //}

    }
}
