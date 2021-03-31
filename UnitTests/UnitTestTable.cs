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
        public void TestDeleteColumn()
        {
            TableColumn tc1 = new TableColumn("NombreAdmin");

            TableColumn tc2 = new TableColumn("EdadAdmin");

            TableColumn tc3 = new TableColumn("PerrosAdmin");

            List<TableColumn> tableColumns = new List<TableColumn>() { tc1, tc2, tc3 };

            Table table = new Table("DatosAdmin", tableColumns);

            table.AddRow(new List<string>() { "Gaizka", "22", "Boss&Drogo" });
            table.AddRow(new List<string>() { "Edurne", "22", "Zuri" });
            table.AddRow(new List<string>() { "Iker", "22", "Null" });
            table.AddRow(new List<string>() { "Xabi", "21", "Null" });

            List<TableColumn> tc = table.GetColumns();
            Condition c = new Condition(Condition.Operations.equals, "Iker", "NombreAdmin");
            table.DeleteColumn(c);
            int h = table.GetColumns().Count;
            Assert.AreEqual(3, h);
            Assert.AreEqual(3, tc[0].GetColumns().Count); 
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

            Condition c = new Condition(Condition.Operations.equals, "Ana", "nombre");

            List<int> positions = t2.SelectRowsPositions(c);
            int p = positions.Count;
            Assert.AreEqual(1, p);


        }

    }


}
