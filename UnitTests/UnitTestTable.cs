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
        TableColumn n = new TableColumn("prueba");
        TableColumn s = new TableColumn("prueba2");



        [TestMethod]
        public void TestAddColumn()
        {

            tabla.AddColumn(this.n);
            tabla.AddColumn(s);
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
            Table t3 = new Table("miTabla");
            TableColumn name = new TableColumn("name");
            TableColumn surname = new TableColumn("surname");
            t3.AddColumn(name);
            t3.AddColumn(surname);

            List<String> list = new List<String>();
            list.Add("Aitor");
            list.Add("Garcia");
            t3.AddRow(list);
            List<String> list2 = new List<String>();
            list2.Add("Amelia");
            list2.Add("Gonzalez");
            t3.AddRow(list2);

            List<String> l = name.GetColumns();
            Condition c = new Condition(Condition.Operations.equals, "Aitor", name);

            t3.DeleteRows(c); 
            int n = l.Count;
            
            Assert.AreEqual(1, n);
            Assert.AreEqual(l[0], "Amelia");
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


