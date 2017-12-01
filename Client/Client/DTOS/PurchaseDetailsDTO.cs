namespace Client.DTOS
{
    using System;
    using System.Dynamic;

    using AutoMapper;
    using Domain;

    public class PurchaseDetailsDTO: IHaveCustomMappings<Product>
    {
        public string ProductName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double[] OrderAmounts { get; set; }

        public string Function()
        {
            return "";
        }

        public void CreateMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, PurchaseDetailsDTO>().
                ForMember(m => m.ProductName, opt =>
                opt.MapFrom(e => e.Name));
        }
    }
}
