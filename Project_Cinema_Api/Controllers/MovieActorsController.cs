using AutoMapper;
using BusinessLogic.DTOs.MovieActorDto;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorsController : ControllerBase
    {
        private readonly IMovieActorService movieActorService;

        public MovieActorsController(IMovieActorService movieActorService)
        {
            this.movieActorService = movieActorService;
        }

        [HttpGet("All")]
        public IActionResult GetMovieActors()
        {
            return Ok(movieActorService.GetAll());
        }

        [HttpGet]
        public IActionResult GetMovieActorById(int id)
        {
            return Ok(movieActorService.Get(id));
        }

        [HttpPost]
        public IActionResult Create(CreateMovieActorDto createMovieActor)
        {
            movieActorService.Create(createMovieActor);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditMovieActorDto editMovieActor)
        {
            movieActorService.Edit(editMovieActor);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            movieActorService.Delete(id);

            return Ok();
        }
    }
}
