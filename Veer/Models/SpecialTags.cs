
using System.ComponentModel.DataAnnotations;

namespace Veer.Models
{
    public class SpecialTags
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tag Name")]
        public string SpecialTag { get; set; }
    }
}
