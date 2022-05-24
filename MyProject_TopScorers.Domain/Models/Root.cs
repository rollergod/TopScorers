using System;
using System.Collections.Generic;

namespace MyProject_TopScorers.Domain.Models
{
    public class Root
    {
        public Query query { get; set; }
        public List<Datum> data { get; set; }
    }
    public class Query
    {
        public string apikey { get; set; }
        public string season_id { get; set; }
    }
    public class Datum
    {
        public int pos { get; set; }
        public Player player { get; set; }
        public Team team { get; set; }
        public int league_id { get; set; }
        public int season_id { get; set; }
        public int matches_played { get; set; }
        public int minutes_played { get; set; }
        public int? substituted_in { get; set; }
        public Goals goals { get; set; }
        public int? penalties { get; set; }
    }

    public class Goals
    {
        public int overall { get; set; }
        public int home { get; set; }
        public int away { get; set; }
    }

    public class Player
    {
        public int? player_id { get; set; }
        public string player_name { get; set; }
        public Uri? CrestUrl { get; set; }
    }



    public class Team
    {
        public int team_id { get; set; }
        public string team_name { get; set; }
    }
}
