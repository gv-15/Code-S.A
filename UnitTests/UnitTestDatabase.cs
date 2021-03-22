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
        public void TestDropTable()
        {
            m_db = new DB("m_nombre");
            Table table1 = new Table("table1");
            Table table2 = new Table("table2");
            m_db.AddTable(table1);
            m_db.AddTable(table2);

            m_db.DropTable("table2");

            int i = m_db.GetDBTableList().Count;

            Assert.AreEqual(1, i);
            Assert.AreEqual("table1", m_db.GetDBTableList()[0].GetName());
        }

        [TestMethod]
        public void TestCreateTable()
        {
            m_db = new DB("m_nombre");

            List<TableColumn> list = new List<TableColumn>();
            TableColumn name = new TableColumn("name");
            TableColumn surname = new TableColumn("surname");
            list.Add(name);
            list.Add(surname);

            m_db.CreateTable("table3", list);

            int num = m_db.GetDBTableList().Count;

            Assert.AreEqual(1, num);
            Assert.AreEqual("table3", m_db.GetDBTableList()[0].GetName());
        }

        [TestMethod]
        public void TestInsert()
        {
            m_db = new DB("m_nombre");

            Table people = new Table("people");
            m_db.AddTable(people);

            TableColumn name = new TableColumn("name");
            TableColumn surname = new TableColumn("surname");
            Table t = m_db.GetTable(0);
            t.AddColumn(name);
            t.AddColumn(surname);

            List<String> values = new List<string>();
            values.Add("Adolfo");
            values.Add("García");

            m_db.Insert("people", people.GetColumns(), values);

            Assert.AreEqual(values,people.GetRowByIndex(0));
            Assert.AreEqual("Adolfo", people.GetColumns()[0].GetColumns()[0]);
            Assert.AreEqual("García", people.GetColumns()[1].GetColumns()[0]);
            int i = people.GetColumns()[0].GetColumns().Count;
            Assert.AreEqual(1, i);
            int i2 = people.GetColumns()[1].GetColumns().Count;
            Assert.AreEqual(1, i2);



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
        public void TestSelectColumns()
        {
            DB db = new DB("MyDB", "Admin", "SoyAdmin");
            Table newTable = new Table("newTable");
            TableColumn column = new TableColumn("a");
            column.AddString("name");
            column.AddString("surname");
            string table = newTable.GetName();
            newTable.AddColumn(column);
            db.AddTable(newTable);

            List<string> colName = new List<string>();
            colName.Add("a");
            Table newTable2 = new Table("b"); 
                
            newTable2=  db.SelectColumns(table, colName);

       


            Assert.AreEqual("['a']{'name'}{'surname'}",newTable2.ToString());

        }

        [TestMethod]
        public void TestLoad()
        {
            DB dbLoad = new DB("LoadedDatabase");

            dbLoad.Load(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "MyDB", "DBtoLoad").Save();


        }

        [TestMethod]
        public void TestDeleteFrom()
        {
          /*  DB db = new DB("MyDB", "Admin", "SoyAdmin");
            Table table = new Table("People");
            TableColumn column = new TableColumn("name");
            TableColumn column2 = new TableColumn("age");
            column.AddString("Ane");
            column.AddString("Lara");
            column2.AddString("18");
            column2.AddString("17");
            Condition condition = new Condition(Condition.Operations.equals, "Ane", column);
            int p = db.FindTableWithName(table.GetName());
           */
        }

    }
}
