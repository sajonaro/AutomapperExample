using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    using AutoMapper;
    using AutoMapper.Configuration;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
