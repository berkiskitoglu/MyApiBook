namespace MyApiBook.WebApi.Dtos
{
    public class UpdateBookApiDto
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal OrginalPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int AuthorID { get; set; }
    }
}
