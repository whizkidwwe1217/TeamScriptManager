using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JeonsoftTeamScriptManager.Utils
{
    public sealed class UpdateManager
    {
        private static UpdateManager instance;

        private UpdateManager()
        {

        }

        public VersionInfo GetUpdateInfo()
        {
            VersionInfo vi = new VersionInfo();
            try
            {
                //FtpWebResponse response = GetFtpResponse(UserName, Password, GetVersionInfoUri());
                //StreamReader input = new StreamReader(response.GetResponseStream());

                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(GetVersionInfoUri());
                //request.Credentials = new NetworkCredential(UserName, Password);
                //request.Method = WebRequestMethods.Ftp.DownloadFile;
                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                //StreamReader stream = new StreamReader(response.GetResponseStream());

                string ftpUrl = "ftp://ftp.jeonsoft.com";
                string username = "u71059845";
                string password = "uptown_629#";
                string ftpDir = "installers/jeonsoftautomationtools";
                string filename = "team_script_manager_version.ini";
                string localDir = "D:\\";

                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl + "/" +
                        ftpDir + "/" + filename);
                    request.Credentials = new NetworkCredential(username, password);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    Stream stream = response.GetResponseStream();
                    FileStream writeStream = new FileStream(localDir + "/" + filename, FileMode.Create);
                    int length = 2048;
                    byte[] buffer = new byte[length];
                    int bytesRead = stream.Read(buffer, 0, length);
                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = stream.Read(buffer, 0, length);
                    }
                    stream.Close();
                    writeStream.Close();
                    request = null;
                }
                catch (Exception ex)
                {
                    
                }

                //try
                //{
                //    IniDictionaryParser parser = new IniDictionaryParser();
                //    Dictionary<string, DictionarySection> sections = parser.Parse(stream.ReadToEnd());
                //    if (sections != null)
                //    {
                //        DictionarySection versionInfo = sections["Version Info"];
                //        if (versionInfo != null)
                //        {
                //            if (versionInfo.Pairs.ContainsKey("Version"))
                //                vi.Version = versionInfo.Pairs["Version"].Value;
                //            if (versionInfo.Pairs.ContainsKey("File Name"))
                //                vi.FileName = versionInfo.Pairs["File Name"].Value;
                //        }
                //    }

                //}
                //catch (Exception ex)
                //{
                //    throw new Exception(ex.Message);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + ex.Message);
            }
            return vi;
        }

        public string VersionFile
        {
            get
            {
                return "team_script_manager_version.ini";
            }
        }
        public string UserName
        {
            get { return "u71059845"; }
        }

        public string Password
        {
            get { return "uptown_629"; }
        }

        public void DownloadFileFromFtp()
        {
            string ftpUrl = "ftp://ftp.jeonsoft.com";
            string username = "u71059845";
            string password = "uptown_629#";
            string ftpDir = "installers/jeonsoftautomationtools";
            string filename = "temp_version_config.ini";
            string localDir = "D:\\";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl + "/" +
                    ftpDir + "/" + filename);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream stream = response.GetResponseStream();
                FileStream writeStream = new FileStream(localDir + "/" + filename, FileMode.Create);
                int length = 2048;
                byte[] buffer = new byte[length];
                int bytesRead = stream.Read(buffer, 0, length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = stream.Read(buffer, 0, length);
                }
                stream.Close();
                writeStream.Close();
                request = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FtpWebResponse GetFtpResponse(string username, string password, string url)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential(username, password);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            return response;
        }

        public void DownloadFileFromFtp(string ftpUrl, string username, string password, string ftpDir, string filename, string localDir)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl + "/" +
                    ftpDir + "/" + filename);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream stream = response.GetResponseStream();
                FileStream writeStream = new FileStream(localDir + "/" + filename, FileMode.Create);
                int length = 2048;
                byte[] buffer = new byte[length];
                int bytesRead = stream.Read(buffer, 0, length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = stream.Read(buffer, 0, length);
                }
                stream.Close();
                writeStream.Close();
                request = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetVersionInfoUri()
        {
            return FtpSite + "/" + BaseFtpDir + "/" + VersionFile;    
        }

        public string BaseFtpDir
        {
            get
            {
               return "installers/jeonsoftautomationtools";
            }
        }
        public string FtpSite
        {
            get
            {
                return "ftp://ftp.jeonsoft.com";
            }
            
        }

        public static UpdateManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new UpdateManager();
                return instance;
            }
        }
    }
}
