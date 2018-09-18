namespace Platforms_1
{
    using System;
    using System.IO;

    public class PhoneContact: Contact, IFileManager
    {
        private string phoneNumber;

        public PhoneContact()
        {
            this.Name = string.Empty;
            this.PhoneNumber = "00000";
        }

        public PhoneContact(string line)
        {
            string[] info = line.Split(':');

            if (info.Length != 2)
            {
                throw new Exception("Incorrect input data!");
            }

            this.Name = info[0].Trim();
            this.PhoneNumber = info[1].Trim();
        }

        public PhoneContact(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                if (value.Length != 5)
                {
                    throw new Exception("Incorrect input phone number! Amount of numbers have to be 5!");
                }

                Int32 phoneNumberToParse;
                if (!System.Int32.TryParse(value, out phoneNumberToParse))
                {
                    throw new Exception("Invalid input phone number! It has to be making up only from numbers!");
                }

                this.phoneNumber = value;
            }
        }

        public void ParseLine(string line)
        {
            string[] info = line.Split(':');

            if (info.Length != 2)
            {
                throw new Exception("Incorrect input data!");
            }

            this.Name = info[0].Trim();
            this.PhoneNumber = info[1].Trim();
        }

        public void ReadFromFile(string path)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new Exception("Unknown text file format!");
            }

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            { 
                string info = sr.ReadToEnd();

                if (info.Length == 0)
                {
                    throw new Exception($"File '{path}' is empty!");
                }

                this.ParseLine(info);
            }
        }

        public void WriteInFile(string path)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new Exception("Unknown text file format!");
            }

            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine($"Name: {Name}; Phone Number: {PhoneNumber}");
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Phone Number: {PhoneNumber}";
        }
    }
}