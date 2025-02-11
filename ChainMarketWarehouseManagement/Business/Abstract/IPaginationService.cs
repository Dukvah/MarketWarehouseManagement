using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IPaginationService
    {
        Task<PaginationResult<T>> GetPagedDataAsync<T>(
        IQueryable<T> query, int pageNumber, int pageSize) where T : class;
    }
}
