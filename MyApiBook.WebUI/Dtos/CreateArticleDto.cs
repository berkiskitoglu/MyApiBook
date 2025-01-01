namespace MyApiBook.WebUI.Dtos
{
    public class CreateArticleDto
    {
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
     
    }
}
