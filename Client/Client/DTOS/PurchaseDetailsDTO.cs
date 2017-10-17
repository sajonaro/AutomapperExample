namespace Client.DTOS
{
    using System;
    using AutoMapper;
    using Domain;

    public class PurchaseDetailsDTO: IHaveCustomMappings
    {
        public string ProductName { get; set; }
        public DateTime PurchaseDate { get; set; }

        public void CreateMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, PurchaseDetailsDTO>().
                ForMember(m => m.ProductName, opt =>
                opt.MapFrom(e => e.Name));
        }
    }
}
