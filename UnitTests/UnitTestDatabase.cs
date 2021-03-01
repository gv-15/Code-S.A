using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTestDatabase
    {
        private DB m_db;
        private String m_nombre;
        [TestMethod]
        public void TestAddTable()
        {
            m_db = new DB("DB");
            Table table = new Table(m_nombre);
            m_db.AddTable(table);
            int size = m_db.GetDBTable().Count;
            Assert.AreEqual(1,size);
        }
    }
}
