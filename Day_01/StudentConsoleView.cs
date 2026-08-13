using System;
using System.Collections.Generic;

namespace Day_01
{
    internal class StudentConsoleView
    {
        // 1. NHẬP THÔNG TIN SINH VIÊN
        public Student NhapSinhVien()
        {
            Student student = new Student();
            Console.WriteLine();
            Console.WriteLine("========== NHẬP THÔNG TIN SINH VIÊN ==========");
            Console.Write("Mã sinh viên: ");
            student.maSV = Console.ReadLine() ?? "";

            Console.Write("Họ tên: ");
            student.hoTen = Console.ReadLine() ?? "";

            student.ngaySinh = NhapNgaySinh();
            student.gioiTinh = NhapGioiTinh();
            Console.Write("Email: ");
            student.Email = Console.ReadLine();
            Console.Write("Số điện thoại: ");
            student.soDienThoai = Console.ReadLine();
            Console.Write("Ngành học: ");
            student.nganhHoc = Console.ReadLine() ?? "";
            student.GPA = NhapGPA();
            student.trangThai = NhapTrangThai();
            return student;
        }

        // 2. NHẬP NGÀY SINH
        public DateTime? NhapNgaySinh()
        {
            while (true)
            {
                Console.Write("Ngày sinh (dd/MM/yyyy, Enter để bỏ qua): ");
                string input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }

                if (DateTime.TryParseExact(input,"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out DateTime ngaySinh))
                {
                    return ngaySinh;
                }

                Console.WriteLine("Ngày sinh không hợp lệ!");
            }
        }

        // 3. NHẬP GIỚI TÍNH
        public bool NhapGioiTinh()
        {
            while (true)
            {
                Console.Write(
                    "Giới tính (1 - Nam, 0 - Nữ): ");
                string input = Console.ReadLine() ?? "";
                if (input == "1")
                {
                    return true;
                }

                if (input == "0")
                {
                    return false;
                }

                Console.WriteLine("Vui lòng nhập 1 hoặc 0!");
            }
        }

        // 4. NHẬP GPA
        public double NhapGPA()
        {
            while (true)
            {
                Console.Write("Điểm trung bình GPA: ");
                string input = Console.ReadLine() ?? "";
                if (double.TryParse(input,out double GPA))
                {
                    if (GPA >= 0 && GPA <= 10)
                    {
                        return GPA;
                    }
                }
                Console.WriteLine("GPA phải nằm trong khoảng từ 0 đến 10!");
            }
        }

        // 5. NHẬP TRẠNG THÁI
        public bool NhapTrangThai()
        {
            while (true)
            {
                Console.Write("Trạng thái (1 - Đang học, 0 - Đã nghỉ): ");
                string input = Console.ReadLine() ?? "";
                if (input == "1")
                {
                    return true;
                }

                if (input == "0")
                {
                    return false;
                }
                Console.WriteLine("Vui lòng nhập 1 hoặc 0!");
            }
        }


        // 6. HIỂN THỊ MỘT SINH VIÊN
        public void HienThiSinhVien(Student student)
        {
            Console.WriteLine();
            Console.WriteLine(
                "========== THÔNG TIN SINH VIÊN ==========");
            Console.WriteLine($"Mã sinh viên: {student.maSV}");
            Console.WriteLine($"Họ tên: {student.hoTen}");
            Console.WriteLine($"Ngày sinh: " +$"{student.ngaySinh?.ToString("dd/MM/yyyy") ?? "Chưa có"}");
            Console.WriteLine($"Giới tính: " +$"{(student.gioiTinh ? "Nam" : "Nữ")}");
            Console.WriteLine($"Email: " +$"{student.Email ?? "Chưa có"}");
            Console.WriteLine($"Số điện thoại: " +$"{student.soDienThoai ?? "Chưa có"}");
            Console.WriteLine($"Ngành học: {student.nganhHoc}");
            Console.WriteLine($"GPA: {student.GPA:F2}");
            Console.WriteLine($"Trạng thái: " +$"{(student.trangThai ? "Đang học" : "Đã nghỉ")}");
            Console.WriteLine("==========================================");
        }


        // 7. HIỂN THỊ DANH SÁCH SINH VIÊN
        public void HienThiDanhSach(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên đang trống!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("================ DANH SÁCH SINH VIÊN ================");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"STT: {i + 1}");
                HienThiSinhVien(students[i]);
                Console.WriteLine();
            }
        }

        // 8. HIỂN THỊ DANH SÁCH DẠNG BẢNG
        public void HienThiBang(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên đang trống!");
                return;
            }
            Console.WriteLine();
            Console.WriteLine($"{"STT",-5}" +$"{"Mã SV",-12}" +$"{"Họ tên",-25}" +$"{"Ngày sinh",-15}" +$"{"Giới tính",-12}" +$"{"Ngành",-15}" +$"{"GPA",-8}" +$"{"Trạng thái",-15}");

            Console.WriteLine(new string('-', 107));
            for (int i = 0; i < students.Count; i++)
            {
                Student sv = students[i];
                string ngaySinh =sv.ngaySinh?.ToString("dd/MM/yyyy")?? "N/A";
                string gioiTinh =sv.gioiTinh? "Nam": "Nữ";
                string trangThai =sv.trangThai? "Đang học": "Đã nghỉ";
                Console.WriteLine($"{i + 1,-5}" +$"{sv.maSV,-12}" +$"{sv.hoTen,-25}" +$"{ngaySinh,-15}" +$"{gioiTinh,-12}" +$"{sv.nganhHoc,-15}" +$"{sv.GPA,-8:F2}" +$"{trangThai,-15}");
            }

            Console.WriteLine(new string('-', 107));
        }


        // 9. HIỂN THỊ THÔNG BÁO
        public void HienThiThongBao(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
        }
    
        // 10. NHẬP MÃ SINH VIÊN
        public string NhapMaSinhVien()
        {
            Console.Write("Nhập mã sinh viên: ");

            return Console.ReadLine() ?? "";
        }


        // 11. NHẬP TỪ KHÓA TÌM KIẾM
        public string NhapTuKhoa()
        {
            Console.Write("Nhập từ khóa họ tên: ");
            return Console.ReadLine() ?? "";
        }


        // 12. HIỂN THỊ DANH SÁCH GPA >= 8
        public void HienThiSinhVienGPA8TroLen(List<Student> students)
        {
            Console.WriteLine();
            Console.WriteLine("========== SINH VIÊN CÓ GPA TỪ 8 TRỞ LÊN ==========");
            if (students.Count == 0)
            {
                Console.WriteLine("Không có sinh viên nào có GPA từ 8 trở lên.");
                return;
            }

            HienThiBang(students);
        }


        // 13. HIỂN THỊ SINH VIÊN GPA CAO NHẤT
        public void HienThiSinhVienDiemCaoNhat(List<Student> students)
        {
            Console.WriteLine();
            Console.WriteLine("========== SINH VIÊN CÓ GPA CAO NHẤT ==========");

            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên đang trống!");
                return;
            }

            HienThiBang(students);
        }

        // 14. HIỂN THỊ GPA TRUNG BÌNH
        public void HienThiDiemTrungBinh(double GPA)
        {
            Console.WriteLine();
            Console.WriteLine($"Điểm trung bình của toàn bộ sinh viên: {GPA:F2}");
        }

        // 15. HIỂN THỊ THỐNG KÊ THEO NGÀNH
        public void HienThiThongKe(Dictionary<string, int> statistics)
        {
            if (statistics.Count == 0)
            {
                Console.WriteLine("Chưa có dữ liệu thống kê!");
                return;
            }

            foreach (var item in statistics)
            {
                Console.WriteLine(
                    $"{item.Key}: {item.Value} sinh viên");
            }
        }

        // 16. XÁC NHẬN XÓA
        public bool XacNhanXoa()
        {
            Console.Write("Bạn có chắc chắn muốn xóa? (Y/N): ");

            string input =Console.ReadLine() ?? "";

            return input.Equals("Y",StringComparison.OrdinalIgnoreCase);
        }
    }
}