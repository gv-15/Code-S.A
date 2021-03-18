using Database;
using Database.MiniSqlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTestParser
    {
        [TestMethod]
        public void Parsing()
        {
            IQuery query = Parser.Parse("SELECT * FROM Table1;");
            Assert.IsTrue(query is SelectAll);
            Assert.AreEqual("Table1", (query as SelectAll).Table());

            IQuery query2 = Parser.Parse("INSERT INTO Table1 VALUES (Gaizka,22);");
            Assert.IsTrue(query2 is Insert);

            IQuery query3 = Parser.Parse("SELECT Edad FROM Table1;");
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
