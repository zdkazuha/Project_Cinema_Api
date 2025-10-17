namespace DataAccess.Data.Entities
{
    public class Movie : BaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        public double Rating { get; set; }

        public long Budget { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PosterUrl { get; set; }

        // navigation property

        public ICollection<Genre>? Genres { get; set; }

        public ICollection<Review>? Reviews { get; set; }

        public ICollection<MovieActor>? MovieActors { get; set; }

    }
}
