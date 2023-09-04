namespace mlbd_logistics_management.Utils;

using AutoMapper;
using mlbd_logistics_management.ViewModels;

public class PaginatedListConverter<TSource, TDestination> : ITypeConverter<PaginatedList<TSource>, PaginatedList<TDestination>>
{
    private readonly IMapper _mapper;

    public PaginatedListConverter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public PaginatedList<TDestination> Convert(PaginatedList<TSource> source, PaginatedList<TDestination> destination, ResolutionContext context)
    {
        var mappedItems = _mapper.Map<List<TDestination>>(source.Items);
        return new PaginatedList<TDestination>(mappedItems, source.TotalCount, source.PageNumber, source.PageSize);
    }
}
