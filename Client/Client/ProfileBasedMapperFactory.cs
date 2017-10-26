namespace Client
{
    using AutoMapper;
    using Client.DTOS;
    using Client.MappingProfiles;

    using Domain;

    /// <summary>
    /// Reflection based Automapper factory
    /// </summary>
    public class ProfileBasedMapperFactory
    {
        public static IMapper GetMapper()
        {
            var automapperConfiguration = new MapperConfiguration(cfg =>
                {
                    //clientDTO
                    cfg.CreateMap<Customer, ClientDTO>();

                    cfg.AddProfile<PurchaseMappingConfigurationProfile>();

                });

            return new Mapper(automapperConfiguration);
        }

    }
}
