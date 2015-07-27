using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string url = @"\\10.0.0.3\On-Going Scripts\JPS\fnGetAge.sql";
            //string url = @"\\newdevserver\On-Going Scripts\JPS\fnGetAge.sql";
            //string url = @"D:\Wayne Lapstop\Jeonsoft\Scripts\Sephil Point Ranges.sql";
            
            //Console.WriteLine(Program.GetHostName(url));
            //Program.DownloadFileFromFtp();

            using (WebClient wc = new WebClient())
            {
                string ftpUrl = "ftp://ftp.jeonsoft.com";
                string username = "u71059845";
                string password = "uptown_629#";
                string ftpDir = "installers/jeonsoftautomationtools";
                string filename = "team_script_manager_version.ini";
                string localDir = "D:\\";
                string uri = ftpUrl + "/" + ftpDir + "/" + filename;
                string outputFilename = Directory.GetCurrentDirectory() + "\\Cache\\" + filename;
                wc.Credentials = new NetworkCredential(username, password);
                
                wc.DownloadFileAsync(new Uri(uri), localDir);
            }
            Console.ReadKey();
        }

        private static void DownloadFileFromFtp()
        {
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
                Console.WriteLine(ex.Message);
            }
        }

        public static string GetHostName(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                Console.WriteLine("Absolute: " + uri.HostNameType.ToString());
                Console.WriteLine(uri.Host);
                System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(uri.Host);
                return ip.HostName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
