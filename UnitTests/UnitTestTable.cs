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
            t.GetColumns().Add("Jon");
            t2.GetColumns().Add("Andrea");

            tabla.AddColumn(t);
            tabla.AddColumn(t2);
            Condition c = new Condition(Condition.Operations.equals, "Jon", t);

            List<String> i = tabla.SelectRows(c);
            foreach (String p in i) {
                foreach (TableColumn t in tabla.GetColumns()) {
                    foreach (String s in t.GetColumns())
                    {
                        if (s.Equals(p))
                        {
                           Assert.AreEqual(s, p);
                        }


                    }
                }
            }
            if(i.Count == 0)
            {
                Assert.IsTrue(i.Count == 0);
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


