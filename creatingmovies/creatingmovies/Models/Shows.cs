namespace creatingmovies.Models
{
    public class Shows
    {
        public string Title { get; set; }
        public int ReleaseYear { get;set; }
        public string Category { get; set; }
        public string Description { get; set; } 

        public Shows(string title, int releaseDate, string category, string description)
        {
            Title = title;
            ReleaseYear = releaseDate;
            Category = category;
            Description = description;
        }
    }
}
