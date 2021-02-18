using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Database;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTableColumn
    {
       [TestMethod]

        public void TestTableColumn()
        {

        }

        public void TestGetColumn()
        {

        }

        public void TestDeleteFrom()
        {

        }

        public void TestAddColumn()
        {

        }
        [TestMethod]
        public void TestDeleteCondition()
        {
           
            
            TableColumn list = new TableColumn("column");
            list.AddString("name");
            list.AddString("surname");
            Condition condition = new Condition(Condition.Operations.equals,"name",list);
            List<String> list1 = list.GetColumn();
            list.DeleteCondition(list1,condition);

            Assert.AreEqual(1,list.GetColumn().Count);

        }
        [TestMethod]
        public void TestSelect()
        {
            TableColumn list = new TableColumn("column");
            list.AddString("name");
            list.AddString("surname");
            Condition condition = new Condition(Condition.Operations.equals, "name", list);
            List<String> list1 = list.GetColumn();
            list.Select(list1, condition);

            Assert.AreEqual(1,list.GetColumn().Count);
        }
    }
}
