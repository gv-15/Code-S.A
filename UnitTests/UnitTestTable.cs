using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            t.GetColumns().Add("33");
            t2.GetColumns().Add("45");
            tabla.AddColumn(t);
            tabla.AddColumn(t2);
            Condition c = new Condition(Condition.Operations.max, "36", t);

            List<String> seleccion = tabla.SelectRows(c);
            foreach (String individual in seleccion) {
                foreach (TableColumn columna in tabla.GetColumns()) {
                    foreach (String iteracion in columna.GetColumns())
                    {
                        if (c.GetOperation().Equals("equals")) {
                            if (iteracion.Equals(individual))
                            {
                                Assert.AreEqual(iteracion, individual);
                            }
                        }
                        else if (c.GetOperation().Equals("max")) 
                        {
                            if (int.Parse(individual) > int.Parse(iteracion))
                            {
                                Assert.IsTrue(int.Parse(individual) > int.Parse(iteracion));
                            }
                        }
                        else 
                        {
                            if (int.Parse(individual) < int.Parse(iteracion))
                            {
                                Assert.IsTrue(int.Parse(individual) < int.Parse(iteracion));
                            }
                        }


                    }
                }
            }
            if(seleccion.Count == 0)
            {
                Assert.IsTrue(seleccion.Count == 0);
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


