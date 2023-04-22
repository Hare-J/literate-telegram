using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class Contingent
    {
        public Contingent()
        {
            Athletes = new HashSet<Athlete>();
            Hometowns = new HashSet<Hometown>();
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "You cannot leave the Code blank.")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "The Code must be exactly 2 capital letters.")]
        [StringLength(2)]
        public string Code { get; set; }

        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        public ICollection<Athlete> Athletes { get; set; }
        public ICollection<Hometown> Hometowns { get; set; }
    }
}
