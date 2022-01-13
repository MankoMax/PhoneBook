using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Record
    {
        public string _number;
        public string _name;

        public Record(string number, string name)
        {
            _number = number;
            _name = name;
        }
    }
}
