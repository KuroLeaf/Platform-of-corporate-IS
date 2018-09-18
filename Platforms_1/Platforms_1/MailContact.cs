namespace Platforms_1
{
    using System;
    using System.IO;

    public class MailContact: Contact, IFileManager
    {
        private string mailAddress;

        public MailContact()
        {
            this.Name = string.Empty;
            this.MailAddress = "-@-";
        }

        public MailContact(string line)
        {
            string[] info = line.Split(':');

            if (info.Length != 2)
            {
                throw new Exception("Incorrect input data!");
            }

            this.Name = info[0].Trim();
            this.MailAddress = info[1].Trim();
        }

        public MailContact(string name, string mailAddress)
        {
            this.Name = name;
            this.MailAddress = mailAddress;
        }

        public string MailAddress
        {
            get
            {
                return this.mailAddress;
            }

            set
            {
                if (!value.Contains("@"))
                {
                    throw new Exception("Incorrect input mail address!");
                }

                this.mailAddress = value;
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
            this.MailAddress = info[1].Trim();
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
                sw.WriteLine($"Name: {Name} - mail address: {MailAddress}");
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, mail address: {MailAddress}";
        }
    }
}
