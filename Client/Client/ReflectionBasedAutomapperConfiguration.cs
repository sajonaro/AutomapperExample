using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    public class ReflectionBasedAutomapperConfiguration
    {
        public static void ConfigureMapping()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            LoadStandardMappings(types);
            LoadCustomMappings(types);
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t)&&
                              !i.IsAbstract &&  
                              !i.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                Mapper.Initialize( cfg=> map.CreateMappings(cfg));
            }
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) && !i.IsAbstract
                              && !i.IsInterface
                        select new { Source = i.GetGenericArguments()[0], Destination = t }).ToArray();

            foreach (var map in maps)
            {
                Mapper.Map(map.Source, map.Destination);
            }

        }
    }
}
