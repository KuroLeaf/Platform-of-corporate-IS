namespace Platforms_1
{
    using System;
    using System.IO;

    /// <summary>
    /// Class for describe phone contact.
    /// </summary>
    /// <remarks>
    /// Inherits file streaming methods from IFileManager and contain means to work with phone contact.
    /// </remarks>
    public class PhoneContact: Contact, IFileManager
    {
        /// <summary>
        /// Phone number field.
        /// </summary>
        private string phoneNumber;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PhoneContact()
        {
            this.Name = string.Empty;
            this.PhoneNumber = "00000";
        }

        /// <summary>
        /// Splits string of info on valid fields: Name and PhoneNumber.
        /// </summary>
        /// <param name="line"> String of information about phone contact.</param>
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

        /// <summary>
        /// Gets name of user and phone number of contact and set their in properly fields.
        /// </summary>
        /// <param name="name"> Name of contact to set.</param>
        /// <param name="phoneNumber"> Phone number of contact to set.</param>
        public PhoneContact(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }


        /// <summary>
        /// PhoneNumber property.
        /// </summary>
        /// <value>
        /// Gets phone number value, set it into properly field and return.
        /// </value>
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

        /// <summary>
        /// Splits string of info on valid fields: Name and PhoneNumber.
        /// </summary>
        /// <param name="line"> String of information about phone contact.</param>
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
                sw.WriteLine($"Name: {Name}; \tPhone Number: \t{PhoneNumber}");
            }
        }

        /// <summary>
        /// Convert object to string.
        /// </summary>
        /// <returns>
        /// Return string of information about phone contact.
        /// </returns>
        public override string ToString()
        {
            return $"Name: {Name} - \tPhone Number: \t{PhoneNumber}";
        }
    }
}