using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

            TableColumn tc1 = new TableColumn("NombreAdmin");

            TableColumn tc2 = new TableColumn("EdadAdmin");

            TableColumn tc3 = new TableColumn("PerrosAdmin");

            List<TableColumn> tableColumns = new List<TableColumn>() {tc1,tc2,tc3};

            Table table = new Table("DatosAdmin", tableColumns);

            table.AddRow(new List<string>() { "Gaizka", "22", "Boss&Drogo" });
            table.AddRow(new List<string>() {"Edurne", "22", "Zuri"});
            table.AddRow(new List<string>() { "Iker", "22", "Null" });
            table.AddRow(new List<string>() { "Xabi", "21", "Null" });

            db.AddTable(table);

            db.Save();

        }

        [TestMethod]
        public void TestLoad()
        {
            DB dbLoad = new DB("LoadedDatabase");

            dbLoad.Load(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "MyDB","DBtoLoad").Save();
            

        }




    }
}
