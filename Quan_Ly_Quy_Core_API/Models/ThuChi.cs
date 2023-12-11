namespace Quan_Ly_Quy_Core_API.Models
{
    public class ThuChi
    {
        int id; 
        string tenKhoanChi;//tên khoản cần chi
        string Loai;//Phân Loại
        double soTien;//số tiền cân chi
        int ngayChi;//ngày chi 
        int namChi;//năm chi

        public ThuChi()
        {

        }
        public int Id { get => id; set => id = value; }
        public string TenKhoanChi { get => tenKhoanChi; set => tenKhoanChi = value; }
        public double SoTien { get => soTien; set => soTien = value; }
        public int NgayChi { get => ngayChi; set => ngayChi = value; }
        public int NamChi { get => namChi; set => namChi = value; }
        public string Loai1 { get => Loai; set => Loai = value; }
    }
}
