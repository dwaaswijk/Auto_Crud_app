using System.ComponentModel.DataAnnotations;

namespace AutoApi.DTOs
{
    public class CreateAutomerkDto
    {
        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }
    }
}