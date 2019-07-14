using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRazor.Models;
using AspNetCoreRazor.ViewModels;
using AutoMapper;

namespace AspNetCoreRazor.Data.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
        }
    }
}
