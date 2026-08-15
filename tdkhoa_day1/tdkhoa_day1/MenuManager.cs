using System;
using System.Collections.Generic;

namespace tdkhoa_day1
{
    /// <summary>
    /// Quản lý menu và điều hướng các chức năng
    /// </summary>
    internal class MenuManager
    {
        private StudentService studentService;
        private StudentConsoleView consoleView;

        public MenuManager()
        {
            studentService = new StudentService();
            consoleView = new StudentConsoleView();
        }

        // Chạy chương trình
        public void ChayChuongTrinh()
        {
            bool tiepTuc = true;

            while (tiepTuc)
            {
                consoleView.HienThiMenu();

                string luaChon = Console.ReadLine() ?? "";

                Console.Clear();

                switch (luaChon)
                {
                    case "1":
                        ThemSinhVien();
                        break;

                    case "2":
                        HienThiDanhSach();
                        break;

                    case "3":
                        TimSinhVienTheoMa();
                        break;

                    case "4":
                        TimGanDungTheoHoTen();
                        break;

                    case "5":
                        CapNhatSinhVien();
                        break;

                    case "6":
                        XoaSinhVien();
                        break;

                    case "7":
                        SapXepTheoTen();
                        break;

                    case "8":
                        SapXepTheoGPA();
                        break;

                    case "9":
                        LaySinhVienGPA_Tu8();
                        break;

                    case "10":
                        LaySinhVienGpaCaoNhat();
                        break;

                    case "11":
                        TinhGPATrungBinh();
                        break;

                    case "12":
                        ThongKeTheoNganh();
                        break;

                    case "13":
                        ThongKeTheoTrangThai();
                        break;

                    case "0":
                        tiepTuc = false;
                        consoleView.ThongBao("Da thoat chuong trinh!");
                        break;

                    default:
                        consoleView.ThongBao("Lua chon khong hop le!");
                        break;
                }

                if (tiepTuc)
                {
                    consoleView.DungManHinh();
                    Console.Clear();
                }
            }
        }

        // 1. Thêm sinh viên
        private void ThemSinhVien()
        {
            Console.WriteLine("========== THEM SINH VIEN ==========");

            Student sinhVien = consoleView.NhapSinhVien();

            // Kiểm tra dữ liệu
            if (!StudentValidator.KiemTraMaSV(sinhVien.maSV))
            {
                consoleView.ThongBao("Ma sinh vien khong duoc de trong!");
                return;
            }

            if (!StudentValidator.KiemTraHoTen(sinhVien.hoTen))
            {
                consoleView.ThongBao("Ho ten khong duoc de trong!");
                return;
            }

            if (!StudentValidator.KiemTraGPA(sinhVien.GPA))
            {
                consoleView.ThongBao("GPA phai nam trong khoang 0 den 10!");
                return;
            }

            if (!string.IsNullOrWhiteSpace(sinhVien.Email)
                && !StudentValidator.KiemTraEmail(sinhVien.Email))
            {
                consoleView.ThongBao("Email khong dung dinh dang!");
                return;
            }

            if (studentService.ThemSinhVien(sinhVien))
            {
                consoleView.ThongBao("Them sinh vien thanh cong!");
            }
            else
            {
                consoleView.ThongBao("Ma sinh vien da ton tai!");
                Student.DecreaseTotalStudents();
            }
        }

        // 2. Hiển thị danh sách
        private void HienThiDanhSach()
        {
            Console.WriteLine("========== DANH SACH SINH VIEN ==========");

            List<Student> danhSach =
                studentService.LayDanhSachSinhVien();

            consoleView.HienThiDanhSach(danhSach);
        }

        // 3. Tìm sinh viên theo mã
        private void TimSinhVienTheoMa()
        {
            Console.WriteLine("========== TIM SINH VIEN THEO MA ==========");

            string maSV = consoleView.NhapMaSV();

            Student? sinhVien =
                studentService.TimSinhVienTheoMa(maSV);

            if (sinhVien == null)
            {
                consoleView.ThongBao("Khong tim thay sinh vien!");
                return;
            }

            consoleView.HienThiSinhVien(sinhVien);
        }

        // 4. Tìm gần đúng theo họ tên
        private void TimGanDungTheoHoTen()
        {
            Console.WriteLine("========== TIM GAN DUNG THEO HO TEN ==========");

            string hoTen = consoleView.NhapHoTen();

            List<Student> danhSach =
                studentService.TimGanDungTheoHoTen(hoTen);

            if (danhSach.Count == 0)
            {
                consoleView.ThongBao("Khong tim thay sinh vien!");
                return;
            }

            consoleView.HienThiDanhSach(danhSach);
        }

        // 5. Cập nhật sinh viên
        private void CapNhatSinhVien()
        {
            Console.WriteLine("========== CAP NHAT SINH VIEN ==========");

            string maSV = consoleView.NhapMaSV();

            Student? sinhVien =
                studentService.TimSinhVienTheoMa(maSV);

            if (sinhVien == null)
            {
                consoleView.ThongBao("Khong tim thay sinh vien!");
                return;
            }

            Console.WriteLine("Nhap thong tin moi!");

            Student sinhVienMoi = consoleView.NhapSinhVien();

            if (!StudentValidator.KiemTraHoTen(sinhVienMoi.hoTen))
            {
                consoleView.ThongBao("Ho ten khong duoc de trong!");
                Student.DecreaseTotalStudents();
                return;
            }

            if (!StudentValidator.KiemTraGPA(sinhVienMoi.GPA))
            {
                consoleView.ThongBao("GPA phai nam trong khoang 0 den 10!");
                Student.DecreaseTotalStudents();
                return;
            }

            if (!string.IsNullOrWhiteSpace(sinhVienMoi.Email)
                && !StudentValidator.KiemTraEmail(sinhVienMoi.Email))
            {
                consoleView.ThongBao("Email khong dung dinh dang!");
                Student.DecreaseTotalStudents();
                return;
            }

            if (studentService.CapNhatSinhVien(maSV, sinhVienMoi))
            {
                consoleView.ThongBao("Cap nhat sinh vien thanh cong!");
            }

            // SinhVienMoi được tạo ra nên giảm lại TotalStudents
            Student.DecreaseTotalStudents();
        }

        // 6. Xóa sinh viên
        private void XoaSinhVien()
        {
            Console.WriteLine("========== XOA SINH VIEN ==========");

            string maSV = consoleView.NhapMaSV();

            Student? sinhVien =
                studentService.TimSinhVienTheoMa(maSV);

            if (sinhVien == null)
            {
                consoleView.ThongBao("Khong tim thay sinh vien!");
                return;
            }

            consoleView.HienThiSinhVien(sinhVien);

            Console.Write("Ban co chac muon xoa? (Y/N): ");
            string xacNhan = Console.ReadLine() ?? "";

            if (xacNhan.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                if (studentService.XoaSinhVien(maSV))
                {
                    consoleView.ThongBao("Xoa sinh vien thanh cong!");
                }
            }
            else
            {
                consoleView.ThongBao("Da huy thao tac xoa.");
            }
        }

        // 7. Sắp xếp theo họ tên
        private void SapXepTheoTen()
        {
            Console.WriteLine("========== SAP XEP THEO HO TEN ==========");

            List<Student> danhSach =
                studentService.SapXepTheoTen();

            consoleView.HienThiDanhSach(danhSach);
        }

        // 8. Sắp xếp theo GPA
        private void SapXepTheoGPA()
        {
            Console.WriteLine("========== SAP XEP THEO GPA ==========");

            List<Student> danhSach =
                studentService.SapXepTheoGPA();

            consoleView.HienThiDanhSach(danhSach);
        }

        // 9. Sinh viên có GPA từ 8 trở lên
        private void LaySinhVienGPA_Tu8()
        {
            Console.WriteLine("========== SINH VIEN GPA TU 8 TRO LEN ==========");

            List<Student> danhSach =
                studentService.LaySinhVienGPA_Tu8();

            consoleView.HienThiDanhSach(danhSach);
        }

        // 10. Sinh viên có GPA cao nhất
        private void LaySinhVienGpaCaoNhat()
        {
            Console.WriteLine("========== SINH VIEN GPA CAO NHAT ==========");

            List<Student> danhSach =
                studentService.LaySinhVienGpaCaoNhat();

            consoleView.HienThiDanhSach(danhSach);
        }

        // 11. Tính GPA trung bình
        private void TinhGPATrungBinh()
        {
            Console.WriteLine("========== GPA TRUNG BINH ==========");

            double GPA =
                studentService.TinhGPATrungBinh();

            Console.WriteLine($"GPA trung bình: {GPA:F2}");
        }

        // 12. Thống kê theo ngành
        private void ThongKeTheoNganh()
        {
            Console.WriteLine("========== THONG KE THEO NGANH ==========");

            Dictionary<string, int> thongKe =
                studentService.ThongKeTheoNganh();

            if (thongKe.Count == 0)
            {
                consoleView.ThongBao("Chua co sinh vien!");
                return;
            }

            foreach (var item in thongKe)
            {
                Console.WriteLine(
                    $"Ngành: {item.Key} - So sinh vien: {item.Value}");
            }
        }

        // 13. Thống kê theo trạng thái
        private void ThongKeTheoTrangThai()
        {
            Console.WriteLine("========== THONG KE TRANG THAI ==========");

            Dictionary<bool, int> thongKe =
                studentService.ThongKeTheoTrangThai();

            if (thongKe.Count == 0)
            {
                consoleView.ThongBao("Chua co sinh vien!");
                return;
            }

            foreach (var item in thongKe)
            {
                string trangThai =
                    item.Key ? "Đang học" : "Nghỉ học";

                Console.WriteLine(
                    $"{trangThai}: {item.Value} sinh viên");
            }
        }
    }
}