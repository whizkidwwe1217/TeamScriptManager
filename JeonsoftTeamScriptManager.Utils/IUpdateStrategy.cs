using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeonsoftTeamScriptManager.Utils
{
    public interface IUpdateStrategy
    {
        void CheckForUpdates();
        void DownloadUpdates();
    }
}