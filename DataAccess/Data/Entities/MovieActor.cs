namespace DataAccess.Data.Entities
{
    public class MovieActor : BaseEntity
    {
        public int Id { get; set; }

        public string CharacterName { get; set; }

        public int MovieId { get; set; }

        public int ActorId { get; set; }

        // navigation property

        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
