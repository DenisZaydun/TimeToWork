namespace TimeToWork.Models
{
	public class ServiceAssignment
	{
		public int ServiceProviderID { get; set; }
		public int ServiceID { get; set; }
		public ServiceProvider ServiceProvider { get; set; }
		public Service Service { get; set; }
	}
}
