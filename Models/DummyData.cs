using SQLiteWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteWeb.Models
{
    public class DummyData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            if(!db.Standings.Any())
            {
                db.Standings.Add(new Standings
                {
                    StandingsId = 1,
                    Rank = 1,
                    Country = "Norway",
                    Gold = 14,
                    Silver = 14,
                    Bronze = 11,
                    Total = 39
                });
                db.Standings.Add(new Standings
                {
                    StandingsId = 2,
                    Rank = 2,
                    Country = "Germany",
                    Gold = 14,
                    Silver = 10,
                    Bronze = 7,
                    Total = 31
                });
                db.Standings.Add(new Standings
                {
                    StandingsId = 3,
                    Rank = 3,
                    Country = "Canada",
                    Gold = 11,
                    Silver = 8,
                    Bronze = 10,
                    Total = 29
                });
                db.Standings.Add(new Standings
                {
                    StandingsId = 4,
                    Rank = 4,
                    Country = "United States",
                    Gold = 9,
                    Silver = 8,
                    Bronze = 6,
                    Total = 23
                });
                db.Standings.Add(new Standings
                {
                    StandingsId = 5,
                    Rank = 5,
                    Country = "Netherlands",
                    Gold = 8,
                    Silver = 6,
                    Bronze = 6,
                    Total = 20
                });
                db.SaveChanges();
            }
        }
    }
}
