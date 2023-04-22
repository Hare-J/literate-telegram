using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class AthleteSport
    {
        public int AthleteID { get; set; }
        public Athlete Athlete { get; set; }

        public int SportID { get; set; }
        public Sport Sport { get; set; }
    }
}
