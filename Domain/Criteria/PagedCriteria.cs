using System.Linq.Expressions;

namespace Domain.Criteria
{
    public class PagedCriteria<TEntity>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Expression<Func<TEntity, bool>> Filter { get; set; }
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }

        public PagedCriteria(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PagedCriteria(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter)
            : this(pageNumber, pageSize)
        {
            Filter = filter;
        }

        public PagedCriteria(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
            : this(pageNumber, pageSize, filter)
        {
            OrderBy = orderBy;
        }
    }
}
