using System.ComponentModel.DataAnnotations;

namespace SeyahatSitesi.Models.Class
{
	public class Home
	{
		[Key]
		public int Id { get; set; }
		public string Baslik { get; set; }
		public string Aciklama { get; set; }


	}
}
