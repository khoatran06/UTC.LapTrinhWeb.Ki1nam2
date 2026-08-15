using System;
using System.Collections.Generic;
using System.Linq;

namespace tdkhoa_day1
{
    /// <summary>
    /// Xử lý các chức năng quản lý sinh viên
    /// </summary>
    internal class StudentService
    {
        private List<Student> danhSachSinhVien = new List<Student>();

        // 1. Thêm sinh viên
        public bool ThemSinhVien(Student sinhVien)
        {
            if (sinhVien == null)
            {
                return false;
            }

            // Kiểm tra mã sinh viên trùng
            if (danhSachSinhVien.Any(s =>
                s.maSV.Equals(sinhVien.maSV, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            danhSachSinhVien.Add(sinhVien);
            return true;
        }

        // 2. Hiển thị danh sách sinh viên
        public List<Student> LayDanhSachSinhVien()
        {
            return danhSachSinhVien;
        }

        // 3. Tìm sinh viên theo mã
        public Student? TimSinhVienTheoMa(string maSV)
        {
            return danhSachSinhVien.FirstOrDefault(
                s => s.maSV.Equals(maSV, StringComparison.OrdinalIgnoreCase)
            );
        }

        // 4. Tìm gần đúng theo họ tên
        public List<Student> TimGanDungTheoHoTen(string hoTen)
        {
            return danhSachSinhVien
                .Where(s => s.hoTen.Contains(
                    hoTen,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // 5. Cập nhật sinh viên
        public bool CapNhatSinhVien(string maSV, Student sinhVienMoi)
        {
            Student? sinhVien = TimSinhVienTheoMa(maSV);

            if (sinhVien == null)
            {
                return false;
            }

            sinhVien.hoTen = sinhVienMoi.hoTen;
            sinhVien.ngaySinh = sinhVienMoi.ngaySinh;
            sinhVien.gioiTinh = sinhVienMoi.gioiTinh;
            sinhVien.Email = sinhVienMoi.Email;
            sinhVien.soDienThoai = sinhVienMoi.soDienThoai;
            sinhVien.nganhHoc = sinhVienMoi.nganhHoc;
            sinhVien.GPA = sinhVienMoi.GPA;
            sinhVien.trangThai = sinhVienMoi.trangThai;

            return true;
        }

        // 6. Xóa sinh viên
        public bool XoaSinhVien(string maSV)
        {
            Student? sinhVien = TimSinhVienTheoMa(maSV);

            if (sinhVien == null)
            {
                return false;
            }

            danhSachSinhVien.Remove(sinhVien);

            // Giảm tổng số sinh viên
            Student.DecreaseTotalStudents();

            return true;
        }

        // 7. Sắp xếp theo họ tên
        public List<Student> SapXepTheoTen()
        {
            return danhSachSinhVien
                .OrderBy(s => s.hoTen)
                .ToList();
        }

        // 8. Sắp xếp theo điểm trung bình
        public List<Student> SapXepTheoGPA()
        {
            return danhSachSinhVien
                .OrderByDescending(s => s.GPA)
                .ToList();
        }

        // 9. Hiển thị sinh viên có điểm từ 8 trở lên
        public List<Student> LaySinhVienGPA_Tu8()
        {
            return danhSachSinhVien
                .Where(s => s.GPA >= 8)
                .ToList();
        }

        // 10. Hiển thị sinh viên có điểm cao nhất
        public List<Student> LaySinhVienGpaCaoNhat()
        {
            if (danhSachSinhVien.Count == 0)
            {
                return new List<Student>();
            }

            double gpaCaoNhat = danhSachSinhVien.Max(s => s.GPA);

            return danhSachSinhVien
                .Where(s => s.GPA == gpaCaoNhat)
                .ToList();
        }

        // 11. Tính điểm trung bình toàn bộ sinh viên
        public double TinhGPATrungBinh()
        {
            if (danhSachSinhVien.Count == 0)
            {
                return 0;
            }

            return danhSachSinhVien.Average(s => s.GPA);
        }

        // 12. Thống kê sinh viên theo ngành
        public Dictionary<string, int> ThongKeTheoNganh()
        {
            return danhSachSinhVien
                .GroupBy(s => s.nganhHoc)
                .ToDictionary(
                    nhom => nhom.Key,
                    nhom => nhom.Count()
                );
        }

        // 13. Thống kê sinh viên theo trạng thái
        public Dictionary<bool, int> ThongKeTheoTrangThai()
        {
            return danhSachSinhVien
                .GroupBy(s => s.trangThai)
                .ToDictionary(
                    nhom => nhom.Key,
                    nhom => nhom.Count()
                );
        }
    }
}