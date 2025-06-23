using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoApi.Models
{
    public class Autotype
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [ForeignKey("Automerk")]
        public int AutomerkId { get; set; }
        public Automerk Automerk { get; set; }
    }
}