/*
* John Moreau
* CSS233
* 11/19/2023
*
*
*/

namespace CSS233_TripLogApp_JohnMoreau.Models
{
    public class TripPage2ViewModel
    {
        public int? Id { get; set; }

        public string? AccommodationPhone { get; set; } = string.Empty;

        public string? AccommodationEmail { get; set; } = string.Empty;

        // Default 
        public TripPage2ViewModel()
        {
        }

        // Constructor for edit path
        public TripPage2ViewModel(Trip trip)
        {
            this.Id = trip.Id;
            this.AccommodationPhone = trip.AccommodationPhone;
            this.AccommodationEmail = trip.AccommodationEmail;
        }

    }
}
