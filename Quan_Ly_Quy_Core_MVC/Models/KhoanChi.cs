namespace Quan_Ly_Quy_Core_API.Models
{
    public class KhoanChi
    {
        int id;
        string tenKhoanChi;//tên khoản cần chi
        int soLuongChi;//số lượng cần chi
        double soTienCanChi;//số tiền cân chi
        int ngayChi;//ngày chi 
        int namChi;//năm chi
        public int Id { get => id; set => id = value; }
        public string TenKhoanChi { get => tenKhoanChi; set => tenKhoanChi = value; }
        public int SoLuongChi { get => soLuongChi; set => soLuongChi = value; }
        public double SoTienCanChi { get => soTienCanChi; set => soTienCanChi = value; }
        public int NgayChi { get => ngayChi; set => ngayChi = value; }
        public int NamChi { get => namChi; set => namChi = value; }


        public KhoanChi()
        {

        }
        public KhoanChi(int _id, string _tenKhoanChi, int _soLuongChi, double _soTienCanChi, int _ngayChi, int _namChi)
        {
            Id = _id;
            TenKhoanChi = _tenKhoanChi;
            SoLuongChi = _soLuongChi;
            SoTienCanChi = _soTienCanChi;
            NgayChi = _ngayChi;
            NamChi = _namChi;
        }
        static List<KhoanChi> ds_KhoanChi = new List<KhoanChi>
            {
                 new KhoanChi{
                          Id          = 01   ,
                          TenKhoanChi = "Kỉ Yếu"      ,
                          SoLuongChi  = 1,
                          SoTienCanChi = 10000000,
                          NgayChi      = 2,
                          NamChi       = 2023,
                     },

            };

    }
}
