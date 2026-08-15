using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace tdkhoa_day1
{
    internal class StudentValidator
    {
        // Kiểm tra mã sinh viên
        public static bool KiemTraMaSV(string? maSV)
        {
            return !string.IsNullOrWhiteSpace(maSV);
        }

        // Kiểm tra họ tên
        public static bool KiemTraHoTen(string? hoTen)
        {
            return !string.IsNullOrWhiteSpace(hoTen);
        }

        // Kiểm tra GPA từ 0 đến 10
        public static bool KiemTraGPA(double GPA)
        {
            return GPA >= 0 && GPA <= 10;
        }

        // Kiểm tra Email
        public static bool KiemTraEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}