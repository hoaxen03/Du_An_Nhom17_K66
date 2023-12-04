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

        public KhoanChi()
        {

        }
        public int Id { get => id; set => id = value; }
        public string TenKhoanChi { get => tenKhoanChi; set => tenKhoanChi = value; }
        public int SoLuongChi { get => soLuongChi; set => soLuongChi = value; }
        public double SoTienCanChi { get => soTienCanChi; set => soTienCanChi = value; }
        public int NgayChi { get => ngayChi; set => ngayChi = value; }
        public int NamChi { get => namChi; set => namChi = value; }

    }
}
