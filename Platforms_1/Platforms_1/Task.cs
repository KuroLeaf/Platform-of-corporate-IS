namespace Platforms_1
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;


    /// <summary>
    /// Class for making all needed tasks.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Perform first task.
        /// </summary>
        /// <remarks>
        /// Read data in the ArrayList collection. 
        /// Sort the collection in alphabetical order and output the result to file1.
        /// </remarks>
        public void DoFirstTask()
        {
            ArrayList list = new ArrayList();
            list = this.ReadFile("Contacts.txt");

            list.Sort(new ContactsComparer());

            this.WriteArrayListContactsInFile("File1.txt", list);
        }
         
        /// <summary>
        /// Perform second task.
        /// </summary>
        /// <remarks>
        /// Rewrite data in a new container pairs: name - phone number + mail + skype. 
        /// Print result in file2. 
        /// Output the names of those people who have only a phone.
        /// </remarks>
        public void DoSecondTask()
        {
            ArrayList list = new ArrayList();
            list = this.ReadFile("Contacts.txt");

            Dictionary<string, List<string>> contactsContainer = this.GroupArrayListContacts(list);

            this.WriteContactsDictionaryInFIle("File2.txt", contactsContainer);

            List<string> userNamesHasOnlyPhones = this.UsersWithOnlyPhones(list);

            this.WriteListInFile("File3.txt", userNamesHasOnlyPhones);
        }

        /// <summary>
        /// Compares two Contacts.
        /// </summary>
        /// <param name="path"> Path for file reading.</param>
        /// <returns>
        /// Read from file info about several contacts and contains it in ArrayList collection.
        /// </returns>
        public ArrayList ReadFile(string path)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new ExceptionsLogger("Unknown text file format!");
            }

            string[] lines = File.ReadAllLines(path);
            ArrayList contactsList = new ArrayList();
          
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Trim().ToLower() == "phone")
                {
                    contactsList.Add(new PhoneContact(lines[++i]));
                }
                else if (lines[i].Trim().ToLower() == "mail")
                {
                    contactsList.Add(new MailContact(lines[++i]));
                }
                else if (lines[i].Trim().ToLower() == "skype")
                {
                    contactsList.Add(new SkypeContact(lines[++i]));
                }
                else if (lines[i].Trim() == string.Empty)
                {
                    continue;
                }
                else
                {
                    throw new ExceptionsLogger($"Unknown contact! Check info in file '{path}'");
                }

            }

            return contactsList;
        }

        /// <summary>
        /// Write ArrayList of Contacts in file.
        /// </summary>
        /// <param name="path"> Path for file writing.</param>
        /// <param name="arrayList"> List of contacts to write.</param>
        public void WriteArrayListContactsInFile(string path, ArrayList arrayList)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new ExceptionsLogger("Unknown text file format!");
            }

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (object element in arrayList)
                {
                    sw.WriteLine(element);
                }
            }
        }

        /// <summary>
        /// Groups data in a new container pairs: name - phone number + mail + skype.
        /// </summary>
        /// <param name="list"> List of contacts to group.</param>        
        /// <returns>
        /// Return new container pairs (Dictionary): : name - phone number + mail + skype.
        /// </returns>
        public Dictionary<string, List<string>> GroupArrayListContacts(ArrayList list)
        {
            var groupList = from Contact l in list
                            group l by (l as Contact).Name;

            Dictionary<string, List<string>> groupContacts = new Dictionary<string, List<string>>();
            foreach (IGrouping<string, Contact> g in groupList)
            {
                List<string> contacts = new List<string>();
                foreach (var t in g)
                {
                    if (t is PhoneContact)
                    {
                        contacts.Add((t as PhoneContact).PhoneNumber);
                    }
                    else if (t is MailContact)
                    {
                        contacts.Add((t as MailContact).MailAddress);
                    }
                    else if (t is SkypeContact)
                    {
                        contacts.Add((t as SkypeContact).SkypeName);
                    }
                }

                groupContacts.Add(g.Key, contacts);
            }

            return groupContacts;
        }

        /// <summary>
        /// Write contacts from Dictionary in fIle.
        /// </summary>
        /// <param name="path"> Path for file writing.</param>
        /// <param name="pairs"> Pairs collection: name - phone number + mail + skype.</param>
        public  void WriteContactsDictionaryInFIle(string path, Dictionary<string, List<string>> pairs)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new ExceptionsLogger("Unknown text file format!");
            }

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (KeyValuePair<string, List<string>> keyValye in pairs)
                {
                    sw.Write($"{keyValye.Key}: \t");
                    foreach (string s in keyValye.Value)
                    {
                        sw.Write($"{s}, ");
                    }

                    sw.WriteLine();
                }
            }
        }

        /// <summary>
        /// Creates List with name of users who has only phone contact.
        /// </summary>
        /// <param name="list"> List of contacts.</param>
        /// <returns>
        /// Returns list of names of users who has only phone contact.
        /// </returns>
        public  List<string> UsersWithOnlyPhones(ArrayList list)
        {
            List<string> namesOnlyWithPhones = (from Contact l in list
                                                group l by (l as Contact).Name into g
                                                where g.Count() == 1
                                                from t in g
                                                where t is PhoneContact
                                                select (t as PhoneContact).Name).ToList();

            return namesOnlyWithPhones;
        }

        /// <summary>
        /// Print in file List of strings.
        /// </summary>
        /// <param name="path"> Path for file writing.</param>
        /// <param name="list"> List of strings.</param>
        public  void WriteListInFile(string path, List<string> list)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new ExceptionsLogger("Unknown text file format!");
            }

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (string l in list)
                {
                    sw.WriteLine(l);
                }
            }
        }
    }
}