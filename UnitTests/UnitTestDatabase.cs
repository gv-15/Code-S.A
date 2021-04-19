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
            Assert.AreEqual(1, size);
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

            
            Assert.AreEqual("table3", m_db.GetDBTableList()[0].GetName());
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
           


            
        }

        [TestMethod]
        public void TestSave()
        {

            DB db = new DB("MyDB", "Admin", "SoyAdmin");

            TableColumn tc1 = new TableColumn("NombreAdmin");

            TableColumn tc2 = new TableColumn("EdadAdmin");

            TableColumn tc3 = new TableColumn("PerrosAdmin");

            List<TableColumn> tableColumns = new List<TableColumn>() { tc1, tc2, tc3 };

            Table table = new Table("DatosAdmin", tableColumns);

            table.AddRow(new List<string>() { "Gaizka", "22", "Boss&Drogo" });
            table.AddRow(new List<string>() { "Edurne", "22", "Zuri" });
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

            Assert.AreEqual("['a']{name}{surname}", newTable2.ToString());

         
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

            DB db = new DB("MyDB", "Admin", "SoyAdmin");
            Table newTable = new Table("newTable");
            TableColumn column = new TableColumn("a");
            column.AddString("name");
            column.AddString("surname");
            string table = newTable.GetName();
            newTable.AddColumn(column);
            db.AddTable(newTable);
            List<string> col = column.GetColumns();
            Condition condition = new Condition(Condition.Operations.equals, "name", column.GetTableColumnName());
            
            db.DeleteFrom(table,col,condition);

            Assert.AreEqual("surname",col[0]);

           
        }

       
        [TestMethod]
        public void TestFindTableWithName()
        {
            m_db = new DB("db");
            Table table = new Table("table");
            Table table2 = new Table("table2");
            Table table3 = new Table("table3");
            m_db.AddTable(table);
            m_db.AddTable(table2);
            m_db.AddTable(table3);

            int i = m_db.FindTableWithName("table2");

            Assert.AreEqual(1, i);


        }

        [TestMethod]
        public void TestSelectAllWhere()
        {
            m_db = new DB("db");
            Table t = new Table("Tabla");
            m_db.AddTable(t);
            TableColumn columna1 = new TableColumn("Coches");
            columna1.AddString("Renault");
            columna1.AddString("Nissan");
            columna1.AddString("Audi");
            t.AddColumn(columna1);
            TableColumn columna2 = new TableColumn("Propietarios");
            columna2.AddString("Miren");
            columna2.AddString("Claudia");
            columna2.AddString("Pedro");
            t.AddColumn(columna2);


            Condition c = new Condition(Condition.Operations.equals, "Audi", "Coches");
            Table table = m_db.SelectAllWhere("Tabla", c);
            String s = table.ToString();
            Assert.AreEqual("['Coches','Propietarios']{Audi,Pedro}", s);
          
        }
        [TestMethod]
        public void TestSelectAll()
        {

            DB db = new DB("MyDB", "Admin", "SoyAdmin");
            Table newTable = new Table("newTable");
            TableColumn column = new TableColumn("a");
            column.AddString("name");
            column.AddString("surname");
            string table = newTable.GetName();
            newTable.AddColumn(column);
            db.AddTable(newTable);
            Table newTable2 = new Table("newTable2");

            newTable2 = db.SelectAll(table);

            Assert.AreEqual("['a']{name}{surname}",newTable2.ToString());

        }

        [TestMethod]
        public void TestUpdate()
        {
            DB db = new DB("MyDB", "Admin", "SoyAdmin");
            Table t = new Table("People");
            TableColumn column = new TableColumn("name");
            column.AddString("Juan");
            column.AddString("Pedro");
            TableColumn column2 = new TableColumn("age");
            column2.AddString("20");
            column2.AddString("21");
            string table = t.GetName();
            t.AddColumn(column);
            t.AddColumn(column2);
            db.AddTable(t);
            string colName = column.GetTableColumnName();
            List<string> cols = new List<string>();
            cols.Add(colName);
            Condition condition = new Condition(Condition.Operations.equals, "Juan", column.GetTableColumnName());
            List<string> values = new List<string>();
            values.Add("David");

            db.Update(cols, values, table, condition);
          


            Assert.AreEqual("'David'",column.GetColumns()[0]);
            Assert.AreEqual("20", column2.GetColumns()[0]);


           

        }
    }

}