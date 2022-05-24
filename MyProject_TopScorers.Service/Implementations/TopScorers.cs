using Microsoft.Extensions.Caching.Memory;
using MyProject_TopScorers.Domain.Enums;
using MyProject_TopScorers.Domain.Models;
using MyProject_TopScorers.Service.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject_TopScorers.Service.Implementations
{
    public class TopScorers : ITopScorers
    {
        CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
        private readonly IMemoryCache _cache;
        public TopScorers(IMemoryCache cache)
        {
            _cache = cache;
        }

        List<Datum> players;
        public List<Datum> Players { get; set; }
        public List<Datum> OldStatPlayers { get; set; }

        public async Task<Root> GetRoot(string url)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = await client.ExecuteAsync(request, CancellationTokenSource.Token);
            var content = response.Content;
            var root = JsonConvert.DeserializeObject<Root>(content);

            return root;
        }
        public async Task<List<Datum>> GetTopScorers(string url,Leagues footballLeague,int season_id)
        {
            
            if (!_cache.TryGetValue(season_id, out players)) // season_id - key
            {
                var root = await GetRoot(url);
                switch (footballLeague)
                {
                    case Leagues.EPL: // English Premier League
                        switch (season_id)
                        {
                            case 352:
                                OldStatPlayers = root.data;
                                _cache.Set(season_id, Players, new MemoryCacheEntryOptions
                                {
                                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                                });
                                break;
                            case 1980:
                                Players = await GetPicturesEPLPlayers(root.data);
                                _cache.Set(season_id, Players, new MemoryCacheEntryOptions
                                {
                                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                                });
                                break;
                        }
                        break;
                    case Leagues.SeriaA: // Seria A
                        switch (season_id)
                        {
                            case 619:
                                OldStatPlayers = root.data;
                                _cache.Set(season_id, Players, new MemoryCacheEntryOptions
                                {
                                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                                });
                                break;
                            case 2100:
                                Players = await GetPicturesSeriaAPlayers(root.data);
                                _cache.Set(season_id, Players, new MemoryCacheEntryOptions
                                {
                                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                                });
                                break;
                        }
                        break;
                    default:
                        break;
                }
                return Players;
            }
           
            return players;
        }

        public async Task<List<Datum>> GetPicturesSeriaAPlayers(List<Datum> root)
        {
            for (int i = 0; i < 20; i++)
            {
                string playerName = root[i].player.player_name;
                switch (playerName)
                {
                    case "Ciro Immobile":
                        root[i].player.CrestUrl = new System.Uri("https://s5o.ru/storage/simple/ru/edt/5e/b1/88/73/rue1fec74a657.jpg");
                        break;
                    case "Dusan Vlahovic":
                        root[i].player.CrestUrl = new System.Uri("https://cdn.vox-cdn.com/thumbor/Gs_LbuiUV5aQuXXeTztMwAJqCVk=/0x0:3000x1998/1200x800/filters:focal(1021x147:1501x627)/cdn.vox-cdn.com/uploads/chorus_image/image/69183282/1232519539.0.jpg");
                        break;
                    case "Giovanni Pablo Simeone":
                        root[i].player.CrestUrl = new System.Uri("https://telegra.ph/file/6306209aa1f0e2b9a534c.jpg");
                        break;
                    case "Kevin Oghenetega Tamaraebi Bakumo-Abraham":
                        root[i].player.CrestUrl = new System.Uri("https://s5o.ru/storage/simple/ru/edt/41/79/86/dd/rue2e55c300a8.jpg");
                        break;
                    case "Lautaro Javier Martinez":
                        root[i].player.CrestUrl = new System.Uri("https://cdn.vox-cdn.com/thumbor/PpIDJeFKdPaLvP1qa5hUIT_2JL4=/0x0:3005x2000/1200x800/filters:focal(1263x760:1743x1240)/cdn.vox-cdn.com/uploads/chorus_image/image/65673488/1181294649.jpg.5.jpg");
                        break;
                    case "Domenico Berardi":
                        root[i].player.CrestUrl = new System.Uri("https://tothelaneandback.com/wp-content/uploads/2021/10/Domenico-Berardi-2.jpg");
                        break;
                    case "Edin Dzeko":
                        root[i].player.CrestUrl = new System.Uri("https://s5o.ru/storage/simple/ru/ugc/0c/97/a5/f3/ruu9f74ff4377.jpg");
                        break;
                    case "Marko Arnautovic":
                        root[i].player.CrestUrl = new System.Uri("https://cdn.tribuna.com/fetch/?url=https%3A%2F%2Fmanutd.one%2Fuploads%2Fposts%2F2018-05%2F1527770364_skysports-marko-arnautovic_4269764.jpg");
                        break;
                    case "Gianluca Scamacca":
                        root[i].player.CrestUrl = new System.Uri("https://oxy.sports.ru/fetch/?url=https%3A%2F%2Fprd-images2-gazzanet.gazzettaobjects.it%2FzrlNdQM5foVgX-TRo24_OOQRdZ8%3D%2F712x402%2Fsmart%2Ffilters%3Aformat%28webp%29%2Fwww.forzaroma.info%2Fassets%2Fuploads%2F202109%2F6134b400bb91f0ff918a7da940161366.jpg");
                        break;
                    case "Gerard Deulofeu Lazaro":
                        root[i].player.CrestUrl = new System.Uri("https://i.trbna.com/preset/wysiwyg/f/f0/96652058811eb96a3c9945a5493a4.jpeg");
                        break;
                    case "Joao Pedro Geraldino Dos Santos Galvao":
                        root[i].player.CrestUrl = new System.Uri("https://juvepoland.com/wp-content/uploads/2019/12/jao-pedro.jpg");
                        break;
                    case "Victor James Osimhen":
                        root[i].player.CrestUrl = new System.Uri("https://odds.ru/upload/media/default/0001/24/a862981014cb6c5714fb44a23b0bab986efaa262.jpeg");
                        break;
                    case "Andrea Pinamonti":
                        root[i].player.CrestUrl = new System.Uri("https://cdn.tribuna.com/fetch/?url=https%3A%2F%2Fstatic1.squarespace.com%2Fstatic%2F593614a03e00beb2f0d520ad%2F5936401cb3db2b83532d06b1%2F5cf6c92c1e1e6800012d0f8e%2F1559677692893%2Fpinamonti-segna-ed-esulta-come-icardi.jpg%3Fformat%3D1000w");
                        break;
                    case "Francesco Caputo":
                        root[i].player.CrestUrl = new System.Uri("https://cdn.tribuna.com/fetch/?url=https%3A%2F%2Fstorage.googleapis.com%2Ftelesite-prod%2Fphotos%2F06484ba0-674f-11ea-aab1-7bc436a38979.jpeg");
                        break;
                    case "Gianluca Caprari":
                        root[i].player.CrestUrl = new System.Uri("https://gianlucadimarzio.com/images/caprari_image.jpg?p=intextimg&s=1ffe8d165b7e004ee223b33dc4cd8705");
                        break;
                    case "Mario Pasalic":
                        root[i].player.CrestUrl = new System.Uri("https://cdn.tribuna.com/fetch/?url=https%3A%2F%2Fi.sprts.ru%2Fpreset%2Fwysiwyg%2F2%2F86%2Fa48e4454411ecbaf3d319ce6e28e6.jpeg");
                        break;
                    case " Beto":
                        root[i].player.CrestUrl = new System.Uri("https://oxy.sports.ru/fetch/?url=https%3A%2F%2Fwww.calciomercatonews.com%2Fwp-content%2Fuploads%2F2021%2F12%2F14114758_medium.jpg");
                        break;
                    case "Duvan Esteban Zapata  Banguero":
                        root[i].player.CrestUrl = new System.Uri("https://i.trbna.com/preset/wysiwyg/e/66/660faa02011ea8816a41adbf14c8c.jpeg");
                        break;
                    case "Lorenzo Insigne":
                        root[i].player.CrestUrl = new System.Uri("https://s-cdn.sportbox.ru/images/styles/upload/fp_fotos/49/5e/f4481ad13afa843dcf43a168a6e10dfd5e18f11e8f113465136670.jpg");
                        break;
                    case "Antonin Barak":
                        root[i].player.CrestUrl = new System.Uri("https://icdn.sempremilan.com/wp-content/uploads/2021/03/1001017725.jpg");
                        break;
                    default:
                        break;
                }
            }

                return root;
        }

        public async Task<List<Datum>> GetPicturesEPLPlayers(List<Datum> root)
        {
            for (int i = 0; i < 20; i++)
            {
                string playerName = root[i].player.player_name;
                switch (playerName)
                {
                    case "Mohamed Salah Hamed Mahrous Ghaly":
                        root[i].player.CrestUrl = new System.Uri("https://oxy.sports.ru/fetch/?url=https%3A%2F%2Fisport.ua%2Fi%2F62%2F99%2F78%2F4%2F6299784%2Fimage_main%2Fc602d28bc788dc440266f7ecd7bbacba-quality_70Xresize_1Xallow_enlarge_0Xw_835Xh_0.jpg");
                        break;
                    case "Cristiano Ronaldo Dos Santos Aveiro":
                        root[i].player.CrestUrl = new System.Uri("https://interesnyefakty.org/wp-content/uploads/Foto-Ronaldu-26.jpg");
                        break;
                    case "Heung-min Son":
                        root[i].player.CrestUrl = new System.Uri("https://media-manager.noticiasaominuto.com/1280/naom_5b51e92bb8360.jpg");
                        break;
                    case "Diogo Jose Teixeira da Silva":
                        root[i].player.CrestUrl = new System.Uri("https://s5o.ru/storage/simple/ru/edt/34/4c/e3/a3/rue8dfb31dbce.jpg");
                        break;
                    case "Sadio Mane":
                        root[i].player.CrestUrl = new System.Uri("https://www.otbfootball.net/wp-content/uploads/2019/09/3682E233-82D5-40D2-BF36-7596B71C2242.jpeg");
                        break;
                    case "Harry Edward Kane":
                        root[i].player.CrestUrl = new System.Uri("https://s5o.ru/storage/simple/ru/ugc/ca/67/a7/72/ruu9a93afc620.jpg");
                        break;
                    case "Ivan Toney":
                        root[i].player.CrestUrl = new System.Uri("https://e00-marca.uecdn.es/assets/multimedia/imagenes/2021/05/31/16224749408630.jpg");
                        break;
                    case "Kevin De Bruyne":
                        root[i].player.CrestUrl = new System.Uri("https://e0.365dm.com/20/07/1600x900/skysports-kevin-de-bruyne-manchester-city_5028684.jpg?20200702214909");
                        break;
                    case "Dazet Wilfried Armel Zaha":
                        root[i].player.CrestUrl = new System.Uri("https://e0.365dm.com/20/01/2048x1152/skysports-wilfried-zaha-crystal-palace_4884846.jpg?20200106221959");
                        break;
                    case "Riyad Karim Mahrez":
                        root[i].player.CrestUrl = new System.Uri("https://i.eurosport.com/2018/12/05/2476253-51423775-2560-1440.jpg");
                        break;
                    case "Bukayo Saka":
                        root[i].player.CrestUrl = new System.Uri("https://e0.365dm.com/19/07/2048x1152/skysports-bukayo-saka-arsenal_4724264.jpg?20190721090525");
                        break;
                    case "Teemu Eino Antero Pukki":
                        root[i].player.CrestUrl = new System.Uri("https://sport.periodicodaily.com/wp-content/uploads/2020/03/teemu-pukki-derby.jpg");
                        break;
                    case "Raheem Shaquille Sterling":
                        root[i].player.CrestUrl = new System.Uri("https://i.trbna.com/preset/wysiwyg/2/4a/625987bfb11eab7889e175565554e.jpeg");
                        break;
                    case "Jamie Richard Vardy":
                        root[i].player.CrestUrl = new System.Uri("https://cdn.readeverything.co/wp-content/uploads/sites/16/2020/04/1211442483-1.jpg");
                        break;
                    case "Mason Tony Mount":
                        root[i].player.CrestUrl = new System.Uri("https://media.vivagoal.com/2019/09/Mason-Mount-Chelsea.jpg");
                        break;
                    case "Emile Smith-Rowe":
                        root[i].player.CrestUrl = new System.Uri("https://cdn.thisisfutbol.com/wp-content/uploads/2020/12/smith-rowe.jpg");
                        break;
                    case "Raphael Dias Belloli":
                        root[i].player.CrestUrl = new System.Uri("https://fplconnect.files.wordpress.com/2021/05/gettyimages-1288302137.jpg");
                        break;
                    case "Emmanuel Dennis Bonaventure":
                        root[i].player.CrestUrl = new System.Uri("https://davaysport.ru/wa-data/public/blog/img/dennis-bonaventure.jpg");
                        break;
                    case "James Ward-Prowse":
                        root[i].player.CrestUrl = new System.Uri("https://cdn.theathletic.com/app/uploads/2020/01/22053103/Ward-Prowse-Southampton-1024x683.jpg");
                        break;
                    case "Bruno Miguel Borges Fernandes":
                        root[i].player.CrestUrl = new System.Uri("https://www.the-sun.com/wp-content/uploads/sites/6/2021/06/crop-15413039.jpg?strip=all&amp;quality=100&amp;w=1200&amp;h=800&amp;crop=1");
                        break;
                    default:
                        break;
                }
            }

            return root;
        }

        public async Task<Datum> GetPlayerByName(string playerName,bool getOldStat = false)
        {
            Datum currentPlayer;
            if (getOldStat)
                currentPlayer = OldStatPlayers.FirstOrDefault(data => data.player.player_name == playerName);
            else
                currentPlayer = Players.FirstOrDefault(data => data.player.player_name == playerName);
            return currentPlayer;
        }

        //public async Task<Datum> GetPlayerById(int id)
        //{
        //    var currentPlayer = SeriaAPLayers.FirstOrDefault(data => data.player.player_id == id);

        //    if (currentPlayer is null)
        //        SeriaAPLayers.FirstOrDefault(data => data.player.player_id == id);

        //    return currentPlayer;
        //}
    }
}
