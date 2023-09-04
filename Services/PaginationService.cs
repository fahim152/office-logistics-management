namespace mlbd_logistics_management.Services;

using mlbd_logistics_management.Services;
using mlbd_logistics_management.ViewModels;
using Microsoft.EntityFrameworkCore;

public class PaginationService : IPaginationService
{
     public async Task<PaginatedList<T>> PaginateAsync<T>(IQueryable<T> query, int pageNumber, int pageSize) where T : class
    {
        var items = await query.Skip((pageNumber - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

        var totalCount = await query.CountAsync();

        return new PaginatedList<T>(items, totalCount, pageNumber, pageSize);
    }
}
