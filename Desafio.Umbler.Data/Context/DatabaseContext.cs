using System;
using System.ComponentModel.DataAnnotations;
using Desafio.Umbler.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Umbler.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {

        }

        public DbSet<Domain> Domains { get; set; }
    }

    
}