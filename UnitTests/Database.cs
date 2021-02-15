using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class Database
    {
        private Database m_db;
        private String m_nombre;
        [TestMethod]
      
        public void TestAddTable()
        {
            m_db = new Database();
            Table table = new Table(m_nombre);
            
        }
    }
}
