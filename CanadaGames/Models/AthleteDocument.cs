using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class AthleteDocument : UploadedFile
    {
        [Display(Name = "Athlete")]
        public int AthleteID { get; set; }

        public Athlete Athlete { get; set; }
    }
}
