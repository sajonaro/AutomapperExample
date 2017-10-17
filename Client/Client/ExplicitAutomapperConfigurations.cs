using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    using AutoMapper;

    using Domain;

    class ExplicitAutomapperConfigurations
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                    cfg.CreateMap<Order, PurchaseDetailsDTO>();
                    cfg.CreateMap<Customer, PurchaseDetailsDTO>();
                });
        }
    }
}
