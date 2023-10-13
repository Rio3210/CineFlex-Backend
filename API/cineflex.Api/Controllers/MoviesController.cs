
using cineflex.Application.Dtos.MovieDto;
using cineflex.Application.Features.Movies.Requests.Commands;
using cineflex.Application.Features.Movies.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cineflex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {


        private readonly IMediator _mediatoR;

        public MoviesController(IMediator mediatoR)
        {
            _mediatoR = mediatoR;
        }



        [HttpGet]
        public async Task<ActionResult<List<GetMovieDto>>> Get()
        {

            var movies = await _mediatoR.Send(new GetMoviesListRequest());
            return Ok(movies);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMovieDto>> Get(int id)
        {
            var movie = await _mediatoR.Send(new GetMovieRequest { id = id });
            return Ok(movie);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateMovieDto data)
        {

            var res = await _mediatoR.Send(new CreateMovieCommand { movieDataTobeCreate = data });
            return Ok(res);
        }



        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateMovieDto data)
        {

            await _mediatoR.Send(new UpdateMovieCommand { UpdateMovieData = data });
            return NoContent();

        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
   
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteMovieCommand { Id = id };
            await _mediatoR.Send(command);
            return NoContent();

        }


    }
}
