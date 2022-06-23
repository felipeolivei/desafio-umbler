using Desafio.Umbler.Data.Context;
using Desafio.Umbler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Umbler.Data.Repositories
{
    public class DomainRepository : RepositoryBase<Domain>, IDomainRepository
    {
        public DomainRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
