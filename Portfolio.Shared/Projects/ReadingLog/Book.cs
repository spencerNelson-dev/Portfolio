namespace Portfolio.Shared.Projects.ReadingLog
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public ReadingLog ReadingLog { get; set; }
    }
}
