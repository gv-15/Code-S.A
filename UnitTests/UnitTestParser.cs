using Database;
using Database.MiniSqlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTestParser
    {
        [TestMethod]
        public void Parsing()
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

            TableColumn tc4 = new TableColumn("GG");

            TableColumn tc5 = new TableColumn("WELLPLAY");

            List<TableColumn> tableColumns2 = new List<TableColumn>() { tc4, tc5};

            Table table2 = new Table("AdminRules", tableColumns2);

            table2.AddRow(new List<string>() { "G", "a"});
            table2.AddRow(new List<string>() { "E", "d"});

            db.AddTable(table);
            db.AddTable(table2);

            IQuery query = Parser.Parse("SELECT * FROM DatosAdmin;");
            Assert.IsTrue(query is SelectAll);
            Assert.AreEqual("DatosAdmin", (query as SelectAll).Table());
            Assert.AreEqual(db.RunMiniSqlQuery("SELECT * FROM DatosAdmin;"),table.ToString());

            IQuery query2 = Parser.Parse("INSERT INTO DatosAdmin VALUES (Tamara,23,Xia);");
            Assert.IsTrue(query2 is Insert);
            db.RunMiniSqlQuery("INSERT INTO DatosAdmin VALUES (Tamara,23,Xia);");
            string resultadoInsert = "['NombreAdmin','EdadAdmin','PerrosAdmin']{'Gaizka','22','Boss&Drogo'}{'Edurne','22','Zuri'}{'Iker','22','Null'}{'Xabi','21','Null'}{'Tamara','23','Xia'}";
            //Assert.AreEqual(resultadoInsert, table.ToString());

            IQuery query3 = Parser.Parse("SELECT EdadAdmin FROM DatosAdmin;");
            Assert.IsTrue(query3 is SelectColumns);

            IQuery query4 = Parser.Parse("SELECT Edad FROM Table1 WHERE Edad = 18;");
            Assert.IsTrue(query4 is SelectWhere);

            IQuery query5 = Parser.Parse("DROP TABLE Table1;");
            Assert.IsTrue(query5 is DropTable);
          


            IQuery query6 = Parser.Parse("CREATE TABLE Table2 (Nombre,Edad);");
            Assert.IsTrue(query6 is CreateTable);

            IQuery query7 = Parser.Parse("DELETE FROM Table1 WHERE Edad = 18;");
            Assert.IsTrue(query7 is DeleteFrom);


        }


    }
}
