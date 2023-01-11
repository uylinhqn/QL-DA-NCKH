using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
namespace AppPhucVinhTuanKiet.Models
{
    public class encrypts
    {
        public encrypts()
        {

        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.
        (com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";

            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);

            bool valid = false;
            if (string.IsNullOrEmpty(email))
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(email);
            }
            return valid;
        }
        public string Encrypt(string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);
                if (VerifyMd5Hash(md5Hash, source, hash))
                    return hash;
                else
                    return null;
            }
        }
        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
                return true;
            else
                return false;
        }
        private static Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //Connectionmd db = new Connectionmd();
        //public DataTable LaySoLieuMDMSPQ(string MaDiemDo,DateTime Ngay, DateTime Ngay1)
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection SqlCnn = db.ReadFromWebConfig();
        //    SqlDataAdapter SqlAdp = new SqlDataAdapter();
        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlTransaction SqlTrans = SqlCnn.BeginTransaction();
        //    try
        //    {
        //        SqlCmd.Transaction = SqlTrans;
        //        SqlCmd.Connection = SqlCnn;
        //        SqlCmd.CommandText = "SELECT distinct [MA_DIEMDO],[NGAYGIO],[IMPBT],[IMPCD],[IMPTD],[EXPBT],[EXPCD],[EXPTD],[AP_T],[RP_T] FROM [DSPMHTai].[dbo].[IMIS_Vcumvals] WHERE [MA_DIEMDO] ='" + MaDiemDo+ "' AND [NGAYGIO]>= '"+ Ngay + "' and [NGAYGIO]<= '" + Ngay1 + "' ORDER BY [NGAYGIO]";
        //        SqlCmd.CommandType = CommandType.Text;
        //        SqlAdp.SelectCommand = SqlCmd;
        //        SqlAdp.SelectCommand.ExecuteNonQuery();
        //        SqlAdp.Fill(dt);
        //        SqlCmd.Transaction.Commit();
        //    }
        //    catch
        //    {
        //        SqlCmd.Transaction.Rollback();
        //    }
        //    finally
        //    {
        //        SqlCmd.Parameters.Clear();
        //        SqlTrans = null;
        //        SqlCnn.Close();
        //        SqlCnn.Dispose();
        //    }
        //    if (SqlCmd != null)
        //        SqlCmd.Dispose();
        //    if (SqlAdp != null)
        //        SqlAdp.Dispose();
        //    return dt;
        //}
        //public DataTable LaySoLieuMDMSPQNLMT(string MaDiemDo, DateTime Ngay, DateTime Ngay1, DateTime Ngay2)
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection SqlCnn = db.ReadFromWebConfig();
        //    SqlDataAdapter SqlAdp = new SqlDataAdapter();
        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlTransaction SqlTrans = SqlCnn.BeginTransaction();
        //    try
        //    {
        //        SqlCmd.Transaction = SqlTrans;
        //        SqlCmd.Connection = SqlCnn;
        //        SqlCmd.CommandText = "declare @sl_nhan numeric(38,6) set @sl_nhan=(SELECT SUM([SL_NHAN]) FROM [DSPMHTai].[dbo].[IMIS_BDPT] where MA_DIEMDO ='" + MaDiemDo + "' and ngay = '" + Ngay + "') SELECT [EXPORTKW],[STARTDATE],@sl_nhan FROM [DSPMHTai].[dbo].[IMIS_CONGSUAT_GIAONHAN_48CK] where MA_DIEMDO ='" + MaDiemDo + "' and startdate >= '"+ Ngay1 + "' and startdate <= '" + Ngay2 + "' order by STARTDATE";
        //        SqlCmd.CommandType = CommandType.Text;
        //        SqlAdp.SelectCommand = SqlCmd;
        //        SqlAdp.SelectCommand.ExecuteNonQuery();
        //        SqlAdp.Fill(dt);
        //        SqlCmd.Transaction.Commit();
        //    }
        //    catch
        //    {
        //        SqlCmd.Transaction.Rollback();
        //    }
        //    finally
        //    {
        //        SqlCmd.Parameters.Clear();
        //        SqlTrans = null;
        //        SqlCnn.Close();
        //        SqlCnn.Dispose();
        //    }
        //    if (SqlCmd != null)
        //        SqlCmd.Dispose();
        //    if (SqlAdp != null)
        //        SqlAdp.Dispose();
        //    return dt;
        //}
        //public DataTable LaySoLieuMDMSPQNLMT_SL(string MaDiemDo, DateTime Ngay)
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection SqlCnn = db.ReadFromWebConfig();
        //    SqlDataAdapter SqlAdp = new SqlDataAdapter();
        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlTransaction SqlTrans = SqlCnn.BeginTransaction();
        //    try
        //    {
        //        SqlCmd.Transaction = SqlTrans;
        //        SqlCmd.Connection = SqlCnn;
        //        SqlCmd.CommandText = "SELECT SUM([SL_NHAN]) FROM [DSPMHTai].[dbo].[IMIS_BDPT] where MA_DIEMDO ='"+ MaDiemDo + "' and ngay = '"+ Ngay + "'";
        //        SqlCmd.CommandType = CommandType.Text;
        //        SqlAdp.SelectCommand = SqlCmd;
        //        SqlAdp.SelectCommand.ExecuteNonQuery();
        //        SqlAdp.Fill(dt);
        //        SqlCmd.Transaction.Commit();
        //    }
        //    catch
        //    {
        //        SqlCmd.Transaction.Rollback();
        //    }
        //    finally
        //    {
        //        SqlCmd.Parameters.Clear();
        //        SqlTrans = null;
        //        SqlCnn.Close();
        //        SqlCnn.Dispose();
        //    }
        //    if (SqlCmd != null)
        //        SqlCmd.Dispose();
        //    if (SqlAdp != null)
        //        SqlAdp.Dispose();
        //    return dt;
        //}
        //public DataTable LaySoLieuMDMSQ(string MaDiemDo, DateTime Ngay, DateTime Ngay1)
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection SqlCnn = db.ReadFromWebConfig();
        //    SqlDataAdapter SqlAdp = new SqlDataAdapter();
        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlTransaction SqlTrans = SqlCnn.BeginTransaction();
        //    try
        //    {
        //        SqlCmd.Transaction = SqlTrans;
        //        SqlCmd.Connection = SqlCnn;
        //        SqlCmd.CommandText = "SELECT [MA_DIEMDO],[NGAYGIO],[IMPBT],[IMPCD],[IMPTD],[EXPBT],[EXPCD],[EXPTD],[RP_T] FROM [DSPMHTai].[dbo].[IMIS_Vcumvals] WHERE [MA_DIEMDO] ='" + MaDiemDo + "' AND [NGAYGIO]>= '" + Ngay + "' and [NGAYGIO]<= '" + Ngay1 + "' ORDER BY [NGAYGIO]";
        //        SqlCmd.CommandType = CommandType.Text;
        //        SqlAdp.SelectCommand = SqlCmd;
        //        SqlAdp.SelectCommand.ExecuteNonQuery();
        //        SqlAdp.Fill(dt);
        //        SqlCmd.Transaction.Commit();
        //    }
        //    catch
        //    {
        //        SqlCmd.Transaction.Rollback();
        //    }
        //    finally
        //    {
        //        SqlCmd.Parameters.Clear();
        //        SqlTrans = null;
        //        SqlCnn.Close();
        //        SqlCnn.Dispose();
        //    }
        //    if (SqlCmd != null)
        //        SqlCmd.Dispose();
        //    if (SqlAdp != null)
        //        SqlAdp.Dispose();
        //    return dt;
        //}
        //public DataTable LaySoLieuDonVi()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection SqlCnn = db.ReadFromWebConfig();
        //    SqlDataAdapter SqlAdp = new SqlDataAdapter();
        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlTransaction SqlTrans = SqlCnn.BeginTransaction();
        //    try
        //    {
        //        SqlCmd.Transaction = SqlTrans;
        //        SqlCmd.Connection = SqlCnn;
        //        SqlCmd.CommandText = "SELECT * FROM [DSPMHTai].[dbo].[IMIS_DONVI] WHERE (ID_DONVICHA like 'PC07%' or ID_DONVICHA like 'CT07%')";
        //        SqlCmd.CommandType = CommandType.Text;
        //        SqlAdp.SelectCommand = SqlCmd;
        //        SqlAdp.SelectCommand.ExecuteNonQuery();
        //        SqlAdp.Fill(dt);
        //        SqlCmd.Transaction.Commit();
        //    }
        //    catch
        //    {
        //        SqlCmd.Transaction.Rollback();
        //    }
        //    finally
        //    {
        //        SqlCmd.Parameters.Clear();
        //        SqlTrans = null;
        //        SqlCnn.Close();
        //        SqlCnn.Dispose();
        //    }
        //    if (SqlCmd != null)
        //        SqlCmd.Dispose();
        //    if (SqlAdp != null)
        //        SqlAdp.Dispose();
        //    return dt;
        //}
        //public DataTable LaySoLieuDiemDo()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection SqlCnn = db.ReadFromWebConfig();
        //    SqlDataAdapter SqlAdp = new SqlDataAdapter();
        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlTransaction SqlTrans = SqlCnn.BeginTransaction();
        //    try
        //    {
        //        SqlCmd.Transaction = SqlTrans;
        //        SqlCmd.Connection = SqlCnn;
        //        SqlCmd.CommandText = "SELECT [MA_TRAM],[MA_DIEMDO],[TEN_DIEMDO],[ID_DONVI] FROM [DSPMHTai].[dbo].[IMIS_DM_DIEMDO] where (ID_DONVI like 'PC07%' or ID_DONVI like 'CT07%')";
        //        SqlCmd.CommandType = CommandType.Text;
        //        SqlAdp.SelectCommand = SqlCmd;
        //        SqlAdp.SelectCommand.ExecuteNonQuery();
        //        SqlAdp.Fill(dt);
        //        SqlCmd.Transaction.Commit();
        //    }
        //    catch
        //    {
        //        SqlCmd.Transaction.Rollback();
        //    }
        //    finally
        //    {
        //        SqlCmd.Parameters.Clear();
        //        SqlTrans = null;
        //        SqlCnn.Close();
        //        SqlCnn.Dispose();
        //    }
        //    if (SqlCmd != null)
        //        SqlCmd.Dispose();
        //    if (SqlAdp != null)
        //        SqlAdp.Dispose();
        //    return dt;
        //}
    }
}