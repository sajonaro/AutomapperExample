using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    using System.Linq;

    using AutoMapper;

    using Client.DTOS;

    using Domain;

    /// <summary>
    /// Explicit configuration
    /// </summary>
    public class ManualConfigMapperFactory
    {
        public static IMapper GetMapper()
        {
            var automapperConfiguration = new MapperConfiguration(
                cfg =>
                {
                    //clientDTO
                    cfg.CreateMap<Customer, ClientDTO>();

                    //PurchaseDetailsDTO
                    cfg.CreateMap<Product, PurchaseDetailsDTO>().
                        ForMember(m => m.ProductName, opt =>
                            opt.MapFrom(e => e.Name));
                });

            return new Mapper(automapperConfiguration);

        }
    }
}
