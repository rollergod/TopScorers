using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MyProject_TopScorers;
using MyProject_TopScorers.Controllers;
using MyProject_TopScorers.Domain.Enums;
using MyProject_TopScorers.Domain.Models;
using MyProject_TopScorers.Domain.ViewModel;
using MyProject_TopScorers.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task ScorersEplReturnAViewResultWithListOfDatum()
        {
            //Arrange
            var loggerMoq = Mock.Of<ILogger<HomeController>>();
            var moqTopScorers = new Mock<ITopScorers>();
            moqTopScorers.Setup(repo => repo.GetTopScorers(WC.URL_EPL, Leagues.EPL, WC.CURRENT_SEASON_EPL)).ReturnsAsync(new List<Datum> { });
            var controller = new HomeController(loggerMoq, moqTopScorers.Object);

            // Act
            var result = await controller.ScorersEPL();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Datum>>(viewResult.Model);
            Assert.Equal(GetTestDatum().Count, model.Count);
            
        }

        [Fact]
        public async Task ScorersSeriaAReturnAViewResultWithOnePlayer()
        {
            string testName = "Ciro Immobile";
            // Arrange
            var loqqerMoq = Mock.Of<ILogger<HomeController>>();
            var moqTopScorers = new Mock<ITopScorers>();
            moqTopScorers.Setup(repo => repo.GetPlayerByName(testName, false))
                .ReturnsAsync(GetTestDatum().FirstOrDefault(player => player.player.player_name == testName));
            var controller = new HomeController(loqqerMoq, moqTopScorers.Object);

            // Act

            var result = await controller.GetPlayer(testName, Leagues.SeriaA);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<PlayerViewModel>(viewResult.Model);
            Assert.Equal("Ciro Immobile", model.infoPlayerSeason2122.player.player_name);

        }

        [Fact]
        public async Task ScorersEplViewResultNotNull()
        {
            var loqqerMor = Mock.Of<ILogger<HomeController>>();
            var moqTopScorers = Mock.Of<ITopScorers>();
            var controller = new HomeController(loqqerMor, moqTopScorers);

            ViewResult result = await controller.ScorersEPL() as ViewResult;

            Assert.NotNull(result);
        }


        private List<Datum> GetTestDatum()
        {
            var datum = new List<Datum>
            {
                new Datum{player = new Player{
                    player_name = "Ciro Immobile"} 
                }
            };
            return datum;
        }
    }
}
