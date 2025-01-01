namespace MyApiBook.WebUI.Dtos
{
	public class ResultCategoryWithBookAndAuthor
	{
		public int BookID { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public decimal OrginalPrice { get; set; }
		public decimal? CurrentPrice { get; set; }
		public string ImageUrl { get; set; }
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public int AuthorID { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
	}
}
