using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MvcMapper.ViewModels;
using MvcMapper.Models;

namespace MvcMapper.Mappers
{
    public class ViewModelToDomainMappingProfile
        : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClientViewModel, Client>();
        }
    }
}