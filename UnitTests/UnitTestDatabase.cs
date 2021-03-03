using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTestDatabase
    {
        private DB m_db;
        [TestMethod]
        public void TestAddTable()
        {
            m_db = new DB("m_nombre");
            Table table = new Table("m_nombre2");
            m_db.AddTable(table);
            int size = m_db.GetDBTable().Count;
            Assert.AreEqual(1,size);
        }

        [TestMethod]
        public void TestLoad()
        {
           
        }

        [TestMethod]
        public void TestSave()
        {

        }
    }
}
