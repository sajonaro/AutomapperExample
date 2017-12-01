
namespace Client
{
    using AutoMapper;

    /// <summary>
    /// denotes the fact that this class defines custom mapping configuration
    /// </summary>
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }

    /// <inheritdoc />
    /// <summary>
    /// T is source
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHaveCustomMappings<T> : IHaveCustomMappings
    {

    }
}
