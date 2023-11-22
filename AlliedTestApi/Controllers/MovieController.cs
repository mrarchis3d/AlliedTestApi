using Application.Queries;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AlliedTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MovieController> _logger;
        public MovieController(IMediator mediator, ILogger<MovieController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        [SwaggerOperation("Get movies paged")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Movies")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Error")]
        public async Task<List<MovieDto>> GetCircle([FromQuery] int p, [FromQuery] int s, [FromQuery] string? filter
        )
        {
            GetPagedMoviesQueryHandler.Query query = new GetPagedMoviesQueryHandler.Query();
            query.PageNumber = p;
            query.PageSize = s;
            query.filer = filter;
            return await _mediator.Send(query);
        }
    }
}
