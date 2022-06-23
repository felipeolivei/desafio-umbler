using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Umbler.Data.Models;
using Whois.NET;
using Microsoft.EntityFrameworkCore;
using DnsClient;
using Desafio.Umbler.Data.Context;
using Desafio.Umbler.Business.Services;

namespace Desafio.Umbler.Controllers
{
    [Route("api")]
    public class DomainController : BaseController
    {
        private readonly IDomainService _domainService;

        public DomainController(IDomainService domainService)
        {
            _domainService = domainService;
        }

        [HttpGet, Route("domain/{domainName}")]
        public async Task<IActionResult> Get(string domainName)
        {
            try
            {
                var domain = await _domainService.GetByDomainName(domainName);

                return Success(domain);
            }
            catch (Exception ex)
            {
                return Error(ex.Message, null);
            }
        }
    }
}
