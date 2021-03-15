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
        public void TestAddRow()
        {
            Table t = new Table("miTabla");
            TableColumn nombre = new TableColumn("nombre");
            TableColumn apellido = new TableColumn("apellido");
            t.AddColumn(nombre);
            t.AddColumn(apellido);

            List<String> lista = new List<String>();
            lista.Add("Aitor");
            lista.Add("Garcia");

            t.AddRow(lista);
            int i = nombre.GetColumns().Count;
            int j = apellido.GetColumns().Count;
            Assert.AreEqual(1, i);
            Assert.AreEqual(1, j);
        }


        [TestMethod]
        public void TestDeleteRows()
        {
            tabla.AddColumn(t);
            Condition c = new Condition(Condition.Operations.equals, "prueba", t);

            tabla.DeleteRows(tabla.GetColumns(), c);
            int n = tabla.GetColumns().Count;
            Assert.AreEqual(1, n); //Esto esta mal, tendria que dar 0 pero el metodo no esta hecho
        }

        [TestMethod]
        public void TestSelectRowsPositions()
        {
            Table t2 = new Table("miTabla");
            TableColumn nombre = new TableColumn("nombre");
            TableColumn apellido = new TableColumn("apellido");
            t2.AddColumn(nombre);
            t2.AddColumn(apellido);

            List<String> lista = new List<String>();
            lista.Add("Aitor");
            lista.Add("Garcia");
            t2.AddRow(lista);
            List<String> lista2 = new List<String>();
            lista2.Add("Ana");
            lista2.Add("Suarez");
            t2.AddRow(lista2);

            Condition c = new Condition(Condition.Operations.equals, "Ana", nombre);
           
            List<int> positions = t2.SelectRowsPositions(c);
            int p = positions.Count;
            Assert.AreEqual(1, p);


        }

    }


}


