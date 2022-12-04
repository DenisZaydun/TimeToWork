using System.ComponentModel.DataAnnotations;

namespace TimeToWork.Models
{
	public class ServiceProvider
	{
		public int ID { get; set; }

		[Required]
		[Display(Name = "Прізвище")]
		[StringLength(50)]
		public string? LastName { get; set; }

		[Required]
		[Display(Name = "Ім'я")]
		[StringLength(50)]
		public string? FirstName { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Дата найму")]
		public DateTime HireDate { get; set; }

		[Display(Name = "Повне ім'я")]
		public string FullName
		{
			get { return LastName + " " + FirstName; }
		}

		public ICollection<ServiceAssignment>? ServiceAssignments { get; set; }
	}
}
