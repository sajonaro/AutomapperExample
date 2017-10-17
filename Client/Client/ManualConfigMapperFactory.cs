using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
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
            var automapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Order, PurchaseDetailsDTO>();
                    cfg.CreateMap<Customer, PurchaseDetailsDTO>();
                });

            return new Mapper(automapperConfiguration);

        }
    }
}
