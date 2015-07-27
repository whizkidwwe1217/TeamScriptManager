using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeonsoftTeamScriptManager.Utils
{
    public class IniParserException : Exception
    {
        private int line;

        public IniParserException(string message, int line)
            : base(message)
        {
            this.line = line;
        }

        public int Line
        {
            get { return line; }
        }
    }
}
