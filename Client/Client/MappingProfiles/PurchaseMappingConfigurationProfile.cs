namespace Client.MappingProfiles
{
    using AutoMapper;
    using Client.DTOS;
    using Domain;

    class PurchaseMappingConfigurationProfile : Profile
    {
        public PurchaseMappingConfigurationProfile()
        {
            CreateMap<Product, PurchaseDetailsDTO>().
                ForMember(m => m.ProductName, opt =>
                    opt.MapFrom(e => e.Name));
        }
    }
}
