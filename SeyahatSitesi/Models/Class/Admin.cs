using System.ComponentModel.DataAnnotations;

namespace SeyahatSitesi.Models.Class
{
	public class Admin
	{
		[Key]
		public int Id { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
	}
}
