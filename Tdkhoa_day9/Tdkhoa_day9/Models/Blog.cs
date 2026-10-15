using System.ComponentModel.DataAnnotations;

namespace Tdkhoa_day9.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên bài viết")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public byte Status { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Today;

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(350)]
        public string? Description { get; set; }
    }
}