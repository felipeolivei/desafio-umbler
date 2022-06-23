using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Umbler.Data.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
