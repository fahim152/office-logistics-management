using AutoMapper;
using mlbd_logistics_management.Utils;
using mlbd_logistics_management.ViewModels;
using mlbd_logistics_management.ViewModels.OutgoingRequests;

namespace mlbd_logistics_management.Models
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Item, ItemViewModel>();
           CreateMap<PaginatedList<Item>, PaginatedList<ItemViewModel>>().ConvertUsing<PaginatedListConverter<Item, ItemViewModel>>();

           CreateMap<ItemType, ItemTypeViewModel>();
           CreateMap<PaginatedList<ItemType>, PaginatedList<ItemTypeViewModel>>().ConvertUsing<PaginatedListConverter<ItemType, ItemTypeViewModel>>();
        }
    }
}