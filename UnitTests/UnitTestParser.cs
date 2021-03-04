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
            // IQuery query = Parser.Parse("Select")
            IQuery query = Parser.Parse("SELECT * FROM Table1;");
            Assert.IsTrue(query is SelectAll);
            Assert.AreEqual("Table1", (query as SelectAll).Table());


        }


    }
}
