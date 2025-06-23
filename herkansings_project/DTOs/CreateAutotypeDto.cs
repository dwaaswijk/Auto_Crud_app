using System.ComponentModel.DataAnnotations;

namespace AutoApi.DTOs
{
    public class CreateAutotypeDto
    {
        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [Required]
        public int AutomerkId { get; set; }
    }
}