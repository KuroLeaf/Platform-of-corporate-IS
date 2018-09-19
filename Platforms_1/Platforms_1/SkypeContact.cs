namespace Platforms_1
{
    using System;
    using System.IO;

    /// <summary>
    /// Class for describe skype contact.
    /// </summary>
    /// <remarks>
    /// Inherits file streaming methods from IFileManager and contain means to work with skype contact.
    /// </remarks>
    public class SkypeContact: Contact, IFileManager
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SkypeContact()
        {
            this.Name = string.Empty;
            this.SkypeName = string.Empty;
        }

        /// <summary>
        /// Splits string of info on valid fields: Name and SkypeName.
        /// </summary>
        /// <param name="line"> String of information about skype contact.</param>
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

        /// <summary>
        /// Gets name of user and skype name of contact and set their in properly fields.
        /// </summary>
        /// <param name="name"> Name of contact to set.</param>
        /// <param name="skypeName"> Skype name of contact to set.</param>
        public SkypeContact(string name, string skypeName)
        {
            this.Name = name;
            this.SkypeName = skypeName;
        }

        /// <summary>
        /// SkypeName property.
        /// </summary>
        /// <value>
        /// Gets skype name value, set it into properly field and return.
        /// </value>
        public string SkypeName { get; set; }

        /// <summary>
        /// Splits string of info on valid fields: Name and SkypeName.
        /// </summary>
        /// <param name="line"> String of information about skype contact.</param>
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

        /// <summary>
        /// Read information about contact from file and set their into properly fields.
        /// </summary>
        /// <param name="path"> Path for file reading.</param>
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

        /// <summary>
        /// Write information about contact in file.
        /// </summary>
        /// <param name="path"> Path for file writing.</param>
        public void WriteInFile(string path)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new Exception("Unknown text file format!");
            }

            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine($"Name: {Name} - \tskype name: \t{SkypeName}");
            }
        }

        /// <summary>
        /// Convert object to string.
        /// </summary>
        /// <returns>
        /// Return string of information about mail contact.
        /// </returns>
        public override string ToString()
        {
            return $"Name: {Name} - \tskype name: \t{SkypeName}";
        }
    }
}