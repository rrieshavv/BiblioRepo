using System.ComponentModel.DataAnnotations;

namespace BiblioRepo.Web.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="Category title")]
        public string Title { get; set; }
    }
}
