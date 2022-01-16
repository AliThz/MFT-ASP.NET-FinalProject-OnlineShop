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
        }
        #endregion
    }
}
