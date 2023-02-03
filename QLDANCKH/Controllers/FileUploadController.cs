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
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedExecel"];
                    if (httpPostedFile != null)
                    {
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/uploads/"+ identity.Name+"/"));
                        // Validate the uploaded image(optional)

                        // Get the complete file path
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/" + identity.Name + "/"), pathdr+httpPostedFile.FileName);

                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(fileSavePath);

                        return new KeyValuePair<bool, string>(true, pathdr + httpPostedFile.FileName);
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
    }
}