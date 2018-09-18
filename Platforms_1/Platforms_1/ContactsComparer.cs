namespace Platforms_1
{
    using System.Collections;

    public class ContactsComparer: IComparer
    {
        public int Compare(object o1, object o2)
        {
            return new CaseInsensitiveComparer().Compare((o1 as Contact).Name, (o2 as Contact).Name);
        }
    }
}
