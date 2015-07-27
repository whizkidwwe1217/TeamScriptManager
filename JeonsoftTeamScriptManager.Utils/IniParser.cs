using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JeonsoftTeamScriptManager.Utils
{
    public class IniParser
    {
        private List<string> warnings;
        private Section unSectionedKeyPairs;

        public IniParser()
        {
            warnings = new List<string>();
            unSectionedKeyPairs = new Section("UnSectioned Key Pairs");
            unSectionedKeyPairs.Operators.Add(':');
        }

        public List<string> Warnings
        {
            get { return warnings; }
        }

        public Section UnSectionedKeyPairs
        {
            get { return unSectionedKeyPairs; }
        }

        public Dictionary<string, Section> Parse(string source)
        {
            string[] lines = source.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Dictionary<string, Section> sections = new Dictionary<string, Section>();
            List<string> comments = new List<string>();
            Section currentSection = null;
            int lineNo = 0;
            foreach (string line in lines)
            {
                ++lineNo;
                string strLine = line.Trim();
                Section section = null;
                if (strLine.Length <= 1)
                    continue;
                else if (strLine.StartsWith(";"))
                    comments.Add(strLine.Substring(1, strLine.Length - 1));
                else if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                {
                    string strSection = strLine.Substring(1, strLine.Length - 2).Trim();
                    section = new Section(strSection) { Comments = comments };
                    section.Operators.Add(';');
                    currentSection = section;
                    comments = new List<string>();
                }
                else
                {
                    if (currentSection != null)
                    {
                        if (!sections[currentSection.Key].StartsWithAnyOperand(strLine))
                        {
                            char[] operators = sections[currentSection.Key].Operators.ToArray();
                            int operatorPos = strLine.IndexOfAny(operators);
                            if (operatorPos == -1)
                                throw new IniParserException("Invalid key pair encountered.", lineNo);
                            string key = strLine.Substring(0, operatorPos).Trim();
                            string value = strLine.Substring(operatorPos + 1, strLine.Length - (operatorPos + 1)).Trim();
                            KeyPair pair = new KeyPair(sections[currentSection.Key], key, value);
                            pair.Comments = comments;
                            pair.Line = lineNo;
                            pair.KeyPairOperator = strLine[operatorPos];
                            sections[currentSection.Key].Pairs.Add(pair);
                            comments = new List<string>();
                        }
                    }
                    else
                    {
                        char keyPairOperator = '=';
                        int operatorPos = strLine.IndexOf(keyPairOperator);
                        if (operatorPos == -1)
                            throw new IniParserException("Invalid key pair encountered.", lineNo);
                        string key = strLine.Substring(0, operatorPos).Trim();
                        string value = strLine.Substring(operatorPos + 1, strLine.Length - (operatorPos + 1)).Trim();
                        KeyPair pair = new KeyPair(unSectionedKeyPairs, key, value);
                        pair.Line = lineNo;
                        pair.Comments = comments;
                        pair.KeyPairOperator = keyPairOperator;
                        unSectionedKeyPairs.Pairs.Add(pair);
                        warnings.Add("Found a key pair with no underlying section at line " + lineNo.ToString());
                    }
                }
                if (section != null)
                    sections.Add(section.Key, section);
            }

            return sections;
        }

        public Dictionary<string, Section> ParseFile(string fileName)
        {
            FileStream stream = null;
            StringBuilder sb = null;
            StreamReader reader = null;
            string source = string.Empty;
            try
            {
                sb = new StringBuilder();
                stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                reader = new StreamReader(stream);
                source = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (reader != null)
                    reader.Close();
            }
            return Parse(source);
        }
    }
}
