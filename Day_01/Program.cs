using System;
using System.Collections.Generic;

namespace Day_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("HALO HALO CAC MOM");
            List<Student> students = new List<Student>()
            {
                new Student {maSV = "SV008", hoTen = "Nguyễn Thùy Chi ",
                    ngaySinh = new DateTime(2006, 06, 03),
                    gioiTinh = true, Email = "aaaa@gmail.com",
                    soDienThoai = "0456784377",nganhHoc = "CNTT",
                    GPA = 8.5,trangThai = true
                },
                new Student {maSV = "SV006", hoTen = "Nguyễn A Xỉn ",
                    ngaySinh = new DateTime(2006, 03, 06),
                    gioiTinh = true , Email = "xxxxx@gmail.com",
                    soDienThoai = "06771508",nganhHoc = "CNTT",
                    GPA = 6.0,trangThai = true
                }
            };
            StudentService service = new StudentService();
            StudentConsoleView view = new StudentConsoleView();
            string choice;
            do
            {
                menu();
                Console.Write("Nhập lựa chọn của bạn: ");
                choice = Console.ReadLine() ?? "";
                switch (choice)
                {
                    case "1":
                        ThemSinhVien( students, service, view);
                        break;
                    case "2":
                        HienThiDS(students,view);
                        break;
                    case "3":
                        TimSinhVienTheoMa(students, service, view);
                        break;
                    case "4":
                        TimGanDungTheoHoTen(students, service, view);
                        break;
                    case "5":
                        CapNhatSinhVien(students, service, view);
                        break;
                    case "6":
                        XoaSinhVien(students, service, view);
                        break;
                    case "7":
                        SapXepTheoHoTen( students,service,view);
                        break;
                    case "8":
                        SapXepTheoGPA(students, service, view);
                        break;
                    case "9":
                        DiemLonHon8(students, service, view);
                        break;
                    case "10":
                        SinhVienDiemCaoNhat(students, service, view);
                        break;
                    case "11":
                        DTB(students, service, view);
                        break;
                    case "12":
                        TKSVTheoNganh(students, service, view);
                        break;
                    case "13":
                        TKSVTheoTT(students, service, view);
                        break;
                    case "14":
                        Console.WriteLine(
                            "Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine(
                            "Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

                Console.WriteLine();
            } while (choice != "14");
        }


        /// <summary>
        /// MENU
        /// </summary>
        static void menu()
        {
            Console.WriteLine();
            Console.WriteLine(
                "========== CHỨC NĂNG ==========");
            Console.WriteLine("1.\tThem sinh vien.\r" +
                "\n2.\tHien thi danh sach.\r" +
                "\n3.\tTim sinh vien theo ma.\r" +
                "\n4.\tTim gan dung theo ho ten.\r" +
                "\n5.\tCap nhat sinh vien.\r" +
                "\n6.\tXoa sinh vien.\r" +
                "\n7.\tSắp xếp theo họ tên .\r" +
                "\n8.\tSắp xếp theo điểm trung bình .\r" +
                "\n9.\tHiển thị sinh viên có điểm từ 8 trở lên .\r" +
                "\n10.\tHiển thị sinh viên có điểm cao nhất .\r" +
                "\n11.\tTính điẻm trung bình toàn bộ nhân viên  .\r" +
                "\n12.\tThống kê sinh viên theo ngành  .\r" +
                "\n13.\tThống kê sinh viên theo trạng thái  .\r");

            Console.WriteLine("14.\tThoát chương trình.");

        }

        //static void ThemSinhVien( List<Student> students, StudentService service,StudentConsoleView view)
        //{
        //    Student student = view.NhapSinhVien();

        //    bool result = service.ThemSinhVien(students,student);

        //    Console.WriteLine($"Số sinh viên hiện tại trong List: {students.Count}");
        //}
        static void ThemSinhVien(List<Student> students,StudentService service,StudentConsoleView view)
        {
            Student student = view.NhapSinhVien();
            bool result = service.ThemSinhVien(students, student);
            if (result)
            {
                Console.WriteLine("Thêm thành công!");
            }
            else
            {
                Console.WriteLine("Thêm thất bại!");
            }

            Console.WriteLine($"Số sinh viên hiện tại trong List: {students.Count}");
        }

        // 2. HIỂN THỊ DANH SÁCH

        static void HienThiDS( List<Student> students,StudentConsoleView view)
        {
            view.HienThiBang(students);
        }

        // 3. TÌM SINH VIÊN THEO MÃ

        static void TimSinhVienTheoMa(List<Student> students, StudentService service, StudentConsoleView view)
        {
            string maSV =view.NhapMaSinhVien();

            Student? student = service.TimTheoMa(students, maSV);

            if (student == null)
            {
                Console.WriteLine(
                    "Không tìm thấy sinh viên!");
            }
            else
            {
                view.HienThiSinhVien(student);
            }
        }

        // 4. TÌM GẦN ĐÚNG THEO HỌ TÊN

        static void TimGanDungTheoHoTen(List<Student> students, StudentService service, StudentConsoleView view)
        {
            string keyword= view.NhapTuKhoa();

            List<Student> result =service.TimGanDungTheoTen( students,keyword);

            if (result.Count == 0)
            {
                Console.WriteLine(
                    "Không tìm thấy sinh viên phù hợp!");
            }
            else
            {
                view.HienThiBang(result);
            }
        }


        // 5. CẬP NHẬT SINH VIÊN

        static void CapNhatSinhVien(List<Student> students, StudentService service, StudentConsoleView view)

        {
            string maSV =view.NhapMaSinhVien();

            Student? student = service.TimTheoMa(students, maSV);

            if (student == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên!");
                return;
            }
            Console.WriteLine( "Nhập thông tin mới:");
            Console.Write("Họ tên: ");
            string hoTen =Console.ReadLine() ?? "";

            DateTime? ngaySinh =view.NhapNgaySinh();
            bool gioiTinh = view.NhapGioiTinh();

            Console.Write("Email: ");
            string? email =Console.ReadLine();

            Console.Write("Số điện thoại: ");
            string? soDienThoai =
                Console.ReadLine();

            Console.Write("Ngành học: ");
            string nganhHoc =Console.ReadLine() ?? "";

            double GPA = view.NhapGPA();

            bool trangThai =view.NhapTrangThai();

            service.CapNhatSinhVien(students, maSV, hoTen, ngaySinh, gioiTinh,email,soDienThoai, nganhHoc,
                GPA, trangThai);
        }


        // 6. XÓA SINH VIÊN

        static void XoaSinhVien(List<Student> students, StudentService service, StudentConsoleView view)
        {
            string maSV = view.NhapMaSinhVien();
            Student? student = service.TimTheoMa(students,maSV);
            if (student == null)
            {
                Console.WriteLine( "Không tìm thấy sinh viên!");
                return;
            }
            view.HienThiSinhVien(student);
            bool confirm = view.XacNhanXoa();

            if (confirm)
            {
                service.XoaSinhVien(students,maSV);
            }
            else
            {
                Console.WriteLine("Đã hủy thao tác xóa.");
            }
        }


        // 7. SẮP XẾP THEO HỌ TÊN

        static void SapXepTheoHoTen(List<Student> students, StudentService service, StudentConsoleView view)
        {
            service.SapXepTheoHoTen(students);
            view.HienThiBang(students);
        }

        // 8. SẮP XẾP THEO GPA

        static void SapXepTheoGPA(List<Student> students, StudentService service, StudentConsoleView view)
        {
            service.SapXepTheoGPA(students);
            view.HienThiBang(students);
        }

        // 9. SINH VIÊN GPA >= 8
        static void DiemLonHon8(List<Student> students, StudentService service, StudentConsoleView view)
        {
            List<Student> result =service.SinhVienGPA8TroLen(students);
            view.HienThiSinhVienGPA8TroLen(result);
        }

        // 10. SINH VIÊN GPA CAO NHẤT
        static void SinhVienDiemCaoNhat(List<Student> students, StudentService service, StudentConsoleView view)
        {
            List<Student> result =service.SinhVienDiemCaoNhat(students);
            view.HienThiSinhVienDiemCaoNhat(result);
        }

        // 11. TÍNH GPA TRUNG BÌNH
        static void DTB(List<Student> students, StudentService service, StudentConsoleView view)
        {
            double GPA =service.TinhDiemTrungBinh(students);
            view.HienThiDiemTrungBinh(GPA);
        }

        // 12. THỐNG KÊ THEO NGÀNH
        static void TKSVTheoNganh(List<Student> students, StudentService service, StudentConsoleView view)
        {
            Dictionary<string, int> result =service.ThongKeTheoNganh(students);
            Console.WriteLine();
            Console.WriteLine("===== THỐNG KÊ SINH VIÊN THEO NGÀNH =====");
            view.HienThiThongKe(result);
        }

        // 13. THỐNG KÊ THEO TRẠNG THÁI

        static void TKSVTheoTT(List<Student> students, StudentService service, StudentConsoleView view)
        {
            Dictionary<string, int> result =service.ThongKeTheoTrangThai(students);
            Console.WriteLine();
            Console.WriteLine("===== THỐNG KÊ SINH VIÊN THEO TRẠNG THÁI =====");
            view.HienThiThongKe(result);
        }
    }
}