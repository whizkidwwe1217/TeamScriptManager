using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JeonsoftTeamScriptManager.Utils
{
    public sealed class FileUtils
    {
        public static FileInfo GetAbsolutePath(string baseDirectory, string relativePath)
        {
            if (relativePath.StartsWith(".\\"))
                relativePath = relativePath.Substring(2, relativePath.Length - 2);
            return new FileInfo(Path.Combine(baseDirectory, relativePath));
        }

        public static DirectoryInfo GetAbsoluteDirectory(string baseDirectory, string relativePath)
        {
            if (relativePath.StartsWith(".\\"))
                relativePath = relativePath.Substring(2, relativePath.Length - 2);
            return new DirectoryInfo(Path.Combine(baseDirectory, relativePath));
        }

        public static FileInfo[] GetFiles(string directory, string pattern, bool recurse, string extensionFilter)
        {
            DirectoryInfo di = new DirectoryInfo(directory);
            return di.GetFiles(extensionFilter, recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        public static DirectoryInfo GetDirectory(string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(fileName);
            return info;
        }

        public static string GetRelativePath(string basePath, string relativePath)
        {
            const Int32 MAX_PATH = 260;
            StringBuilder str = new StringBuilder(MAX_PATH);
            Boolean bRet = Win32.PathRelativePathTo(
                 str,
                basePath, FileAttributes.Directory,
                 relativePath, FileAttributes.Directory
                 );
            if (bRet)
                return str.ToString();
            return string.Empty;
        }

        public static string GetRelativePathFromFile(string basePath, string relativeFile)
        {
            const Int32 MAX_PATH = 260;
            StringBuilder str = new StringBuilder(MAX_PATH);
            Boolean bRet = Win32.PathRelativePathTo(
                 str,
                basePath, FileAttributes.Directory,
                 relativeFile, FileAttributes.Normal
                 );
            if (bRet)
                return str.ToString();
            return string.Empty;
        }
    }
}
