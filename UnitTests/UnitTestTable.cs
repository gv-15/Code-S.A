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



        /*
        [TestMethod]
        public void TestDeleteColumn()
        {
            Table table = new Table("table");
            TableColumn name = new TableColumn("namea");
            TableColumn age = new TableColumn("age");
            table.AddColumn(name);
            table.AddColumn(age);
            name.AddString("Aitor");
            name.AddString("Laia");
            List<TableColumn> tc = table.GetColumns();
            Condition c = new Condition(Condition.Operations.equals, "Laia", name.GetTableColumnName());
            table.DeleteColumn(c);
            int h = table.GetColumns().Count;
            Assert.AreEqual(1, h);
            Assert.AreEqual(age, tc[0]); 
        }*/

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

            Condition c = new Condition(Condition.Operations.equals, "Ana", "nombre");

            List<int> positions = t2.SelectRowsPositions(c);
            int p = positions.Count;
            Assert.AreEqual(1, p);


        }

    }


}
