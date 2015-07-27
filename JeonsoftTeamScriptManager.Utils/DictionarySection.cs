using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeonsoftTeamScriptManager.Utils
{
    public class DictionarySection
    {
        private string key;
        private Dictionary<string, DictionaryKeyPair> pairs;
        private List<string> comments;
        private List<char> operators;

        public DictionarySection(string key, List<char> operands)
        {
            this.key = key;
            pairs = new Dictionary<string, DictionaryKeyPair>();
            comments = new List<string>();
            this.operators = new List<char>();
        }

        public DictionarySection(string key)
        {
            this.key = key;
            this.pairs = new Dictionary<string, DictionaryKeyPair>();
            operators = new List<char>();
            operators.Add('=');
        }

        public bool ContainsOperand(char operand)
        {
            return operators.Contains(operand);
        }

        public bool StartsWithAnyOperand(string source)
        {
            for (int i = 0; i < operators.Count; i++)
            {
                if (source.StartsWith(operators[i].ToString()))
                    return true;
            }
            return false;
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public Dictionary<string, DictionaryKeyPair> Pairs
        {
            get { return pairs; }
            set { pairs = value; }
        }

        public List<string> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public List<char> Operators
        {
            get { return operators; }
            set { operators = value; }
        }
    }
}
