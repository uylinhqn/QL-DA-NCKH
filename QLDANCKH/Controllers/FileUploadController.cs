using QLDANCKH.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace TestFileUpload
{
    public class FileUploadController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();
        [HttpPost]
        public KeyValuePair<bool, string> UploadFile()
        {
            string filelink = "";
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            if (db.Proc_ThanhVien_SelectPK2(identity.Name).ToList().Count > 0)
            {
                try
            {
                string pathdr = DateTime.Now.ToString("yyyyMMddHHmmss");
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedFile = HttpContext.Current.Request.Files;
                    if (httpPostedFile != null)
                    {
                        for (int i = 0; i < httpPostedFile.Count; i++)
                        {
                            HttpPostedFile PostedFiles = httpPostedFile[i];
                            PostedFiles = httpPostedFile[i];
                            filelink += pathdr + "-" + ConvertToUnSign(PostedFiles.FileName) + ";";
                                var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads"), pathdr + "-"+ ConvertToUnSign(PostedFiles.FileName)); 
                            httpPostedFile[i].SaveAs(fileSavePath);
                        }
                        return new KeyValuePair<bool, string>(true, filelink);
                    }
                    
                    return new KeyValuePair<bool, string>(true, "Could not get the uploaded file.");
                }

                return new KeyValuePair<bool, string>(true, "No file found to upload.");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, "An error occurred while uploading the file. Error Message: " + ex.Message);
            }
            }
            else
            {
                return new KeyValuePair<bool, string>(false, "An error occurred while uploading the file.");
            }
        }
        public static string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                if (i != 46 && i != 45)
                {
                    text = text.Replace(((char)i).ToString(), "");
                }
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                if (i != 95)
                {
                    text = text.Replace(((char)i).ToString(), "");
                }
            }
            text = text.Replace(" ", "");
            text = text.Replace("–", "");
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}