namespace Platforms_1
{
    using System.Collections;

    /// <summary>
    /// Class for comparing two contacts.
    /// </summary>
    /// <remarks>
    /// Realize IComparer interface to make sorting any colection of Contacts.
    /// </remarks>
    public class ContactsComparer: IComparer
    {

        /// <summary>
        /// Compares two Contacts.
        /// </summary>
        /// <param name="o1"> the first object to compare.</param>        
        /// <param name="o2"> The second object to compare.</param>
        /// <returns>
        /// Returns '1' if first bigger than second, '0' if tey are equal and '-1' if first smaller then second.
        /// </returns>
        public int Compare(object o1, object o2)
        {
            return new CaseInsensitiveComparer().Compare((o1 as Contact).Name, (o2 as Contact).Name);
        }
    }
}
