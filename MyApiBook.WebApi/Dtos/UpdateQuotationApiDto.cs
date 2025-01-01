namespace MyApiBook.WebApi.Dtos
{
    public class UpdateQuotationApiDto
    {
        public int QuatationID { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
    }
}
