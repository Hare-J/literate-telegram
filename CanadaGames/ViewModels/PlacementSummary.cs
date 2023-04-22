using CanadaGames.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.ViewModels
{
    public class PlacementSummary
    {
        public int ID { get; set; }

        [Display(Name = "Athlete")]
        public string FormalName
        {
            get
            {
                return LastName + ", " + FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? "" :
                        (" " + (char?)MiddleName[0] + ".").ToUpper());
            }
        }

        [Display(Name = "Athlete")]
        public string Name { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters long.")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters long.")]
        public string LastName { get; set; }

        [Display(Name = "Average")]
        public int AveragePlacement { get; set; }

        [Display(Name = "Highest")]
        public int HighestPlacement { get; set; }

        [Display(Name = "Lowest")]
        public int LowestPlacement { get; set; }

        [Display(Name = "Total Events")]
        public int TotalEvents { get; set; }

        [Display(Name = "Contingent")]
        public string ContingentCode { get; set; }

        [Display(Name = "ID")]
        public string AthleteCode { get; set; }
    }
}
