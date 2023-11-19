

/*
* John Moreau
* CSS233
* 11/19/2023
*
*
*/

using System.ComponentModel.DataAnnotations;

namespace CSS233_TripLogApp_JohnMoreau.Models
{
    public class Trip
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Destination")]
        public string Destination { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an Accommodation")]
        public string Accommodation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Start Date")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999", ErrorMessage = "Date must be after 1/1/1900")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a End Date")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999", ErrorMessage = "Date must be after 1/1/1900")]
        public DateTime EndDate { get; set; }

        public string AccommodationPhone { get; set; } = string.Empty;

        public string AccommodationEmail { get; set; } = string.Empty;

        public string Activity1 { get; set; } = string.Empty;

        public string Activity2 { get; set; } = string.Empty;

        public string Activity3 { get; set; } = string.Empty;   


    }
}
