using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class MovieActor
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
