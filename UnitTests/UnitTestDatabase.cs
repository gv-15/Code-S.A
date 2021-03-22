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
        public void TestSelectWhere()
        {
            m_db = new DB("db");
            Table t = new Table("Tabla");
            TableColumn columna1=new TableColumn("Coches");
            columna1.AddString("Renault");
            columna1.AddString("Nissan");
            columna1.AddString("Audi");
            t.AddColumn(columna1);
            TableColumn columna2 = new TableColumn("Propietarios");
            columna2.AddString("Miren");
            columna2.AddString("Claudia");
            columna2.AddString("Pedro");
            TableColumn columna3 = new TableColumn("Precio");
            columna3.AddString("2000");
            columna3.AddString("8520");
            columna3.AddString("10000");
            t.AddColumn(columna1);
            t.AddColumn(columna2);
            t.AddColumn(columna3);
            m_db.AddTable(t);
            Condition c = new Condition()


            
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

            table.AddRow(new List<string>() { "Gaizka", "22", "Boss&Drogo"});
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
