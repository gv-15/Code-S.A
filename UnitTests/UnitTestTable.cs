using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTable
    {

        Table tabla = new Table("tabla");
        TableColumn t = new TableColumn("prueba");
        TableColumn t2 = new TableColumn("prueba2");

        [TestMethod]
        public void TestAddColumn()
        {
            
            tabla.AddColumn(t);
            int n = tabla.GetColumns().Count;
            Assert.AreEqual(1, n);
        }

        [TestMethod]
        public void TestSelectRows()
        {

        }

        [TestMethod]
        public void TestDeleteRows()
        {

        }

    }


}


