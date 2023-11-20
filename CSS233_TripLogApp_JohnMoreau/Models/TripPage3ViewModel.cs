

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
    public class TripPage3ViewModel
    {
        public int? Id { get; set; }
        public string? Activity1 { get; set; } = string.Empty;

        public string? Activity2 { get; set; } = string.Empty;

        public string? Activity3 { get; set; } = string.Empty;

        // Default 
        public TripPage3ViewModel()
        {
        }

        // Constructor for edit path
        public TripPage3ViewModel(Trip trip)
        {
            this.Id = trip.Id;
            this.Activity1 = trip.Activity1;
            this.Activity2 = trip.Activity2;
            this.Activity3 = trip.Activity3;
        }

    }
}
