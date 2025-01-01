namespace MyApiBook.WebApi.Dtos
{
    public class UpdateArticleApiDto
    {
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
        public int ArticleID { get; set; }
    }
}
