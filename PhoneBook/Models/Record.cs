using System.Text.RegularExpressions;

namespace PhoneBook
{
    public class Record
    {
        private string _number;

        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                var regEx = new Regex(" *[\\~#%&*{}()/:<>?|\"-]+ *");
                _number = regEx.Replace(value, string.Empty);
            }
        }

        public string Name { get; set; }

        public Record(string number, string name)
        {
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"Name: {Name}; \n   Number: {Number}\n";
        }
    }
}
