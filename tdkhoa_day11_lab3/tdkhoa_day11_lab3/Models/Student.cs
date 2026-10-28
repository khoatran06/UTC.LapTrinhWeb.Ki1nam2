using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace tdkhoa_day11_lab3.Models
{
    public enum Branch
    {
        IT = 1,
        BE = 2,
        CE = 3,
        EE = 4
    }

    public enum Gender
    {
        Nam = 1,
        Nu = 2,
        Khac = 3
    }

    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        [StringLength(
            100,
            MinimumLength = 4,
            ErrorMessage = "Họ và tên phải có từ 4 đến 100 ký tự."
        )]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        [RegularExpression(
            @"^[A-Za-z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Email phải có tên miền gmail.com."
        )]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d\s])\S+$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, chữ số và ký tự đặc biệt."
        )]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Chuyên ngành")]
        [Required(ErrorMessage = "Vui lòng chọn chuyên ngành.")]
        public Branch? Branch { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
        public Gender? Gender { get; set; }

        [Display(Name = "Sinh viên chính quy")]
        public bool IsRegular { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh.")]
        [DataType(DataType.Date)]
        [Range(
            typeof(DateTime),
            "01/01/1963",
            "12/31/2005",
            ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005."
        )]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "Vui lòng nhập điểm.")]
        [Range(
            0.0,
            10.0,
            ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10."
        )]
        public double? Score { get; set; }
    }
}