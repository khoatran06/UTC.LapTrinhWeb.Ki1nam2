using System.ComponentModel.DataAnnotations;

namespace tdkhoa_day7.Models
{
    public class Product : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [StringLength(150, MinimumLength = 6,
            ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ảnh sản phẩm là bắt buộc.")]
        public string Image { get; set; }

        [Range(100000, float.MaxValue,
            ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 100.000.")]
        public float Price { get; set; }

        [Range(0, float.MaxValue,
            ErrorMessage = "Giá khuyến mãi không được âm.")]
        public float SalePrice { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        public int? CategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            // SalePrice phải nhỏ hơn hoặc bằng 90% Price
            if (SalePrice > Price * 0.9f)
            {
                yield return new ValidationResult(
                    "Giá khuyến mãi phải nhỏ hơn hoặc bằng 90% giá chuẩn.",
                    new[] { nameof(SalePrice) });
            }

            // Kiểm tra Description
            if (!string.IsNullOrWhiteSpace(Description))
            {
                // Không quá 1500 ký tự
                if (Description.Length > 1500)
                {
                    yield return new ValidationResult(
                        "Mô tả không được vượt quá 1500 ký tự.",
                        new[] { nameof(Description) });
                }

                // Từ nhạy cảm
                string[] tuCam =
                {
                    "die",
                    "admin",
                    "fuck",
                    "địt",
                    "đụ"
                };

                foreach (string tu in tuCam)
                {
                    if (Description.Contains(
                        tu,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        yield return new ValidationResult(
                            "Mô tả không được chứa từ nhạy cảm.",
                            new[] { nameof(Description) });

                        break;
                    }
                }
            }
        }
    }
}