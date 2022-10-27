using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using DTO;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_TongLuong
    {
        DAL_TongLuong dalTongLuong = new DAL_TongLuong();
        public DataTable GetAllTongLuong()
        {
            return dalTongLuong.GetALLTongLuong();
        }
        public bool InsertTongLuong(DTO_TongLuong tl)
        {
            return dalTongLuong.InsertTongLuong(tl);
        }
        public bool UpdateTongLuong(DTO_TongLuong tl)
        {
            return dalTongLuong.UpdateTongLuong(tl);
        }
        public SqlDataReader LoadTienThuong(string maNV, string ngayBatDau, DateTime ngayKetThuc)
        {
            return dalTongLuong.LoadTienThuong(maNV, ngayBatDau, ngayKetThuc);
        }
        public SqlDataReader LoadTienPhat(string maNV, string ngayBatDau, DateTime ngayKetThuc)
        {
            return dalTongLuong.LoadTienPhat(maNV, ngayBatDau, ngayKetThuc);
        }
        public SqlDataReader LoadTienBH(string maNV)
        {
            return dalTongLuong.LoadTienBH(maNV);
        }
        public SqlDataReader LoadNgayLamViec(string maNV, string ngayBatDau, DateTime ngayKetThuc)
        {
            return dalTongLuong.LoadNgayLamViec(maNV, ngayBatDau, ngayKetThuc);
        }
        //public bool CheckNVThaiSan(string maNV, string ngayBatDau, string ngayKetThuc)
        //{
        //    return dalTongLuong.CheckNVThaiSan(maNV, ngayBatDau, ngayKetThuc);
        //}
    }
}
