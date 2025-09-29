using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs.MovieActorDto
{
    public class CreateMovieActorDto
    {
        public string CharacterName { get; set; }

        public int MovieId { get; set; }

        public int ActorId { get; set; }
    }
}
