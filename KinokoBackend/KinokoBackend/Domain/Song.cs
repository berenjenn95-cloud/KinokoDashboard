namespace KinokoBackend.Domain
{
    public class Song
    {

        public int Id { get; private set; }

        public string Title { get; set; } = string.Empty;
        public string FileName { get;  set; } = string.Empty;

        public TimeSpan Duration { get;  set; }

        public DateTime Date { get; private set; } = DateTime.UtcNow;
        public Song() { }
        public Song(int id,string title, string fileName, TimeSpan duration, DateTime date)
        {
            Id = id;
            Title = title;
            FileName = fileName;
            Duration = duration;
            Date = date;
        }


    }
}
