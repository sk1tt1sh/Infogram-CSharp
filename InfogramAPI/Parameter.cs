using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infogram
{
    class Parameter
    {
        public string key, value;

        public Parameter(string key,string value)
        {
            this.key = key;
            this.value = value;
        }

        public bool equals(object other)
        {
            return false;
        }
    }
}
