using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeonsoftTeamScriptManager.Utils
{
    public class DictionaryKeyPair
    {
        private string key;
        private string value;
        private List<string> comments;
        private DictionarySection section;
        private int line;
        private char keyPairOperator;

        public DictionaryKeyPair(DictionarySection section, string key, string value)
        {
            this.key = key;
            this.value = value;
            this.section = section;
        }

        public char KeyPairOperator
        {
            get { return keyPairOperator; }
            set { keyPairOperator = value; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public List<string> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public DictionarySection Section
        {
            get { return section; }
        }

        public int Line
        {
            get { return line; }
            set { line = value; }
        }
    }
}
