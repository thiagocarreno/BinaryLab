using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace MvcMapper.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings() 
        {
            Mapper.Initialize(
                m =>
                {
                    m.AddProfile<DomainToViewModelMappingProfile>();
                    m.AddProfile<ViewModelToDomainMappingProfile>();
                }
            );
        } 
    }
}