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

            DB db = new DB("MyDB", "Admin", "Admin");

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

            IQuery query2 = Parser.Parse("INSERT INTO DatosAdmin VALUES ('Tamara','23','Xia');");
            Assert.IsTrue(query2 is Insert);
  

            IQuery query3 = Parser.Parse("SELECT EdadAdmin FROM DatosAdmin;"); 
            Assert.IsTrue(query3 is SelectColumns);
            string resultadoSelectColumns = "['EdadAdmin']{'22'}{'22'}{'22'}{'21'}";
            Assert.AreEqual(db.RunMiniSqlQuery("SELECT EdadAdmin FROM DatosAdmin;"),resultadoSelectColumns);
           
            IQuery query4 = Parser.Parse("SELECT EdadAdmin FROM DatosAdmin WHERE EdadAdmin=21;");
            Assert.IsTrue(query4 is SelectWhere);
            string resultadoSelectWhere = "['EdadAdmin']{'22'}{'22'}{'22'}";
            Assert.AreEqual(resultadoSelectWhere, db.RunMiniSqlQuery("SELECT EdadAdmin FROM DatosAdmin WHERE EdadAdmin=22;"));


            IQuery query5 = Parser.Parse("DROP TABLE DatosAdmin;");
            Assert.IsTrue(query5 is DropTable);
            Assert.IsNotNull(db.FindTableWithName("AdminRules"));
            db.RunMiniSqlQuery("DROP TABLE AdminRules;");
            Assert.AreEqual(-1,db.FindTableWithName("AdminRules")); //Compruebas que ese nombre ya no esta en la database
            

            IQuery query6 = Parser.Parse("CREATE TABLE Table2 (Nombre,Edad);");
            Assert.IsTrue(query6 is CreateTable);
            
            db.RunMiniSqlQuery("CREATE TABLE AdminRules (Nombre,Edad);");
            Assert.IsNotNull(db.FindTableWithName("AdminRules"));
            Assert.AreEqual(1, db.FindTableWithName("AdminRules"));
            string resultadoCreateTable = "['Nombre','Edad']";
            Assert.AreEqual(resultadoCreateTable , db.GetTableWithName("AdminRules").ToString());
            
            db.RunMiniSqlQuery("CREATE TABLE MyTable (Name TEXT,Age INT,Address TEXT);");
            string resultadoCreateTable2 = "['Name','Age','Address']";
            Assert.AreEqual(resultadoCreateTable2, db.GetTableWithName("MyTable").ToString());

            IQuery query7 = Parser.Parse("DELETE FROM Table1 WHERE Edad=21;");
            Assert.IsTrue(query7 is DeleteFrom);
           

            IQuery query8 = Parser.Parse("SELECT * FROM DatosAdmin WHERE EdadAdmin=22;");
            Assert.IsTrue(query8 is SelectAllWhere);

            IQuery query9 = Parser.Parse("CLOSE;");
            Assert.IsTrue(query9 is Close);


            IQuery query10 = Parser.Parse("UPDATE Employees SET Name='Patxi',Surname='Elorriaga' WHERE Id=2;");
            Assert.IsTrue(query10 is Update);
            db.RunMiniSqlQuery("UPDATE DatosAdmin SET EdadAdmin=24,PerrosAdmin='Kong' WHERE EdadAdmin=21;");
            string resultadoUpdate = "['NombreAdmin','EdadAdmin','PerrosAdmin']{Gaizka,'22',Boss&Drogo}{Edurne,'22',Zuri}{Iker,'22',Null}{Xabi,'24','Kong'}";
            Assert.AreEqual(resultadoUpdate, db.RunMiniSqlQuery("SELECT * FROM DatosAdmin;"));

            IQuery query11 = Parser.Parse("ADD USER ('Eva','1234',Employee);");
            Assert.IsTrue(query11 is AddUser);

            IQuery query12 = Parser.Parse("CREATE SECURITY PROFILE Employee;");
            Assert.IsTrue(query12 is CreateSecurityProfile);
             
            IQuery query13 = Parser.Parse("DROP SECURITY PROFILE securityProfile;");
            Assert.IsTrue(query13 is DropSecurityProfile);
              
            IQuery query14 = Parser.Parse("GRANT SELECT ON EmployeesPublic TO Employee;");
            Assert.IsTrue(query14 is Grant);
          
            IQuery query15 = Parser.Parse("REVOKE privilegeType ON table TO securityProfile;");
            Assert.IsTrue(query15 is Revoke);
               
            IQuery query16 = Parser.Parse("DELETE USER user;");
            Assert.IsTrue(query16 is DeleteUser);

            IQuery query17 = Parser.Parse("Database1,admin,admin");
            Assert.IsTrue(query17 is Login);

        }



    }
}
