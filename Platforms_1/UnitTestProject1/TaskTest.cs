using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using System.IO;
namespace UnitTestProject1
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void ReadTest()
        {
            Platforms_1.Task user = new Platforms_1.Task();
            ArrayList list1 = user.ReadFile("RT.txt");
            Assert.AreEqual(new Platforms_1.MailContact("Endy:endyCoolBoy@ukr.net").ToString(), list1[0].ToString());
            Assert.AreEqual(new Platforms_1.PhoneContact("Andrew:12345").ToString(), list1[1].ToString());
        }
        [TestMethod]
        public void WrireTest()
        {
            Platforms_1.Task user = new Platforms_1.Task();
            ArrayList list1 = user.ReadFile("RT.txt");
            user.WriteArrayListContactsInFile("WT.txt", list1);
            string[] list2 = File.ReadAllLines("WT.txt");
            Assert.AreEqual(list1[0].ToString(), list2[0]);
        }
        [TestMethod]
        public void DictionaryAndOutTestTest()
        {

            Platforms_1.Task user = new Platforms_1.Task();
            ArrayList list1 = user.ReadFile("RT.txt");
            Dictionary<string, List<string>> His = user.GroupArrayListContacts(list1);
            user.WriteContactsDictionaryInFIle("DT.txt", His);
            string[] list2 = File.ReadAllLines("DT.txt");
            Assert.AreEqual("Endy: 	endyCoolBoy@ukr.net, 12121, ", list2[0]);
        }
        [TestMethod]
        public void CreateListTest()
        {
            Platforms_1.Task user = new Platforms_1.Task();
            ArrayList list1 = user.ReadFile("RT.txt");
            List<string> names1 = new List<string>();
            names1 = user.UsersWithOnlyPhones(list1);
            Assert.AreEqual(3, names1.Count);
        }
        [TestMethod]
        public void WriteListTest()
        {
            Platforms_1.Task user = new Platforms_1.Task();
            ArrayList list1 = user.ReadFile("RT.txt");
            List<string> names1 = new List<string>();
            names1 = user.UsersWithOnlyPhones(list1);
            user.WriteListInFile("LT.txt", names1);
            string[] arr = File.ReadAllLines("LT.txt");
            Assert.AreEqual(arr[2], names1[2]);

        }
    }
}
