using System.ComponentModel.DataAnnotations;

namespace ComplantSystem.Areas.VillagesUsers.Models
{
    public class InputSearch
    {
        [MinLength(3)]
        [Required]
        public string Term { get; set; }
    }
}
