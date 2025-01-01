namespace MyApiBook.WebUI.Dtos
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Status { get; set; }
        public string Icon { get; set; }
    }
}
