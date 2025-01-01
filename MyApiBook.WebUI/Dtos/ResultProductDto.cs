

namespace MyApiBook.WebUI.Dtos
{
    public class ResultProductDto
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal OrginalPrice { get; set; }
        public decimal? CurrentPrice { get; set; }
        public string ImageUrl { get; set; }
		public string Description { get; set; }


	}
}
                                                           