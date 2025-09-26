using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Title { get; set; }

        [Required, MinLength(10)]
        public string Overview { get; set; }

        [Required, Range(1,10)]
        public double Rating { get; set; }

        [Required, Range(1, int.MaxValue)]
        public long Budget { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string PosterUrl { get; set; }

        public int? GenresId { get; set; }

        // navigation property

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }

    }
}
