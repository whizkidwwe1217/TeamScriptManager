using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeonsoftTeamScriptManager
{
    public enum BookmarkType 
    {
        Info,
        Warning,
        Error
    }

    public class Bookmark
    {
        private string filename;

        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
        private int startLine;

        public int StartLine
        {
            get { return startLine; }
            set { startLine = value; }
        }
        private int startColumn;

        public int StartColumn
        {
            get { return startColumn; }
            set { startColumn = value; }
        }

        private int endColumn;

        public int EndColumn
        {
            get { return endColumn; }
            set { endColumn = value; }
        }

        private int endLine;

        public int EndLine
        {
            get { return endLine; }
            set { endLine = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        private BookmarkType type;

        public BookmarkType Type
        {
            get { return type; }
            set { type = value; }
        }

        public Bookmark(string filename, string name, int startColumn, int startLine, int endColumn, int endLine, string message, BookmarkType type)
        {
            this.name = name;
            this.filename = filename;
            this.startColumn = startColumn;
            this.startLine = startLine;
            this.endColumn = endColumn;
            this.endLine = endLine;
            this.message = message;
            this.type = type;
        }
    }
}
