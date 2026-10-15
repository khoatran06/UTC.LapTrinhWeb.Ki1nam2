using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tdkhoa_day9.Models;

namespace Tdkhoa_day9.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        [Range(0, double.MaxValue)]
        public float Price { get; set; }

        [Range(0, double.MaxValue)]
        public float SalePrice { get; set; }

        public byte Status { get; set; } = 1;

        [Required]
        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Today;

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(350)]
        public string? Description { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}