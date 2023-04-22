using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class Event
    {
        public Event()
        {
            Placements = new HashSet<Placement>();
        }

        [Display(Name = "Event")]
        public string Summary
        {
            get
            {
                return Gender?.Name + "'s " + Type + " " + Name;
            }
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You cannot leave the event type blank.")]
        [StringLength(10, ErrorMessage = "Event type cannot be more than 10 characters long.")]
        public string Type { get; set; }

        [Display(Name = "Sport")]
        [Required(ErrorMessage = "You must select the Sport")]
        public int SportID { get; set; }
        public Sport Sport { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "You must select the Gender")]
        public int GenderID { get; set; }
        public Gender Gender { get; set; }

        public ICollection<Placement> Placements { get; set; }
    }
}
