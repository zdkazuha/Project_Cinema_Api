using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs.MovieActorDto
{
    public class MovieActorDto
    {
        public int Id { get; set; }

        public string CharacterName { get; set; }
        public string MovieTitle { get; set; }
        public string ActorName { get; set; }
    }
}
