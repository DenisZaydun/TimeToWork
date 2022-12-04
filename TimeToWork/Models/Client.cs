using System.ComponentModel.DataAnnotations;

namespace TimeToWork.Models
{
	public class Client
	{
		public int ID { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Прізвище не може бути довше 50 символів.")]
		[Display(Name = "Прізвище")]
		public string? LastName { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Ім'я не може бути довше 50 символів.")]
		[Display(Name = "Ім'я")]
		public string? FirstName { get; set; }

		[Display(Name = "Повне ім'я")]
		public string FullName
		{
			get
			{
				return LastName + " " + FirstName;
			}
		}

		[Display(Name = "Номер телефону")]
		public string? PhoneNumber { get; set; }

		public ICollection<Appointment>? Appointments { get; set; }
	}
}
