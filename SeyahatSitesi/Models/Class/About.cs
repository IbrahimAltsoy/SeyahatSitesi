using System.ComponentModel.DataAnnotations;

namespace SeyahatSitesi.Models.Class
{
	public class About
	{
		[Key]
		public int Id { get; set; }
		public string ImageUrl { get; set; }
		public string Abouts { get; set; }


	}
}
