using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
   public class DAL_TongLuong
    {
        public DataTable GetALLTongLuong()
        {
            DataTable dt = DataConnection.Instance.ExecuteQuery("select * from TongLuong");
            return dt;
        }

        // lay thong tin nhan vien thong qua tai khoan
        public bool InsertTongLuong(DTO_TongLuong tl)
        {
            string query = string.Format($"insert into TongLuong(MaNV,TenNV,TuNgay,DenNgay,SoNgayCong,LuongCB,TongPhiBH,TongTienThuong,TongTienPhat,TongLuong)values(N'{tl.MaNV}',N'{tl.TenNV}', '{tl.TuNgay}', '{tl.DenNgay}',{tl.SoNgayCong},{tl.LuonngCB},{tl.TongBaoHiem},{tl.TongTienThuong},{tl.TongTienPhat},{tl.TongLuong})");
            int result = DataConnection.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //code sửa Nhân Viên
        public bool UpdateTongLuong(DTO_TongLuong tl)
        {
            string query = string.Format($"update TongLuong set  TenNV='{tl.TenNV}', TuNgay = '{tl.TuNgay}', DenNgay = '{tl.DenNgay}', SoNgayCong={tl.SoNgayCong}, LuongCB={tl.LuonngCB}, PhiBaoHiem={tl.TongBaoHiem},TienThuong ={tl.TongTienThuong},TongTienPhat={tl.TongTienPhat},TongTien={tl.TongLuong} where maNV='{tl.MaNV}'");
            int result = DataConnection.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        // code load data tổng tiền thưởng
        public SqlDataReader LoadTienThuong(string maNV, string ngayBatDau, DateTime ngayKetThuc)
        {
            string query = string.Format($"select SUM(TienThuong) from DSKhenThuong where MaNV = '{maNV}' and NgayThuong between DATEADD(day, 0, '{ngayBatDau} 00:00:00') and '{ngayKetThuc}' ");
            return DataConnection.Instance.LoadData(query);
        }
        // code load data tổng tiền phạt
        public SqlDataReader LoadTienPhat(string maNV, string ngayBatDau, DateTime ngayKetThuc)
        {
            string query = string.Format($"select SUM(TienPhat) from DSKyLuat where MaNV = '{maNV}' and NgayKyLuat between DATEADD(day, 0, '{ngayBatDau} 00:00:00') and '{ngayKetThuc}' ");
            return DataConnection.Instance.LoadData(query);
        }
        // code load data tổng tiền bảo hiểm
        public SqlDataReader LoadTienBH(string maNV)
        {
            string query = string.Format($"select SUM(PhiBaoHiem) from DSBaoHiem where MaNV = '{maNV}'");
            return DataConnection.Instance.LoadData(query);
        }
        // code load data số ngày làm việc
        public SqlDataReader LoadNgayLamViec(string maNV, string ngayBatDau, DateTime ngayKetThuc)
        {
            string query = string.Format($"select count(MaNV) from ChamCong where MaNV = '{maNV}'and NgayCham between DATEADD(day, 0, '{ngayBatDau} 00:00:00') and '{ngayKetThuc}'");
            return DataConnection.Instance.LoadData(query);
        }
        // code check nhân viên thai sản
        //public bool CheckNVThaiSan(string maNV, string ngayBatDau, string ngayKetThuc)
        //{
        //    string query = string.Format($"exec sp_CheckNVThaiSan '{maNV}', '{ngayBatDau}', '{ngayKetThuc}'");
        //    return DataConnection.Instance.CheckExist(query);
        //}
    }
}

