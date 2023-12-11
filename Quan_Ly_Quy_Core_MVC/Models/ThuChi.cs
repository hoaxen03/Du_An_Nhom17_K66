﻿namespace Quan_Ly_Quy_Core_API.Models
{
    public class ThuChi
    {
        int id;
        string tenKhoanChi;//tên khoản cần chi
        string Loai;
        double soTien;//số tiền cân chi
        int ngayChi;//ngày chi 
        int namChi;//năm chi
        public int Id { get => id; set => id = value; }
        public string TenKhoanChi { get => tenKhoanChi; set => tenKhoanChi = value; }
        public int NgayChi { get => ngayChi; set => ngayChi = value; }
        public int NamChi { get => namChi; set => namChi = value; }
        public string Loai1 { get => Loai; set => Loai = value; }
        public double SoTien { get => soTien; set => soTien = value; }

        public ThuChi()
        {

        }
        public ThuChi(int _id, string _tenKhoanChi, double _soTien, int _ngayChi, int _namChi)
        {
            Id = _id;
            TenKhoanChi = _tenKhoanChi;
            SoTien = _soTien;
            NgayChi = _ngayChi;
            NamChi = _namChi;
        }
        static List<ThuChi> ds_ThuChi = new List<ThuChi>
            {
                 new ThuChi{
                          Id          = 01   ,
                          TenKhoanChi = "Kỉ Yếu"      ,
                          Loai1 = "Chi",
                          SoTien = 10000000,
                          NgayChi      = 2,
                          NamChi       = 2023,
                     },

            };

    }
}