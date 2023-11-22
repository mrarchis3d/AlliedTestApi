using Domain.Criteria;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> GetMoviesPagedAsync(PagedCriteria<Movie> criteria);
    }
}
