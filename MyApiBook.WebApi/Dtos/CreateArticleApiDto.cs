namespace MyApiBook.WebApi.Dtos
{
    public class CreateArticleApiDto
    {
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
      
    }
}
