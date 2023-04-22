using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class Athlete : Auditable, IValidatableObject
    {
        public Athlete()
        {
            AthleteSports = new HashSet<AthleteSport>();
            AthleteDocuments = new HashSet<AthleteDocument>();
            Placements = new HashSet<Placement>();
        }
        public int ID { get; set; }

        [Display(Name = "Athlete")]
        public string FullName
        {
            get
            {
                return FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? " " :
                        (" " + (char?)MiddleName[0] + ". ").ToUpper())
                    + LastName;
            }
        }
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
        [Display(Name = "ID Code")]
        public string ACode
        {
            get
            {
                return "A:" + AthleteCode.ToString().PadLeft(7,'0');
            }
        }
        public string Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int a = today.Year - DOB.Year
                    - ((today.Month < DOB.Month || (today.Month == DOB.Month && today.Day < DOB.Day) ? 1 : 0));
                return a.ToString(); /*Note: You could add .PadLeft(3) but spaces disappear in a web page. */
            }
        }

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

        [Display(Name = "Athlete Code")]
        [Required(ErrorMessage = "The 7 digit Code for the Athlete is required")]
        [RegularExpression("^\\d{7}$", ErrorMessage = "The Athlete Code must be exactly 7 numeric digits.")]
        [StringLength(7)]//DS Note: we only include this to limit the size of the database field to 10
        public string AthleteCode { get; set; }

        //[Required(ErrorMessage = "You cannot leave the Hometown blank.")]
        //[StringLength(100, ErrorMessage = "Hometown cannot be more than 100 characters long.")]
        //public string Hometown { get; set; }

        //[ValidateDOBRange] //I will leave it to IValidatableObject
        [Required(ErrorMessage = "You must enter the date of birth.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Display(Name = "Height (cm)")]
        [Required(ErrorMessage = "You cannot leave the Height blank.")]
        [Range(61,245,ErrorMessage ="Height must be between 61cm and 245cm.")]
        public int Height { get; set; }

        [Display(Name = "Weight (kg)")]
        [Required(ErrorMessage = "You cannot leave the Weight blank.")]
        [Range(18.0d, 180.0d, ErrorMessage = "Weight must be between 18kg and 180kg.")]
        public double Weight { get; set; }

        [Display(Name = "Years I have participated in my sport")]
        [Required(ErrorMessage = "You cannot leave the Years In Sport blank.")]
        public int YearsInSport { get; set; }

        [Display(Name = "Club or Team affiliation")]
        [Required(ErrorMessage = "You must enter the Club or Team Affiliation.")]
        [StringLength(255, ErrorMessage = "Affiliation cannot be more than 255 characters long.")]
        public string Affiliation { get; set; }

        [Display(Name = "My goals for the games")]
        [Required(ErrorMessage = "You must enter goals for the games.")]
        [StringLength(255, ErrorMessage = "Goal statement cannot be more than 255 characters long.")]
        [MinLength(10, ErrorMessage = "Goal statement must be at least 10 characters.")]
        public string Goals { get; set; }

        [Display(Name = "Other information that could be of interest to the media")]
        [Required(ErrorMessage = "You must enter information for the media.")]
        [StringLength(2000, ErrorMessage = "Media informaiton cannot be more than 2000 characters long.")]
        [DataType(DataType.MultilineText)]
        public string MediaInfo { get; set; }

        [Display(Name = "Contingent")]
        [Required(ErrorMessage = "You must select the Contingent")]
        public int ContingentID { get; set; }
        public Contingent Contingent { get; set; }

        [Display(Name = "Sport")]
        [Required(ErrorMessage = "You must select the Sport")]
        public int SportID { get; set; }
        public Sport Sport { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "You must select the Gender")]
        public int GenderID { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Coach")]
        public int? CoachID { get; set; }
        public Coach Coach { get; set; }

        [Display(Name = "Hometown")]
        public int? HometownID { get; set; }
        public Hometown Hometown { get; set; }

        [Display(Name = "Alternate Sports")]
        public ICollection<AthleteSport> AthleteSports { get; set; }

        [Display(Name = "Documents")]
        public ICollection<AthleteDocument> AthleteDocuments { get; set; }

        public AthletePhoto AthletePhoto { get; set; }
        public AthleteThumbnail AthleteThumbnail { get; set; }

        public ICollection<Placement> Placements { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Test date range for DOB
            if (DOB < Convert.ToDateTime("1992-08-22") || DOB >= Convert.ToDateTime("2010-08-07"))
            {
                yield return new ValidationResult("DOB must be between 1992-08-22 and 2010-08-06.", new[] { "DOB" });
            }
            //Test BMI Value
            double BMI = Weight / Math.Pow(Height / 100d,2);
            if(BMI<15 || BMI >=40)
            {
                yield return new ValidationResult("BMI of " + BMI.ToString("n1")
                    + " is outside the allowable range of 15 to 40", new[] { "Weight" });
            }
        }
    }
}
