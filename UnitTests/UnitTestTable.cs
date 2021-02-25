using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTable
    {


        //Table CreateTestTable()
        //{

        //}
        Table tabla = new Table("tabla");
        TableColumn t = new TableColumn("prueba");
        TableColumn t2 = new TableColumn("prueba2");
        


        [TestMethod]
        public void TestAddColumn()
        {
            
            tabla.AddColumn(t2);
            tabla.AddColumn(t);
            int n = tabla.GetColumns().Count;
            Assert.AreEqual(2, n);
        }

        [TestMethod]
        public void TestSelectRows()
        {
            t.GetColumn().Add("pru");
            t2.GetColumn().Add("eba");

            tabla.AddColumn(t);
            tabla.AddColumn(t2);
            Condition c = new Condition(Condition.Operations.equals, "pru", t);

            List<String> i = tabla.SelectRows(c);
            foreach (String p in i) {
                foreach (TableColumn t in tabla.GetColumns()) {
                    foreach (String s in t.GetColumn())
                    {
                        if (s.Equals(p))
                        {
                           Assert.AreEqual(s, p);
                        }


                    }
                }
            } 
        }


        [TestMethod]
        public void TestDeleteRows()
        {
            tabla.AddColumn(t);
            Condition c = new Condition(Condition.Operations.equals, "prueba", t);

            tabla.DeleteRows(tabla.GetColumns(), c);
            int n = tabla.GetColumns().Count;
            Assert.AreEqual(1, n);
        }

    }


}


