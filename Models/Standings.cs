using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteWeb.Models
{
    public class Standings
    {
        public int StandingsId { get; set; }
        public int Rank { get; set; }
        public string Country { get; set; }
        public int Gold { get; set; }
        public int Silver{ get; set; }
        public int Bronze { get; set; }
        public int Total { get; set; }
    }
}
