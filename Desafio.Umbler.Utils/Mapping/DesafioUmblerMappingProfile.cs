using AutoMapper;
using Desafio.Umbler.Business.Dto;
using Desafio.Umbler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Umbler.Utils.Mapping
{
    public class DesafioUmblerMappingProfile : Profile
    {
        public DesafioUmblerMappingProfile()
        {
            CreateMap<Domain, DomainDto>()
                .ReverseMap();

        }
    }
}
