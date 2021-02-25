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

            int num = names.GetColumn().Count;

            Assert.AreEqual(1, num);

            Boolean encontrado = false;

            foreach (String element in names.GetColumn())
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

            int num = names.GetColumn().Count;

            Assert.AreEqual(1,num);
        }
        [TestMethod]
        public void TestDeleteCondition()
        {

            TableColumn column = new TableColumn("name");
            column.AddString("Ane");
            column.AddString("Lara");
            Condition condition = new Condition(Condition.Operations.equals, "Ane", column);

            List<String> names = column.GetColumn();
            column.DeleteCondition(names, condition);

            Assert.AreEqual(1, column.GetColumn().Count);

            TableColumn column2 = new TableColumn("numbers");
            column2.AddString("7");
            column2.AddString("10");
            Condition condition1 = new Condition(Condition.Operations.min, "8", column2);

            List<String> numbers = column2.GetColumn();
            column2.DeleteCondition(numbers, condition1);
            foreach (String element in column2.GetColumn())
            {

                Assert.AreEqual("10", element);

            }
            Assert.AreEqual(1, column2.GetColumn().Count);
        }

            
        [TestMethod]
        public void TestSelect()
        {
            TableColumn column = new TableColumn("name");
            column.AddString("adolfo");
            column.AddString("eider");
            Condition condition = new Condition(Condition.Operations.equals, "adolfo", column);

            List<String> col = column.GetColumn();

            List<String> l = column.Select(col, condition);

            foreach (String element in l)
            {
                Assert.AreEqual(element, "adolfo");
            }

            Assert.IsTrue(l.Count > 0);
        }
    }
}
