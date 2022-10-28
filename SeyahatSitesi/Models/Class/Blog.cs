

using System.ComponentModel.DataAnnotations;

namespace SeyahatSitesi.Models.Class
{
	public class Blog
	{
		[Key]
		public int Id { get; set; }
		public string Baslik { get; set; }
		public DateTime DateTime { get; set; }
		public string Text { get; set; }
		public string BlogImage { get; set; }
		public ICollection<Comment> Comments { get; set; } // Bütün hata buradadaır  burayı incelemeye al burdan çıkarsın 
		


	}
}
