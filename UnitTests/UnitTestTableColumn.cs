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
           
            TableColumn column = new TableColumn("column");
            column.AddString("name");
            column.AddString("surname");
            Condition condition = new Condition(Condition.Operations.equals,"name",column);
            List<String> list1 = column.GetColumn();
            column.DeleteCondition(list1,condition);
            Assert.AreEqual(1,column.GetColumn().Count);
            column.AddString("lastname");
            Condition condition6 = new Condition(Condition.Operations.min, "name", column);
            List<String> list7 = column.GetColumn();
            column.DeleteCondition(list7, condition6);
            foreach (String element in column.GetColumn())
            {
                Assert.AreEqual("lastname", element);
            }

            TableColumn list2 = new TableColumn("column1");
            list2.AddString("0");
            list2.AddString("4");
            Condition condition1 = new Condition(Condition.Operations.min, "2", list2);
            List<String> list3 = list2.GetColumn();
            list2.DeleteCondition(list3, condition1);
            Assert.AreEqual(1, list2.GetColumn().Count);
            foreach (String element in list2.GetColumn())
            {
                Assert.AreEqual("0",element);
            }
                

            TableColumn list4 = new TableColumn("column2");
            list4.AddString("0");
            list4.AddString("4");
            Condition condition2 = new Condition(Condition.Operations.max, "2", list4);
            List<String> list5 = list4.GetColumn();
            list4.DeleteCondition(list5, condition2);
            Assert.AreEqual(1, list4.GetColumn().Count);
            foreach (String element in list4.GetColumn())
            {
                Assert.AreEqual("4", element);
            }

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
