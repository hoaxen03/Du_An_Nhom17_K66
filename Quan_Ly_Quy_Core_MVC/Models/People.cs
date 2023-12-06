namespace Quan_Ly_Quy_Core_MVC.Models
{
    public abstract class People
    {
        string cccd;
        string hodem;
        string ten;
        string bietdanh;
        string email;
        string dienthoai;
        int tuoi;
        int tien;

        public string Cccd { get => cccd; set => cccd = value; }
        public string Hodem { get => hodem; set => hodem = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Bietdanh { get => bietdanh; set => bietdanh = value; }
        public string Email { get => email; set => email = value; }
        public string Dienthoai { get => dienthoai; set => dienthoai = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string Hovaten { get => $"{hodem} {ten}"; }
        public int Tien { get => tien; set => tien = value; }

        public People()
        {
        }

        public People(string _cccd, string _hodem, string _ten, string _bietdanh, string _email, string _dienthoai, int _tuoi, int _tien)
        {
            Cccd = _cccd;
            Hodem = _hodem;
            Ten = _ten;
            Bietdanh = _bietdanh;
            Email = _email;
            Dienthoai = _dienthoai;
            Tuoi = _tuoi;
            Tien = _tien;
        }

        public abstract string GetInfo();

    }
}
