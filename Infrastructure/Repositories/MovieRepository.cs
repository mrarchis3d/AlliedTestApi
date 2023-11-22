using Domain.Criteria;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly MovieDbContext _dbContext;

        public MovieRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Movie>> GetMoviesPagedAsync(PagedCriteria<Movie> criteria)
        {
            IQueryable<Movie> query = _dbContext.Set<Movie>();

            if (criteria.Filter != null)
            {
                query = query.Where(criteria.Filter);
            }

            if (criteria.OrderBy != null)
            {
                query = criteria.OrderBy(query);
            }

            var movies = await query
                .Include(m=>m.PosterImage)
                .Skip((criteria.PageNumber - 1) * criteria.PageSize)
                .Take(criteria.PageSize)
                .OrderByDescending(x=>x.Year)
                .ThenByDescending(x=>x.Title)
                .ToListAsync();

            return movies;
        }
    }
}
