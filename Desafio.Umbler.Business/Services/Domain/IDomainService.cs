using Desafio.Umbler.Business.Dto;
using Desafio.Umbler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Umbler.Business.Services
{
    public interface IDomainService : IServiceBase<Domain>
    {
        Task<DomainDto> GetByDomainName(string domainName);
    }
}
