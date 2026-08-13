using System;
using System.Collections.Generic;
using System.Text;

namespace Day_01
{
    /// <summary>
    /// class: student
    /// Author: Nguyễn Thùy Chi
    /// </summary>
    internal class Student
    {
        public static int TotalStudents { get; private set; } = 0;

        // Properties
        public string maSV { get; set; }
        public string hoTen { get; set; }
        public DateTime? ngaySinh { get; set; }
        public bool gioiTinh { get; set; }
        public string? Email { get; set; }
        public string? soDienThoai { get; set; }
        public string nganhHoc { get; set; }
        public double GPA { get; set; }
        public bool trangThai { get; set; }
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
