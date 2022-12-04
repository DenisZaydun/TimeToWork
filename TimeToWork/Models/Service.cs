using System.ComponentModel.DataAnnotations;

namespace TimeToWork.Models
{
	public class Service
	{
		public int ServiceId { get; set; }

		[Display(Name = "Назва послуги")]
		[StringLength(50, MinimumLength = 3)]
		public string? ServiceName { get; set; }

		[Display(Name = "Короткий опис")]
		public string? ShortDescription { get; set; }

		[Display(Name = "Опис")]
		public string? Description { get; set; }
		public ICollection<Appointment>? Appointments { get; set; }
		public ICollection<ServiceAssignment>? ServiceAssignments { get; set; }
	}
}
