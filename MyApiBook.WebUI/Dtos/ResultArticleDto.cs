namespace MyApiBook.WebUI.Dtos
{
    public class ResultArticleDto
    {
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
        public int ArticleID { get; set; }
    }
}
