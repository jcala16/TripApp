using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TripsApp.Models
{
[Table("Trips")] // Maps to the table name 'Trips'
public class Trip
{
[Key] // Specifies TripId as the primary key
public int TripId { get; set; }
[Required(ErrorMessage = "Destination is required")] //Validation: Destination is required
public string Destination { get; set; }
[Required(ErrorMessage = "Accommodation is required")] //Validation: Accommodation is required
public string Accommodation { get; set; }
[Required(ErrorMessage = "Start Date is required")] //Validation: StartDate is required
[DataType(DataType.Date)] // Specify data type as Date fordate picker in views
public DateTime StartDate { get; set; }
[Required(ErrorMessage = "End Date is required")] //Validation: EndDate is required
[DataType(DataType.Date)] // Specify data type as Date for date picker in views
public DateTime EndDate { get; set; }
public string AccommodationPhone { get; set; } // Optional
public string AccommodationEmail { get; set; } // Optional
public string Activity1 { get; set; } // Optional
public string Activity2 { get; set; } // Optional
public string Activity3 { get; set; } // Optional
}
}