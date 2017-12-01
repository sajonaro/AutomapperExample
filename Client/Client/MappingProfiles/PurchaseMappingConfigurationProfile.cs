namespace Client.MappingProfiles
{
    using System.Linq;

    using AutoMapper;
    using Client.DTOS;
    using Domain;
    
    /// <summary>
    /// mapping specifications of Product to PuchaseDetailsDTO transformation 
    /// </summary>
    class PurchaseMappingConfigurationProfile : Profile
    {
        public PurchaseMappingConfigurationProfile()
        {
            this.CreateMap<Product, PurchaseDetailsDTO>().
                ForMember(m => m.ProductName, opt =>
                    opt.MapFrom(e => e.Name)).
                ForMember(m=>m.OrderAmounts, opt =>
                    opt.MapFrom(m=>m.Orders.Select(e=>e.Amout)));
        }
    }
}
