namespace MyApiBook.WebUI.Dtos
{
	public class ArticleWithAuthorAndBookDto
	{
		public int ArticleID { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Description { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
		public List<String> ImageUrl { get; set; }
	}
}
