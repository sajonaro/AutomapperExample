using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    /// <summary>
    /// Reflection nBased Automapper factory
    /// </summary>
    public class MapperFactory
    {
        public static IMapper  GetMapper()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            var automapperConfiguration = new MapperConfiguration(cfg =>
                {
                    LoadStandardMappings(types, cfg);
                    LoadCustomMappings(types,cfg);
                });

            return new Mapper(automapperConfiguration);
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression configExpression)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t)&&
                              !t.IsAbstract &&  
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(configExpression);
            }
        }

        private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression configExpression)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType &&
                              i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                             !t.IsAbstract &&
                             !t.IsInterface
                        select new { Source = i.GetGenericArguments()[0], Destination = t }).ToArray();

            foreach (var map in maps)
            {
                configExpression.CreateMap(map.Source, map.Destination);
            }

        }
    }
}
