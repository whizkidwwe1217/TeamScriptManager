using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeonsoftTeamScriptManager
{
    public class DataSizeUnit
    {
        public float size;
        public string unit;
        public float convertedSize;

        public DataSizeUnit(long size)
        {
            this.size = size;
        }

        public override string ToString()
        {
            return Calculate();
        }

        private string Calculate()
        {
            unit = Units.Byte;
            convertedSize = size;

            if (size >= Math.Pow(2, 10) && size < Math.Pow(2, 20))
            {
                unit = Units.Kilobyte;
                convertedSize = size / (float)Math.Pow(2, 10);
            }
            else if (size >= Math.Pow(2, 20) && size < Math.Pow(2, 30))
            {
                unit = Units.Megabyte;
                convertedSize = size / (float)Math.Pow(2, 20);
            }
            else if (size >= Math.Pow(2, 30) && size < Math.Pow(2, 40))
            {
                unit = Units.Gigabyte;
                convertedSize = size / (float)Math.Pow(2, 30);
            }
            else if (size >= Math.Pow(2, 40) && size < Math.Pow(2, 50))
            {
                unit = Units.Terabyte;
                convertedSize = size / (float)Math.Pow(2, 40);
            }
            else if (size >= Math.Pow(2, 50) && size < Math.Pow(2, 60))
            {
                unit = Units.Petabyte;
                convertedSize = size / (float)Math.Pow(2, 50);
            }
            else if (size >= Math.Pow(2, 60) && size < Math.Pow(2, 70))
            {
                unit = Units.Exabyte;
                convertedSize = size / (float)Math.Pow(2, 60);
            }
            else if (size >= Math.Pow(2, 70) && size < Math.Pow(2, 80))
            {
                unit = Units.Exabyte;
                convertedSize = size / (float)Math.Pow(2, 70);
            }
            else if (size >= Math.Pow(2, 80) && size < Math.Pow(2, 90))
            {
                unit = Units.Yottabyte;
                convertedSize = size / (float)Math.Pow(2, 80);
            }
            else if (size >= Math.Pow(2, 90))
                return "a very huge file";
            return string.Format("{0:#,##0.00} {1}", convertedSize, unit);
        }
        public sealed class Units
        {
            public const string Byte = "B";
            public const string Kilobyte = "KB";
            public const string Megabyte = "MB";
            public const string Gigabyte = "GB";
            public const string Terabyte = "TB";
            public const string Petabyte = "PB";
            public const string Exabyte = "EB";
            public const string Zettabyte = "ZB";
            public const string Yottabyte = "YB";
        }
    }
}
