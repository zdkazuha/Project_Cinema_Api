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
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string CharacterName { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public int ActorId { get; set; }

        // navigation property

        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
