using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTableColumn
    {
       [TestMethod]

        public void TestDeleteFrom()
        {
            TableColumn names = new TableColumn("myColumn");
            names.AddString("Ane");
            names.AddString("Joseba");

            names.DeleteFrom("Ane");

            int num = names.GetColumns().Count;

            Assert.AreEqual(1, num);

            Boolean encontrado = false;

            foreach (String element in names.GetColumns())
            { 
                if (element.Equals("Ane"))
                {   
                    encontrado = true;
                }
            }
            
            if(encontrado)

                Assert.Fail();
        }

        [TestMethod]
        public void TestAddColumn()
        {
            TableColumn names = new TableColumn("myColumn");
            names.AddString("Ane");

            int num = names.GetColumns().Count;

            Assert.AreEqual(1,num);
        }
        [TestMethod]
        public void TestDeleteCondition()
        {

            TableColumn column = new TableColumn("name");
            column.AddString("Ane");
            column.AddString("Lara");
            Condition condition = new Condition(Condition.Operations.equals, "Ane", column);

            List<String> names = column.GetColumns();
            column.DeleteCondition(names, condition);

            Assert.AreEqual(1, column.GetColumns().Count);

            Boolean find = false;
            foreach (String element in names)
            {
                if (element.Equals("Ane"))
                {
                    find = true;
                }
            }

            if (find)
                Assert.Fail();

            TableColumn column2 = new TableColumn("numbers");
            column2.AddString("7");
            column2.AddString("10");
            Condition condition1 = new Condition(Condition.Operations.min, "8", column2);

            List<String> numbers = column2.GetColumns();
            column2.DeleteCondition(numbers, condition1);
            foreach (String element in column2.GetColumns())
            {

                Assert.AreEqual("10", element);

            }
            Assert.AreEqual(1, column2.GetColumns().Count);
        }

            
        [TestMethod]
        public void TestSelect()
        {
            TableColumn column = new TableColumn("name");
            column.AddString("adolfo");
            column.AddString("eider");
            Condition condition = new Condition(Condition.Operations.equals, "adolfo", column);

            List<String> col = column.GetColumns();

            List<String> l = column.Select(col, condition);

            foreach (String element in l)
            {
                Assert.AreEqual(element, "adolfo");
            }

            Assert.IsTrue(l.Count > 0);

            TableColumn column2 = new TableColumn("numbers");
            column2.AddString("6");
            column2.AddString("9");
            Condition condition2 = new Condition(Condition.Operations.min, "7", column2);

            List<String> numbers = column2.GetColumns();
            List <String> list = column2.Select(numbers, condition2);
            foreach (String element in list)
            {

                Assert.AreEqual("6", element);

            }
          
        }

        [TestMethod]

        public void TestGetPositions()
        {
            //List<int> positions = new List<int>();
            TableColumn column = new TableColumn("name");
            column.AddString("adolfo");
            column.AddString("eider");
            column.AddString("pepe");
            Condition condition = new Condition(Condition.Operations.equals, "pepe", column);

            
            List<int> positions = column.GetPositions(condition);

            foreach (int element in positions)
            {
                Assert.AreEqual(2, element);
            }
            
        }

        [TestMethod]

        public void TestGetValues()
        {
            TableColumn list = new TableColumn("numbers");
            list.AddString("0");
            list.AddString("1");
            list.AddString("2");
            list.AddString("3");
            List<int> positions = new List<int>();
            
            positions.Add(1);
      
            List<string> list2 = new List<string>();
            list2 = list.GetValues(positions);

            string resultado = list2[0];

            
            Assert.AreEqual(1, int.Parse(resultado));
        }
    }
}

