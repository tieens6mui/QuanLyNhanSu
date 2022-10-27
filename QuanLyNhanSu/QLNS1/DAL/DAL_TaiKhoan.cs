using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        //Lấy dữ liệu hiển thị
        public DataTable GetData()
        {
            DataTable dt = DataConnection.Instance.ExecuteQuery("select UserName, DisplayName, Type from Account");
            return dt;
        }
        // Lấy thông tin tài khoản username
        public DTO_Accounts GetAccountByUserName(string userName)
        {
            DataTable data = DataConnection.Instance.ExecuteQuery("select * from Account where UserName = '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new DTO_Accounts(item);
            }
            return null;
        }
        // Lấy dữ liệu Account
        public DataTable GetListAccount()
        {
            return DataConnection.Instance.ExecuteQuery("select * from Account");
        }

        // Code sử lý đổi thông tin và mật khẩu
        public bool ChangeAccount(string username, string displayname, string password, string newpassword)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hastable = new MD5CryptoServiceProvider().ComputeHash(temp);
            string haspass = "";
            foreach (byte item in hastable)
            {
                haspass += item;
            }
            int result = DataConnection.Instance.ExecuteNonQuery("exec sp_ChangeAccount @username , @displayname , @password , @newpassword "
                                                                    , new object[] { username, displayname, Encript(password), Encript(newpassword) });
            return result > 0;
        }
        string Encript(string password)
        {
            string haspass = "";
            if (password == "")
            {
                return haspass;
            }
            else
            {
                byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
                byte[] hastable = new MD5CryptoServiceProvider().ComputeHash(temp);
                foreach (byte item in hastable)
                {
                    haspass += item;
                }
                return haspass;
            }
        }
        // Code sử lý đăng nhập và mã hóa mật khẩu
        public bool Login(string UserName, string Password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(Password);
            byte[] hastable = new MD5CryptoServiceProvider().ComputeHash(temp);
            string haspass = "";
            foreach (byte item in hastable)
            {
                haspass += item;
            }
            string query = " sp_LogintAccount @username , @password";
            DataTable result = DataConnection.Instance.ExecuteQuery(query, new object[] { UserName, haspass });
            return result.Rows.Count > 0;
        }
        // code sử lý thêm tài khoản
        public bool InsertAccount(DTO_Accounts ac)
        {
            string query = string.Format("insert into Account(UserName, DisplayName, Type)values(N'{0}', N'{1}', {2})", ac.UserName, ac.DisplayName, ac.Type);
            int result = DataConnection.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        // code sử lý sửa tài khoản
        public bool UpdateAccount(DTO_Accounts ac)
        {
            string query = string.Format("update Account set DisplayName= N'{0}', Type={1} where UserName='{2}'", ac.DisplayName, ac.Type, ac.UserName);
            int result = DataConnection.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        // code sử lý xóa tài khoản 
        public bool DeleteAccount(string username)
        {
            string query = string.Format("delete Account where UserName=N'{0}'", username);
            int result = DataConnection.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        // code check Account với UserName truyền vào
        public bool CheckAccount(string userName)
        {
            string query = string.Format($"select * from Account where UserName = N'{userName}'");
            return DataConnection.Instance.CheckExist(query);
        }
    }
}
