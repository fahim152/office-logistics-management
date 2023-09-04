using mlbd_logistics_management.ViewModels;

namespace mlbd_logistics_management.Services;

public interface IPaginationService
{
    Task<PaginatedList<T>> PaginateAsync<T>(IQueryable<T> source, int pageNumber, int pageSize) where T : class;
}
