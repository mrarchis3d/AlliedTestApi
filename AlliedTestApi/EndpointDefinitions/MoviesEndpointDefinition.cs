using AlliedTestApi.Abstractions;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlliedTestApi.EndpointDefinitions
{
    public class MoviesEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var movies = app.MapGroup("/api/movies").WithOpenApi();

            //GET
            movies.MapGet("/", GetPagedMovies).WithName("GetPagedMovies");
        }

        private async Task<IResult> GetPagedMovies(IMediator mediator, [FromQuery] int p, [FromQuery] int s, [FromQuery] string? filter)
        {
            GetPagedMoviesQueryHandler.Query query = new GetPagedMoviesQueryHandler.Query();
            query.PageNumber = p;
            query.PageSize = s;
            query.filer = filter!;
            return TypedResults.Ok(await mediator.Send(query));
        }
    }
}
