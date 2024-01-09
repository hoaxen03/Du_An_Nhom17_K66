using System.Globalization;

namespace Quan_Ly_Quy_Core_API.Models
{
    public class ThuChi
    {
        int id;
        string tenKhoanChi;//tên khoản cần chi
        string loai;
        double soTien;//số tiền cân chi
        DateTime ngayChi;//ngày chi 
        public int Id { get => id; set => id = value; }
        public string TenKhoanChi { get => tenKhoanChi; set => tenKhoanChi = value; }
        public DateTime NgayChi { get => ngayChi; set => ngayChi = value; }
        public string Loai { get => loai; set => loai = value; }
        public double SoTien { get => soTien; set => soTien = value; }

        public ThuChi()
        {

        }
        public ThuChi(int _id, string _tenKhoanChi, double _soTien, DateTime _ngayChi,string _loai)
        {
            Id = _id;
            TenKhoanChi = _tenKhoanChi;
            SoTien = _soTien;
            NgayChi = _ngayChi;
            Loai = _loai;
        }
        static List<ThuChi> ds_ThuChi = new List<ThuChi>
            {
                 new ThuChi{
                          Id          = 01   ,
                          TenKhoanChi = "Kỉ Yếu"      ,
                          Loai = "Chi",
                          SoTien = 10000000,
                          NgayChi      = DateTime.ParseExact("8/3/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                     },

            };

    }
}
