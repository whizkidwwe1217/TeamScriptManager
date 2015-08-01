using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace JeonsoftTeamScriptManager.Utils
{
    public sealed class Win32
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern bool PathRelativePathTo(
             [Out] StringBuilder pszPath,
             [In] string pszFrom,
             [In] FileAttributes dwAttrFrom,
             [In] string pszTo,
             [In] FileAttributes dwAttrTo
        );
    }
}
