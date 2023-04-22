using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class Gender
    {
        public Gender()
        {
            Athletes = new HashSet<Athlete>();
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "You cannot leave the Code blank.")]
        [RegularExpression("^[M,W]$", ErrorMessage = "The Code must be either M or W.")]
        [StringLength(1)]
        public string Code { get; set; }

        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        public ICollection<Athlete> Athletes { get; set; }
    }
}
