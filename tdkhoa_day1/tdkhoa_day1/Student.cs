using System;

namespace tdkhoa_day1
{
    internal class Student
    {
        public static int TotalStudents { get; private set; } = 0;

        // Properties
        public string maSV { get; set; } = "";
        public string hoTen { get; set; } = "";
        public DateTime? ngaySinh { get; set; }
        public bool gioiTinh { get; set; }
        public string? Email { get; set; }
        public string? soDienThoai { get; set; }
        public string nganhHoc { get; set; } = "";
        public double GPA { get; set; }
        public bool trangThai { get; set; }

        // Constructor
        public Student()
        {
            TotalStudents++;
        }

        public static void DecreaseTotalStudents()
        {
            if (TotalStudents > 0)
            {
                TotalStudents--;
            }
        }
    }
}