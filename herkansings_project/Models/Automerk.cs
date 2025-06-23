using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoApi.Models
{
    public class Automerk
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        public List<Autotype> Autotypes { get; set; } = new();
    }
}