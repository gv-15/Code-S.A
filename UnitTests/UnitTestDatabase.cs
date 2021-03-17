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
            int size = m_db.GetDBTableList().Count;
            Assert.AreEqual(1,size);
        }

        [TestMethod]
        public void TestSave()
        {

            DB db = new DB("MyDB","Admin","SoyAdmin");

            Table table = new Table("DatosAdmin");

            TableColumn tc1 = new TableColumn("NombreAdmin");

            tc1.AddString("Gaizka");

            TableColumn tc2 = new TableColumn("EdadAdmin");

            tc2.AddString("22");

            TableColumn tc3 = new TableColumn("PerrosAdmin");

            tc3.AddString("Boss");

            tc3.AddString("Drogo");

            table.AddColumn(tc1);

            table.AddColumn(tc2);

            table.AddColumn(tc3);

            db.AddTable(table);

            db.Save();

        }




    }
}
