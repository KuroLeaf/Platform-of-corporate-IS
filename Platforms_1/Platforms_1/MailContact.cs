namespace Platforms_1
{
    using System;
    using System.IO;

    /// <summary>
    /// Class for describe mail contact.
    /// </summary>
    /// <remarks>
    /// Inherits file streaming methods from IFileManager and contain means to work with mail contact.
    /// </remarks>
    public class MailContact: Contact, IFileManager
    {
        /// <summary>
        /// Mail address field.
        /// </summary>
        private string mailAddress;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MailContact()
        {
            this.Name = string.Empty;
            this.MailAddress = "-@-";
        }

        /// <summary>
        /// Splits string of info on valid fields: Name and MailAddress.
        /// </summary>
        /// <param name="line"> String of information about mail contact.</param>
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

        /// <summary>
        /// Gets name of user and mail address of contact and set their in properly fields.
        /// </summary>
        /// <param name="name"> Name of contact to set.</param>
        /// <param name="mailAddress"> Mail address of contact to set.</param>
        public MailContact(string name, string mailAddress)
        {
            this.Name = name;
            this.MailAddress = mailAddress;
        }

        /// <summary>
        /// MailAddress property.
        /// </summary>
        /// <value>
        /// Gets mail address value, set it into properly field and return.
        /// </value>
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

        /// <summary>
        /// Splits string of info on valid fields: Name and MailAddress.
        /// </summary>
        /// <param name="line"> String of information about mail contact.</param>
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
                sw.WriteLine($"Name: {Name} - \tmail address: \t{MailAddress}");
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
            return $"Name: {Name} - \tmail address: \t{MailAddress}";
        }
    }
}
