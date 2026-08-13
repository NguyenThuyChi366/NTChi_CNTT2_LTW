using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_01
{
    internal class StudentValidator
    {        public bool KiemTraMaSV(List<Student> students,string maSV)
        {
            foreach (Student sv in students)
            {
                if (sv.maSV.Equals(maSV,StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }

        public bool KiemTraHoTen(string hoTen)
        {
            return !string.IsNullOrWhiteSpace(hoTen);
        }
        public bool KiemTraGPA(double GPA)
        {
            return GPA >= 0 && GPA <= 10;
        }
        public bool KiemTraEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email khong dung dinh dang!");
                return false ;
            }

            string pattern =@"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}