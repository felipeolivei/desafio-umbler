using AutoMapper;
using Desafio.Umbler.Business.Dto;
using Desafio.Umbler.Data.Models;
using Desafio.Umbler.Data.Repositories;
using DnsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whois.NET;

namespace Desafio.Umbler.Business.Services
{
    public class DomainService : ServiceBase<Domain>, IDomainService
    {
        private readonly IDomainRepository _domainRepository;
        private readonly IMapper _mapper;

        public DomainService(IDomainRepository domainRepository, IMapper mapper) : base(domainRepository)
        {
            _domainRepository = domainRepository;
            _mapper = mapper;
        }

        public async Task<DomainDto> GetByDomainName(string domainName)
        {
            var domain = _domainRepository.GetWhere(d => d.Name == domainName);

            if (domain == null)
            {
                domain = await GetDomainAsync(domainName);

                _domainRepository.Add(domain);
            }

            if (DateTime.Now.Subtract(domain.UpdatedAt).TotalMinutes > domain.Ttl)
            {
                domain = await GetDomainAsync(domainName, domain);

                _domainRepository.Update(domain);
            }

            return _mapper.Map<DomainDto>(domain);
        }

        private async Task<Domain> GetDomainAsync(string domainName, Domain? domain = null)
        {
            var response = await WhoisClient.QueryAsync(domainName);

            var lookup = new LookupClient();
            var result = await lookup.QueryAsync(domainName, QueryType.ANY);
            var record = result.Answers.ARecords().FirstOrDefault();
            var address = record?.Address;
            var ip = address?.ToString();

            var hostResponse = await WhoisClient.QueryAsync(ip);

            if (domain == null)
                domain = new Domain
                {
                    Name = domainName,
                    Ip = ip,
                    UpdatedAt = DateTime.Now,
                    WhoIs = response.Raw,
                    Ttl = record?.TimeToLive ?? 0,
                    HostedAt = hostResponse.OrganizationName
                };
            else
            {
                domain.Name = domainName;
                domain.Ip = ip;
                domain.UpdatedAt = DateTime.Now;
                domain.WhoIs = response.Raw;
                domain.Ttl = record?.TimeToLive ?? 0;
                domain.HostedAt = hostResponse.OrganizationName;
            }

            return domain;
        }
    }
}
