namespace SviatoslavSkobalskyi.Meninx.DevTestTask.API.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int Quantity { get; set; }
    }
}
