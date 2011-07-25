using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CameraViewer
{
    public class FtpService
    {
        public static string HostIp;
        public static string UserName;
        public static string Password;

        public async Task UploadImageAsync(Image image, string destination)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                await UploadStreamAsync(stream, destination);
            }
        }


        private void MakeDir(string relativePath)
        {
            var dir = Path.GetDirectoryName(relativePath);
            if (!string.IsNullOrEmpty(dir))
            {
                var remoteDir = GetAbsolutePath(dir);
                var request = CreateRequest(remoteDir, WebRequestMethods.Ftp.MakeDirectory);
                ExecuteRequest(request);
            }
        }

        private  Task UploadStreamAsync(Stream sourceStream, string relativePath)
        {
            return TaskEx.Run(() =>
                           {
                               MakeDir(relativePath);
                               var path = GetAbsolutePath(relativePath);
                               var req = CreateRequest(path, WebRequestMethods.Ftp.UploadFile);
                               req.ContentLength = sourceStream.Length;

                               sourceStream.Seek(0, SeekOrigin.Begin);
                               Stream strm = req.GetRequestStream();
                               sourceStream.CopyTo(strm);
                               strm.Close();
                           });

        }

        private System.Net.FtpWebRequest CreateRequest(string uri, string method)
        {
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)WebRequest.Create(uri);
            reqFTP.Credentials = new NetworkCredential(UserName, Password);
            reqFTP.KeepAlive = false;
            reqFTP.UseBinary = true;
            reqFTP.Method = method;
            return reqFTP;
        }

        private void ExecuteRequest(WebRequest request)
        {
            try
            {
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                response.Close();
                if (responseStream != null) responseStream.Close();

            }
            catch (System.Net.WebException e)
            {
                var response = (FtpWebResponse)e.Response;
                if (response.StatusCode != FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    throw;
                }
            }
        }

        private string GetAbsolutePath(string relativePath)
        {
            return string.Format("ftp://{0}/{1}", HostIp, relativePath);
        }
    }
}
