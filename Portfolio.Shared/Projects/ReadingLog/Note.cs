namespace Portfolio.Shared.Projects.ReadingLog
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int ReadingLogId { get; set; }
    }
}
