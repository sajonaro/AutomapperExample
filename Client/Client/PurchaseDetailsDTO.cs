using System;

namespace Client
{
    using AutoMapper;
    using Domain;

    public class PurchaseDetailsDTO: IHaveCustomMappings, IMapFrom<Customer>,IMapFrom<Order>
    {
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public DateTime PurchaseDate { get; set; }

        public void CreateMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Customer, PurchaseDetailsDTO>().
                ForMember(m => m.ClientName, opt =>
                opt.MapFrom(e => e.Name));
        }
    }
}
