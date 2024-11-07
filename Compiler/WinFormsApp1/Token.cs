using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Token
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public bool IsToken(string type)
        {
            return Type == type;
        }

        public override string ToString()
        {
            return $"{Type}: {Value}";
        }
    }
}
