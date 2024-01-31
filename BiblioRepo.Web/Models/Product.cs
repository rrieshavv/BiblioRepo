using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioRepo.Web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        [Required]
        [StringLength (50)]
        public string Author { get; set; }

        [Required]
        [StringLength (50)]
        public string ISBN { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Range (1, 100000)]
        public double Price { get; set; }

        [Required]
        [Display(Name= "Discount rate")]
        public float DiscountRate { get; set; }

        [Required]
        [Range (1,100000)]
        [Display(Name="Discounted price")]
        public double DiscountedPrice { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }
    }
}
