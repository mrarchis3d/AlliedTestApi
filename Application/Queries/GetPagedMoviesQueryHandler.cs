using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Application.Queries
{
    public class GetPagedMoviesQueryHandler
    {
        public class Query : IRequest<List<MovieDto>>
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string filer { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.PageNumber).NotNull().NotEmpty()
                   .WithMessage(string.Format("This Field is required, {0}", nameof(Query.PageNumber)));
                RuleFor(x => x.PageSize).NotNull().NotEmpty()
                   .WithMessage(string.Format("This Field is required, {0}", nameof(Query.PageSize)));
            }
        }

        public class Handler : IRequestHandler<Query, List<MovieDto>>
        {
            private readonly IMovieRepository _movieRepository;
            private readonly IMapper _mapper;
            public Handler(IMovieRepository movieRepository, IMapper mapper)
            {
                _movieRepository = movieRepository;
                _mapper = mapper;
            }
            public async Task<List<MovieDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var criteria = new Domain.Criteria.PagedCriteria<Movie>(request.PageNumber, request.PageSize);
                if(!string.IsNullOrWhiteSpace(request.filer))
                    criteria.Filter = (Movie) => Movie.Title.ToLower().Contains(request.filer.ToLower());
                var pagedMovies = await _movieRepository.GetMoviesPagedAsync(criteria);
                return _mapper.Map<List<MovieDto>>(pagedMovies);
            }
        }
    }
}
