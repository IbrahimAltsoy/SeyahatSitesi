using System.ComponentModel.DataAnnotations;

namespace SeyahatSitesi.Models.Class
{
	public class Address
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Explanation { get; set; }
		public string Adress { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Location { get; set; }


	}
}
