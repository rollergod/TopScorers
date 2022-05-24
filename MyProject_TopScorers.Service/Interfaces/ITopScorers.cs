using MyProject_TopScorers.Domain.Enums;
using MyProject_TopScorers.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject_TopScorers.Service.Interfaces
{
    public interface ITopScorers
    {
        List<Datum> Players { get; set; }
        Task<List<Datum>> GetTopScorers(string url, Leagues footballLeague, int season_id);
        Task<List<Datum>> GetPicturesSeriaAPlayers(List<Datum> root);
        Task<List<Datum>> GetPicturesEPLPlayers(List<Datum> root);
        Task<Datum> GetPlayerByName(string playerName,bool getOldStat = false);
        //Task<Datum> GetPlayerById(int id);
    }
}
