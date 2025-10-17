namespace DataAccess.Data.Entities
{
    public class Actor : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // navigation property
        public ICollection<MovieActor>? MovieActors { get; set; }
    }
}
