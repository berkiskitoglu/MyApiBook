namespace MyApiBook.WebUI.Dtos
{
    public class UpdateArticleDto
    {
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
        public int ArticleID { get; set; }
    }
}
