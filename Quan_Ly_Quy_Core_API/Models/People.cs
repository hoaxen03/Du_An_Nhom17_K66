namespace Quan_Ly_Quy_Core_API.Models
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

        public string Cccd { get => cccd; set => cccd = value; }
        public string Hodem { get => hodem; set => hodem = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Bietdanh { get => bietdanh; set => bietdanh = value; }
        public string Email { get => email; set => email = value; }
        public string Dienthoai { get => dienthoai; set => dienthoai = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }

        public string Hovaten { get => $"{hodem} {ten}"; }



        public People()
        {
        }

        public People(string _cccd, string _hodem, string _ten, string _bietdanh, string _email, string _dienthoai, int _tuoi)
        {
            this.Cccd = _cccd;
            this.Hodem = _hodem;
            this.Ten = _ten;
            this.Bietdanh = _bietdanh;
            this.Email = _email;
            this.Dienthoai = _dienthoai;
            this.Tuoi = _tuoi;
        }

        public abstract string GetInfo();
    }
}
