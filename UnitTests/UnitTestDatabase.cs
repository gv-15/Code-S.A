using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTestDatabase
    {
        private UnitTestDatabase m_db;
        private String m_nombre;
        [TestMethod]
        public void TestAddTable()
        {
            m_db = new UnitTestDatabase();
            Table table = new Table(m_nombre);
            
        }
    }
}
