namespace DataAccess.Data.Entities
{
    public class Genre : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // navigation property
        public ICollection<Movie>? Movies { get; set; }
    }
}
