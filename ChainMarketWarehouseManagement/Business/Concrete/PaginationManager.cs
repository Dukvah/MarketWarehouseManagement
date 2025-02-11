using Business.Abstract;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class PaginationManager : IPaginationService
    {
        public async Task<PaginationResult<T>> GetPagedDataAsync<T>(
        IQueryable<T> query, int pageNumber, int pageSize) where T : class
        {
            var totalRecords = await query.CountAsync();
            var data = await query.Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return new PaginationResult<T>(data, pageNumber, pageSize, totalRecords);
        }
    }
}
