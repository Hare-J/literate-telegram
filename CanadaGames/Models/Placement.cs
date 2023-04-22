using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class Placement : Auditable
    {
        public int ID { get; set; }

        [Display(Name = "Place")]
        public string PlacementOrdinal
        {
            get
            {
                return Place switch
                {
                    1 => Place.ToString() + "st",
                    2 => Place.ToString() + "nd",
                    3 => Place.ToString() + "rd",
                    _ => Place.ToString() + "th",
                };
            }
        }

        [Required(ErrorMessage = "You cannot leave the placement blank.")]
        [Range(1, 100, ErrorMessage = "Place must be bwtween 1 and 100.")]
        public int Place { get; set; }

        [StringLength(2000, ErrorMessage = "Comments cannot be more than 2000 characters long.")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        [Display(Name = "Event")]
        [Required(ErrorMessage = "You must select the Event")]
        public int EventID { get; set; }
        public Event Event { get; set; }

        [Display(Name = "Athlete")]
        [Required(ErrorMessage = "You must select the Athlete")]
        public int AthleteID { get; set; }
        public Athlete Athlete { get; set; }
    }
}
