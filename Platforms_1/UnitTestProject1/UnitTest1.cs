using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        //MailContactTests
        [TestMethod]
        public void MailContactConstructor1Test()
        {
            Platforms_1.MailContact user = new Platforms_1.MailContact("Oleh:Lancelot@gmail.com");
            Assert.AreEqual("Oleh", user.Name);
            Assert.AreEqual("Lancelot@gmail.com", user.MailAddress);
        }
        [TestMethod]
        public void MailContactConstructor2Test()
        {
            Platforms_1.MailContact user = new Platforms_1.MailContact();
            Assert.AreEqual("", user.Name);
            Assert.AreEqual("-@-", user.MailAddress);
        }
        [TestMethod]
        public void MailContactConstructor3Test()
        {
            Platforms_1.MailContact user = new Platforms_1.MailContact("Oleh", "Lancelot@gmail.com");
            Assert.AreEqual("Oleh", user.Name);
            Assert.AreEqual("Lancelot@gmail.com", user.MailAddress);
        }
        [TestMethod]
        public void MailParseLineTest()
        {
            Platforms_1.MailContact user = new Platforms_1.MailContact();
            user.ParseLine("Oleh:Lancelot@gmail.com");
            Assert.AreEqual("Oleh", user.Name);
            Assert.AreEqual("Lancelot@gmail.com", user.MailAddress);
        }
        [TestMethod]
        public void MailToStringTest()
        {
            Platforms_1.MailContact user = new Platforms_1.MailContact();
            user.ParseLine("Oleh:Lancelot@gmail.com");
            string expected = "Name: Oleh - \tmail address: \tLancelot@gmail.com";
            Assert.AreEqual(expected, user.ToString());
        }
        //PhoneContactTests
        public void PhoneContactConstructor1Test()
        {
            Platforms_1.PhoneContact user = new Platforms_1.PhoneContact("Oleh:99999");
            Assert.AreEqual("Oleh", user.Name);
            Assert.AreEqual("99999", user.PhoneNumber);
        }
        [TestMethod]
        public void PhoneContactConstructor2Test()
        {
            Platforms_1.PhoneContact user = new Platforms_1.PhoneContact();
            Assert.AreEqual("", user.Name);
            Assert.AreEqual("00000", user.PhoneNumber);
        }
        [TestMethod]
        public void PhoneContactConstructor3Test()
        {
            Platforms_1.PhoneContact user = new Platforms_1.PhoneContact("Oleh","99999");
            Assert.AreEqual("Oleh", user.Name);
            Assert.AreEqual("99999", user.PhoneNumber);
        }
        [TestMethod]
        public void PhoneParseLineTest()
        {
            Platforms_1.PhoneContact user = new Platforms_1.PhoneContact();
            user.ParseLine("Oleh:99999");
            Assert.AreEqual("Oleh", user.Name);
            Assert.AreEqual("99999", user.PhoneNumber);
        }
        [TestMethod]
        public void PhoneToStringTest()
        {
            Platforms_1.PhoneContact user = new Platforms_1.PhoneContact();
            user.ParseLine("Oleh:99999");
            string expected = "Name: Oleh - \tPhone Number: \t99999";
            Assert.AreEqual(expected, user.ToString());
        }
        //SkypeContactTests
        public void SkypeContactConstructor1Test()
        {
            Platforms_1.SkypeContact user = new Platforms_1.SkypeContact("Oleh:SkypeLogin1");
            Assert.AreEqual("Oleh", user.Name);
            Assert.AreEqual("SkypeLogin1", user.SkypeName);
        }
        [TestMethod]
        public void SkypeContactConstructor2Test()
        {
            Platforms_1.SkypeContact user = new Platforms_1.SkypeContact();
            Assert.AreEqual("", user.Name);
            Assert.AreEqual("", user.SkypeName);
        }
        [TestMethod]
        public void SkypeContactConstructor3Test()
        {
            Platforms_1.SkypeContact user = new Platforms_1.SkypeContact("Oleh","SkypeLogin1");
            Assert.AreEqual("Oleh", user.Name);
            Assert.AreEqual("SkypeLogin1", user.SkypeName);
        }
        [TestMethod]
        public void SkypeParseLineTest()
        {
            Platforms_1.SkypeContact user = new Platforms_1.SkypeContact();
            user.ParseLine("Oleh:SkypeLogin1");
            Assert.AreEqual("Oleh", user.Name);
            Assert.AreEqual("SkypeLogin1", user.SkypeName);
        }
        [TestMethod]
        public void SkypeToStringTest()
        {
            Platforms_1.SkypeContact user = new Platforms_1.SkypeContact();
            user.ParseLine("Oleh:SkypeLogin1");
            string expected = "Name: Oleh - \tskype name: \tSkypeLogin1";
            Assert.AreEqual(expected, user.ToString());
        }
        //ContactsComparerTest
        [TestMethod]
        public void ContactComparertest()
        {
            Platforms_1.PhoneContact user1 = new Platforms_1.PhoneContact("Oleh", "99999");
            Platforms_1.SkypeContact user2 = new Platforms_1.SkypeContact("Oleh", "SkypeLogin1");
            Platforms_1.MailContact user3 = new Platforms_1.MailContact("Helo", "lancelot@gmail.com");
            Platforms_1.ContactsComparer compare = new Platforms_1.ContactsComparer();
            int result1 = compare.Compare(user1, user2);
            int result2 = compare.Compare(user2, user3);
            Assert.AreEqual(0, result1);
            Assert.AreEqual(1, result2);
        }
    }
}
