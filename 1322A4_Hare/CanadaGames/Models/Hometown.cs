using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class Hometown
    {
        public Hometown()
        {
            Athletes = new HashSet<Athlete>();
        }

        public int ID { get; set; }

        [Display(Name = "Hometown")]
        [DisplayFormat(NullDisplayText = "No Hometown Specified")]
        public string HometownContingent
        {
            get
            {
                return Name + ", " + Contingent?.Code;
            }
        }

        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(100, ErrorMessage = "Name cannot be more than 100 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Contingent")]
        [Required(ErrorMessage = "You must select the Contingent")]
        public int ContingentID { get; set; }

        public Contingent Contingent { get; set; }

        public ICollection<Athlete> Athletes { get; set; }
    }
}
