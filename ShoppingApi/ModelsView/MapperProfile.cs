using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi.ModelsView
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            /**Customer**/
            CreateMap<Customer, JoinCustomerDTO>().ForMember(dto => dto.CustomerItems, opt => opt.MapFrom(x => x.CustomerItems));
            CreateMap<JoinCustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            /**CustomerItem**/
            CreateMap<CustomerItem, CustomerItemDTO>().ForMember(dto => dto.ItemName, opt => opt.MapFrom(x => x.Item.Name))
                                                      .ForMember(dto => dto.ItemPrice, opt => opt.MapFrom(x => x.Item.Price));
            CreateMap<CustomerItemDTO, CustomerItem>();

            /**Item**/
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();

            /**Categories**/
            CreateMap<Category, JoinCategoryDTO>().ForMember(dto => dto.Items, opt => opt.MapFrom(x => x.Items));
            CreateMap<JoinCategoryDTO, Category>();

        }
    }

}
