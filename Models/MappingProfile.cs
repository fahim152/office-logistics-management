using AutoMapper;
using mlbd_logistics_management.Utils;
using mlbd_logistics_management.ViewModels;

namespace mlbd_logistics_management.Models
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Item, ItemViewModel>();
           CreateMap<PaginatedList<Item>, PaginatedList<ItemViewModel>>().ConvertUsing<PaginatedListConverter<Item, ItemViewModel>>();
        }
    }
}