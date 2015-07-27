using System;
using System.Collections.Generic;
using System.Text;

namespace JeonsoftTeamScriptManager
{
    public class IndexedFile
    {
        public string name;
        public string path;
        public string groupName;
        public string groupPath;
        public bool Added;

        public IndexedFile(string groupName, string groupPath, string name, string path)
        {
            this.name = name;
            this.path = path;
            this.groupName = groupName;
            this.groupPath = groupPath;
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            IndexedFile idx = obj as IndexedFile;
            return idx.path == this.path;
        }

        public override int GetHashCode()
        {
            return path.GetHashCode();
        }
    }
}
