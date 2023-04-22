using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class Sport
    {
        public Sport()
        {
            Athletes = new HashSet<Athlete>();
            AthleteSports = new HashSet<AthleteSport>();
            Events = new HashSet<Event>();
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "You cannot leave the Code blank.")]
        [RegularExpression("^[A-Z]{3}$", ErrorMessage = "The Code must be exactly 3 capital letters.")]
        [StringLength(3)]
        public string Code { get; set; }

        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }

        [Display(Name = "Main Athletes")]
        public ICollection<Athlete> Athletes { get; set; }

        [Display(Name="Alternates")]
        public ICollection<AthleteSport> AthleteSports { get; set; }

    }
}
