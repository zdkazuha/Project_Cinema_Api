using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.DTOs.MovieDto
{
    public class CreateMovieDto
    {
        [Required, MinLength(3)]
        public string Title { get; set; }

        [Required, MinLength(10)]
        public string Overview { get; set; }

        [Required, Range(1, 10)]
        public double Rating { get; set; }

        [Required, Range(1, int.MaxValue)]
        public long Budget { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string PosterUrl { get; set; }
    }
}
