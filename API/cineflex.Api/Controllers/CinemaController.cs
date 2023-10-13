using cineflex.Application.Dtos.CinemaDto;
using cineflex.Application.Features.Cinemas.Requests.Commands;
using cineflex.Application.Features.Cinemas.Requests.Queries;
using cineflex.Application.Features.Movies.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cineflex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {

        private readonly IMediator _mediatoR;

        public CinemaController(IMediator mediatoR)
        {
            _mediatoR = mediatoR;
        }



        [HttpGet]
        public async Task<ActionResult<List<GetCinemaDto>>> Get()
        {

            var cinemas = await _mediatoR.Send(new GetCinemaRequest());
            return Ok(cinemas);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCinemaDto>> Get(int id)
        {
            var movie = await _mediatoR.Send(new GetCinemaRequest { id = id });
            return Ok(movie);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateCinemaDto data)
        {

            var res = await _mediatoR.Send(new CreateCinemaCommand { cinemaDataTobeCreate = data });
            return Ok(res);
        }



        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateCinemaDto data)
        {

            await _mediatoR.Send(new UpdateCinemaCommand { UpdateCinemaData = data });
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
