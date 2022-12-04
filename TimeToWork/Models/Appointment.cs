using System.ComponentModel.DataAnnotations;

namespace TimeToWork.Models
{
	public class Appointment
	{
		public int AppointmentId { get; set; }
		public int ServiceId { get; set; }
		public int ClientId { get; set; }

		[Display(Name = "Дата")]
		public DateTime Date { get; set; }

		public Service? Service { get; set; }
		public Client? Client { get; set; }
	}
}
