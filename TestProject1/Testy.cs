using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLOB;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading;


namespace TestProject1
{
    [TestClass]
    public class Testy
    {
        private string connectionString,table,topic,text;
        CLOB.CLOB testClob;
        public Testy()
        {
            connectionString = @"
                Data Source=.;
                Database=clob;
                Integrated Security=True";
            table = "testowa1";
            text = "tresc";
            topic = "nazwa";
            testClob = new CLOB.CLOB(connectionString, table, text, topic);
        }

        private TestContext testContextInstance;



        [TestMethod]
        public void Test1_SprawdzenieWyszukiwanieUdane()
        {
            string[] wynik = testClob.find("TestowyCiag1");
            Assert.AreEqual("TestowyDokument1",wynik[0]);
        }

        [TestMethod]
        public void Test2_SprawdzenieWyszukiwanieNieudane()
        {
            string[] wynik = testClob.find("TestowyCiag1242544");
            Assert.IsTrue(wynik.Length==0);
        }

        [TestMethod]
        public void Test3_SprawdzenieDodaniaPliku()
        {
            testClob.addDocument("C:\\Users\\Administrator\\Documents\\Visual Studio 2008\\Projects\\ConsoleApplication3\\TestowyDokument1.txt","TestowyDokument");
            Thread.Sleep(5);
            string[] wynik = testClob.find("ZawartoscTestowegoDokumentu1");
            Assert.AreEqual(wynik[0], "TestowyDokument");
        }

        [TestMethod]
        public void Test4_SprawdzenieUsunieciaPliku()
        {
            testClob.addDocument("C:\\Users\\Administrator\\Documents\\Visual Studio 2008\\Projects\\ConsoleApplication3\\TestowyDokument2.txt", "TestowyDokument2");
            Thread.Sleep(5);
            testClob.deleteDocument("TestowyDokument2");
            string[] wynik = testClob.find("ZawartoscTestowegoDokumentu2");
            Assert.IsTrue(wynik.Length == 0);
        }
        [TestMethod]
        public void Test5_SprawdzenieUsunieciaPlikuZWyszukiwaniem()
        {
            testClob.addDocument("C:\\Users\\Administrator\\Documents\\Visual Studio 2008\\Projects\\ConsoleApplication3\\TestowyDokument2.txt", "TestowyDokument2");
            testClob.deleteDocumentWith("ZawartoscTestowegoDokumentu2");
            string[] wynik = testClob.find("ZawartoscTestowegoDokumentu2");
            Assert.IsTrue(wynik.Length == 0);
        }
    }
}
