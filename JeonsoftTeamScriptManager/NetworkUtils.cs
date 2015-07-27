using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JeonsoftTeamScriptManager
{
    public sealed class NetworkUtils
    {
        public static string GetHostName(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(uri.Host);
                return ip.HostName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool AreHostNameEqual(string url1, string url2)
        {
            string host1 = NetworkUtils.GetHostName(url1);
            string host2 = NetworkUtils.GetHostName(url2);
            return host1.ToLower().Trim().Equals(host2.ToLower().Trim());
        }

        public static UriHostNameType GetHostType(string url, ref string host/*, ref string hostname*/)
        {
            try
            {
                Uri uri = new Uri(url);
                host = uri.Host;
                //if (uri.HostNameType != UriHostNameType.Basic && uri.HostNameType != UriHostNameType.Unknown)
                //    hostname = System.Net.Dns.GetHostEntry(uri.Host).HostName;
                return uri.HostNameType;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetHost(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                return uri.Host;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
