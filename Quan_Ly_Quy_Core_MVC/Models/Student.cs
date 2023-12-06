using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Quan_Ly_Quy_Core_MVC.Models
{
    public class Student : People
    {
        string msv; // 221070001 (22 năm | 107 mã ngành | 0001 số thứ tự nhập học)
        string lop; // 66A-HTTT, 66B-HTTT
        string khoavien; // Khoa Cơ điện Công trình

        public string Msv { get => msv; set => msv = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Khoavien { get => khoavien; set => khoavien = value; }

        public Student()
        {
        }

        public Student(
            string _msv, string _lop, string _khoavien,
            string _cccd, string _hodem, string _ten, string _bietdanh, string _email, string _dienthoai, int _tuoi ,int _tien) : base(_cccd, _hodem, _ten, _bietdanh, _email, _dienthoai, _tuoi,_tien)
        {
            this.Msv = _msv;
            this.Lop = _lop;
            this.Khoavien = _khoavien;
            this.Cccd = _cccd;
            this.Hodem = _hodem;
            this.Ten = _ten;
            this.Bietdanh = _bietdanh;
            this.Email = _email;
            this.Dienthoai = _dienthoai;
            this.Tuoi = _tuoi;
            this.Tien = _tien;
        }

        static List<Student> ds_sinhvien = new List<Student>
            {
                 new Student{
                          Msv         = "221070002"   ,
                          Lop         = "66-HTTT"     ,
                          Khoavien    = "Khoa CĐCT"   ,
                          Cccd        = "0011234534"  ,
                          Hodem       = "Nguyễn Văn"  ,
                          Ten         = "ABCXYZ"      ,
                          Bietdanh    = "ABCXYZ"      ,
                          Email       = "abc@demo.com",
                          Dienthoai   = "0979xxxx222" ,
                          Tuoi        = 20,
                          Tien        = 500000
                     },

            };

        public override string GetInfo()
        {
            return $"{Msv} - {Hodem} {Ten}";
        }
    }
}
