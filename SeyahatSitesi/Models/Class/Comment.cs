using System.ComponentModel.DataAnnotations;

namespace SeyahatSitesi.Models.Class
{
	public class Comment
	{
		[Key]
		public int Id { get; set; }
		public string User { get; set; }
		public string Email { get; set; }
		public string Commentss { get; set; }
		public int Blogid { get; set; }
		public virtual Blog Blog { get; set; }
		/*public int Bloke { get; set; }*///blogId senin Bloke e eşit oluyor
		//public virtual Blog id { get; set; }




	}
}
