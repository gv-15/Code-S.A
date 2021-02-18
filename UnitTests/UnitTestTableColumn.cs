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
           
            
            TableColumn list = new TableColumn("column");
            list.AddColumn("name");
            list.AddColumn("surname");
            Condition condition = new Condition(Condition.Operations.equals,"column",list);
            List<String> list1 = list.GetColumn();
            list.DeleteCondition(list1,condition);

            

        }
        [TestMethod]
        public void TestSelect()
        {
        
        }
    }
}
