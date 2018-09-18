namespace Platforms_1
{
    using System;
    using System.Collections;
    using System.IO;

    public class Task
    {
        private ArrayList ReadFile(string path)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new Exception("Unknown text file format!");
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
                    throw new Exception($"Unknown contact! Check info in file '{path}'");
                }
            }

            return contactsList;
        }

        private void WriteArrayListContactsInFile(string path, ArrayList arrayList)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new Exception("Unknown text file format!");
            }

            using (StreamWriter sw = new StreamWriter("File1.txt", false, System.Text.Encoding.Default))
            {
                foreach (object element in arrayList)
                {
                    sw.WriteLine(element);
                }
            }
        }

        public void DoFirstTask()
        {
            ArrayList list = new ArrayList();
            list = this.ReadFile("Contacts.txt");

            list.Sort(new ContactsComparer());

            this.WriteArrayListContactsInFile("File.txt", list);
        }

        public void DoSecondTask()
        {
            // Please make it!
            // Don`t forget using LINQ :)

        }
    }
}