using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_01
{
    /// <summary>
    /// Class StudentService
    /// Xử lý các nghiệp vụ liên quan đến sinh viên
    /// </summary>
    internal class StudentService
    {
        private StudentValidator validator;

        // Constructor
        public StudentService()
        {
            validator = new StudentValidator();
        }
        // 1. THÊM SINH VIÊN
        public bool ThemSinhVien(List<Student> students,Student student)
        {
            if (!validator.KiemTraMaSV(students,student.maSV))
            {
                Console.WriteLine("Mã sinh viên đã tồn tại!");
                return false;
            }
            if (!validator.KiemTraHoTen(student.hoTen))
            {
                Console.WriteLine("Họ tên không được để trống!");
                return false;
            }

            if (!validator.KiemTraGPA(student.GPA))
            {
                Console.WriteLine("GPA phải nằm trong khoảng từ 0 đến 10!");
                return false;
            }

            if (!validator.KiemTraEmail(student.Email))
            {
                Console.WriteLine("Email không đúng định dạng!");
                return false;
            }

            students.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
            return true;
        }

        // 2. HIỂN THỊ DANH SÁCH SINH VIÊN
        public void HienThiDanhSach(
            List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên đang trống!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("DANH SÁCH SINH VIÊN");
            Console.WriteLine(new string('-', 120));
            foreach (Student sv in students)
            {
                Console.WriteLine($"Mã SV: {sv.maSV}");
                Console.WriteLine($"Họ tên: {sv.hoTen}");
                Console.WriteLine($"Ngày sinh: " +$"{sv.ngaySinh?.ToString("dd/MM/yyyy") ?? "Chưa có"}");
                Console.WriteLine($"Giới tính: " +$"{(sv.gioiTinh ? "Nam" : "Nữ")}");
                Console.WriteLine($"Email: {sv.Email ?? "Chưa có"}");
                Console.WriteLine($"Số điện thoại: " +$"{sv.soDienThoai ?? "Chưa có"}");
                Console.WriteLine($"Ngành học: {sv.nganhHoc}");
                Console.WriteLine($"GPA: {sv.GPA:F2}");
                Console.WriteLine($"Trạng thái: " +$"{(sv.trangThai ? "Đang học" : "Đã nghỉ")}");
                Console.WriteLine(new string('-', 120));
            }
        }


        // 3. TÌM SINH VIÊN THEO MÃ
        public Student? TimTheoMa(List<Student> students,string maSV)
        {
            foreach (Student sv in students)
            {
                if (sv.maSV.Equals(maSV,StringComparison.OrdinalIgnoreCase))
                {
                    return sv;
                }
            }
            return null;
        }
        // 4. TÌM GẦN ĐÚNG THEO HỌ TÊN
        public List<Student> TimGanDungTheoTen(List<Student> students,string keyword)
        {
            List<Student> result =
                new List<Student>();
            foreach (Student sv in students)
            {
                if (sv.hoTen.Contains(keyword,StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(sv);
                }
            }
            return result;
        }

        // 5. CẬP NHẬT SINH VIÊN
        public bool CapNhatSinhVien(List<Student> students,string maSV,string hoTen,
            DateTime? ngaySinh,bool gioiTinh,string? email,string? soDienThoai,
            string nganhHoc,double GPA,bool trangThai)
        {
            Student? student =TimTheoMa(students, maSV);
            if (student == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên cần cập nhật!");
                return false;
            }
            if (!validator.KiemTraHoTen(hoTen))
            {
                Console.WriteLine("Họ tên không được để trống!");
                return false;
            }
            if (!validator.KiemTraGPA(GPA))
            {
                Console.WriteLine("GPA phải nằm trong khoảng từ 0 đến 10!");
                return false;
            }
            if (!validator.KiemTraEmail(email))
            {
                Console.WriteLine("Email không đúng định dạng!");
                return false;
            }

            student.hoTen = hoTen;
            student.ngaySinh = ngaySinh;
            student.gioiTinh = gioiTinh;
            student.Email = email;
            student.soDienThoai = soDienThoai;
            student.nganhHoc = nganhHoc;
            student.GPA = GPA;
            student.trangThai = trangThai;
            Console.WriteLine("Cập nhật sinh viên thành công!");
            return true;
        }

        // 6. XÓA SINH VIÊN
        public bool XoaSinhVien(List<Student> students,string maSV)
        {
            Student? student =TimTheoMa(students, maSV);
            if (student == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên cần xóa!");
                return false;
            }
            students.Remove(student);
            Student.DecreaseTotalStudents();
            Console.WriteLine("Xóa sinh viên thành công!");
            return true;
        }

        // 7. SẮP XẾP THEO HỌ TÊN
        public void SapXepTheoHoTen(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên đang trống!");
                return;
            }

            students.Sort((sv1, sv2) =>string.Compare(sv1.hoTen,sv2.hoTen,StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Đã sắp xếp sinh viên theo họ tên!");
        }

        // 8. SẮP XẾP THEO ĐIỂM TRUNG BÌNH
        public void SapXepTheoGPA(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên đang trống!");
                return;
            }
            students.Sort((sv1, sv2) =>sv2.GPA.CompareTo(sv1.GPA));
            Console.WriteLine("Đã sắp xếp sinh viên theo GPA giảm dần!");
        }

        // 9. HIỂN THỊ SINH VIÊN CÓ GPA TỪ 8 TRỞ LÊN
        public List<Student> SinhVienGPA8TroLen(List<Student> students)
        {
            List<Student> result =new List<Student>();
            foreach (Student sv in students)
            {
                if (sv.GPA >= 8)
                {
                    result.Add(sv);
                }
            }
            return result;
        }

        // 10. HIỂN THỊ SINH VIÊN CÓ GPA CAO NHẤT
        public List<Student> SinhVienDiemCaoNhat(List<Student> students)
        {
            List<Student> result =new List<Student>();
            if (students.Count == 0)
            {
                return result;
            }
            double maxGPA =
                students.Max(sv => sv.GPA);
            foreach (Student sv in students)
            {
                if (sv.GPA == maxGPA)
                {
                    result.Add(sv);
                }
            }
            return result;
        }


        // 11. TÍNH ĐIỂM TRUNG BÌNH TOÀN BỘ SINH VIÊN
        public double TinhDiemTrungBinh(List<Student> students)
        {
            if (students.Count == 0)
            {
                return 0;
            }
            double tongGPA = 0;
            foreach (Student sv in students)
            {
                tongGPA += sv.GPA;
            }
            return tongGPA / students.Count;
        }

        // 12. THỐNG KÊ SINH VIÊN THEO NGÀNH
        public Dictionary<string, int> ThongKeTheoNganh(List<Student> students)
        {
            Dictionary<string, int> result =new Dictionary<string, int>();
            foreach (Student sv in students)
            {
                string nganh = sv.nganhHoc;
                if (result.ContainsKey(nganh))
                {
                    result[nganh]++;
                }
                else
                {
                    result.Add(nganh, 1);
                }
            }
            return result;
        }

        // 13. THỐNG KÊ SINH VIÊN THEO TRẠNG THÁI
        public Dictionary<string, int> ThongKeTheoTrangThai(List<Student> students)
        {
            Dictionary<string, int> result =new Dictionary<string, int>();

            foreach (Student sv in students)
            {
                string trangThai;
                if (sv.trangThai)
                {
                    trangThai = "Đang học";
                }
                else
                {
                    trangThai = "Đã nghỉ";
                }

                if (result.ContainsKey(trangThai))
                {
                    result[trangThai]++;
                }
                else
                {
                    result.Add(trangThai, 1);
                }
            }
            return result;
        }
    }
}
