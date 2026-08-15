using System;
using System.Collections.Generic;
using System.Globalization;

namespace tdkhoa_day1
{
    /// <summary>
    /// Nhập và hiển thị thông tin sinh viên trên Console
    /// </summary>
    internal class StudentConsoleView
    {
        // Nhập một sinh viên
        public Student NhapSinhVien()
        {
            Student sinhVien = new Student();

            Console.Write("Nhap ma sinh vien: ");
            sinhVien.maSV = Console.ReadLine() ?? "";

            Console.Write("Nhap ho ten: ");
            sinhVien.hoTen = Console.ReadLine() ?? "";

            Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
            string ngaySinh = Console.ReadLine() ?? "";

            if (DateTime.TryParseExact(
                ngaySinh,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime ngay))
            {
                sinhVien.ngaySinh = ngay;
            }

            Console.Write("Nhap gioi tinh (Nam/Nu): ");
            string gioiTinh = Console.ReadLine() ?? "";
            sinhVien.gioiTinh = gioiTinh.Equals(
                "Nam",
                StringComparison.OrdinalIgnoreCase);

            Console.Write("Nhap Email: ");
            sinhVien.Email = Console.ReadLine();

            Console.Write("Nhap so dien thoai: ");
            sinhVien.soDienThoai = Console.ReadLine();

            Console.Write("Nhap nganh hoc: ");
            sinhVien.nganhHoc = Console.ReadLine() ?? "";

            Console.Write("Nhap diem trung binh: ");
            double.TryParse(
                Console.ReadLine(),
                out double GPA);
            sinhVien.GPA = GPA;

            Console.Write("Nhap trang thai (Đang hoc/Nghi hoc): ");
            string trangThai = Console.ReadLine() ?? "";
            sinhVien.trangThai = trangThai.Equals(
                "Đang hoc",
                StringComparison.OrdinalIgnoreCase);

            return sinhVien;
        }

        // Hiển thị một sinh viên
        public void HienThiSinhVien(Student sinhVien)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Ma SV       : {sinhVien.maSV}");
            Console.WriteLine($"Ho ten      : {sinhVien.hoTen}");

            if (sinhVien.ngaySinh.HasValue)
            {
                Console.WriteLine(
                    $"Ngay sinh   : {sinhVien.ngaySinh.Value:dd/MM/yyyy}");
            }
            else
            {
                Console.WriteLine("Ngay sinh   : Chưa co");
            }

            Console.WriteLine(
                $"Gioi tinh   : {(sinhVien.gioiTinh ? "Nam" : "Nu")}");
            Console.WriteLine($"Email       : {sinhVien.Email}");
            Console.WriteLine($"SĐT         : {sinhVien.soDienThoai}");
            Console.WriteLine($"Ngành học   : {sinhVien.nganhHoc}");
            Console.WriteLine($"GPA         : {sinhVien.GPA:F2}");
            Console.WriteLine(
                $"Trạng thái  : {(sinhVien.trangThai ? "Đang hoc" : "Nghi hoc")}");
            Console.WriteLine("----------------------------------------");
        }

        // Hiển thị danh sách sinh viên
        public void HienThiDanhSach(List<Student> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach sinh vien dang trong!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("========== DANH SACH SINH VIEN ==========");

            foreach (Student sinhVien in danhSach)
            {
                HienThiSinhVien(sinhVien);
            }

            Console.WriteLine($"Tong so sinh vien: {danhSach.Count}");
        }

        // Hiển thị một dòng thông báo
        public void ThongBao(string noiDung)
        {
            Console.WriteLine(noiDung);
        }

        // Nhập mã sinh viên
        public string NhapMaSV()
        {
            Console.Write("Nhap ma sinh vien: ");
            return Console.ReadLine() ?? "";
        }

        // Nhập họ tên
        public string NhapHoTen()
        {
            Console.Write("Nhap ho ten can tim: ");
            return Console.ReadLine() ?? "";
        }

        // Hiển thị menu
        public void HienThiMenu()
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("       CHUONG TRINH QUAN LY SINH VIEN    ");
            Console.WriteLine("==========================================");
            Console.WriteLine("1.  Them sinh vien");
            Console.WriteLine("2.  Hien thi danh sach");
            Console.WriteLine("3.  Tim sinh vien theo ma");
            Console.WriteLine("4.  Tim gan dung theo ho ten");
            Console.WriteLine("5.  Cap nhat sinh vien");
            Console.WriteLine("6.  Xoa sinh vien");
            Console.WriteLine("7.  Sap xep theo ho ten");
            Console.WriteLine("8.  Sap xep theo diem trung binh");
            Console.WriteLine("9.  Hien thi sinh vien co diem tu 8 tro len");
            Console.WriteLine("10. Hien thi sinh vien co diem cao nhat");
            Console.WriteLine("11. Tinh diem trung binh toan bo sinh vien");
            Console.WriteLine("12. Thong ke sinh vien theo nganh");
            Console.WriteLine("13. Thong ke sinh vien theo trang thai");
            Console.WriteLine("0.  Exit");
            Console.WriteLine("==========================================");
            Console.Write("Chon chuc nang: ");
        }

        // Tạm dừng màn hình
        public void DungManHinh()
        {
            Console.WriteLine();
            Console.WriteLine("Nhan Enter de tiep tuc...");
            Console.ReadLine();
        }
    }
}
