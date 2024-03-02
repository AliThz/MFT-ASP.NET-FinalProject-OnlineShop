using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        #region [ - Ctor - ]
        public AutoMapperProfile()
        {
            #region [ - PersonFlow - ]
            CreateMap<Domain.Aggregates.PersonAggregate.Person, DTOs.PersonDTOs.PersonDTO>().ReverseMap();
            #endregion

            #region [ - ProductFlow - ]
            CreateMap<Domain.Aggregates.ProductAggregate.Product, DTOs.ProductDTOs.ProductDTO>().ReverseMap();
            #endregion

            #region [ - OrderFlow - ]
            CreateMap<Domain.Aggregates.OrderAggregate.OrderHeader, DTOs.OrderHeaderDTOs.OrderHeaderDTO>().ReverseMap();
            CreateMap<Domain.Aggregates.OrderAggregate.OrderDetail, DTOs.OrderDetailDTOs.OrderDetailDTO>().ReverseMap();
            #endregion
        }
        #endregion
    }
}
