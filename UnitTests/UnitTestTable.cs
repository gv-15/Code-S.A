using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTable
    {

        Table tabla = new Table("tabla");
        TableColumn t = new TableColumn("prueba");
        

        [TestMethod]
        public void TestAddColumn()
        {
            TableColumn t2 = new TableColumn("prueba2");
            tabla.AddColumn(t);
            int n = tabla.GetColumns().Count;
            Assert.AreEqual(2, n);
        }

        [TestMethod]
        public void TestSelectRows()
        {
            Condition c = new Condition(Condition.Operations.equals, "prueba", t);
            List<int> n= tabla.SelectRows(tabla.GetColumns(), c);
            Assert.IsNotNull(n);
            Assert.AreEqual(1, n.Count);
        }

        [TestMethod]
        public void TestDeleteRows()
        {
            Condition c = new Condition(Condition.Operations.equals, "prueba", t);

            tabla.DeleteRows(tabla.GetColumns(), c);
            int n = tabla.GetColumns().Count;
            Assert.AreEqual(1, n);
        }

    }


}


