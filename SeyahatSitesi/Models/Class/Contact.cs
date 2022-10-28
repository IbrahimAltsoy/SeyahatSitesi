using System.ComponentModel.DataAnnotations;

namespace SeyahatSitesi.Models.Class
{
	public class Contact
	{
		[Key]
		public int Id { get; set; }
		public string User { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Messaje { get; set; }

	}
}
