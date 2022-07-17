using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_TopScorers
{
    public static class WC
    {
        public static string URL_SA = "https://app.sportdataapi.com/api/v1/soccer/topscorers?apikey=3983ad80-d775-11ec-b10a-b1449bbed000&season_id=2100";
        public static string URL_EPL = "https://app.sportdataapi.com/api/v1/soccer/topscorers?apikey=3983ad80-d775-11ec-b10a-b1449bbed000&season_id=1980";
        public static string URL_SA_19_20 = "https://app.sportdataapi.com/api/v1/soccer/topscorers?apikey=3983ad80-d775-11ec-b10a-b1449bbed000&season_id=619";
        public static string URL_EPL_19_20 = "https://app.sportdataapi.com/api/v1/soccer/topscorers?apikey=3983ad80-d775-11ec-b10a-b1449bbed000&season_id=352";


        //Коды для API
        public static int CURRENT_SEASON_SA = 2100;
        public static int SEASON_20_21_SA = 619;
        public static int CURRENT_SEASON_EPL = 1980;
        public static int SEASON_20_21_EPL = 352;
    }
}
