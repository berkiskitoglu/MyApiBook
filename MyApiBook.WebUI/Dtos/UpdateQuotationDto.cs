﻿namespace MyApiBook.WebUI.Dtos
{
    public class UpdateQuotationDto
    {
        public int QuatationID { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
    }
}