using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MvcMapper.Models;
using MvcMapper.ViewModels;

namespace MvcMapper.Mappers
{
    public class DomainToViewModelMappingProfile
        : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Client, ClientViewModel>();
        }
    }
}