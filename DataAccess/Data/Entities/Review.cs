namespace DataAccess.Data.Entities
{
    public class Review : BaseEntity
    {
        public int Id{ get; set; }

        public string Comment { get; set; }

        public int MovieId { get; set; }

        public string UserId { get; set; }

        // navigation property

        public Movie Movie { get; set; }
        public User? User { get; set; }
    }
}
