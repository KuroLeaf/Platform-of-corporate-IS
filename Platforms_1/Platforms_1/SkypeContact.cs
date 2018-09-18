namespace Platforms_1
{
    using System;
    using System.IO;

    public class SkypeContact: Contact, IFileManager
    {
        public SkypeContact()
        {
            this.Name = string.Empty;
            this.SkypeName = string.Empty;
        }

        public SkypeContact(string line)
        {
            string[] info = line.Split(':');

            if (info.Length != 2)
            {
                throw new Exception("Incorrect input data!");
            }

            this.Name = info[0].Trim();
            this.SkypeName = info[1].Trim();
        }

        public SkypeContact(string name, string skypeName)
        {
            this.Name = name;
            this.SkypeName = skypeName;
        }

        public string SkypeName { get; set; }

        public void ParseLine(string line)
        {
            string[] info = line.Split(':');

            if (info.Length != 2)
            {
                throw new Exception("Incorrect input data!");
            }

            this.Name = info[0].Trim();

            this.SkypeName = info[1].Trim();
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
                sw.WriteLine($"Name: {Name} - skype name: {SkypeName}");
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, skype name: {SkypeName}";
        }
    }
}