using AutoMapper;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.DTOs.MovieDto;
using BusinessLogic.Interfaces;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet("All")]
        public IActionResult GetMovies()
        {
            return Ok(movieService.GetAll());
        }

        [HttpGet]
        public IActionResult GetMovieById(int id)
        {
            return Ok(movieService.Get(id));
        }

        [HttpPost]
        public IActionResult Created(CreateMovieDto createMovie)
        {
            movieService.Create(createMovie);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditMovieDto editMovie)
        {
            movieService.Edit(editMovie);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            movieService.Delete(id);

            return Ok();
        }
    }
}
