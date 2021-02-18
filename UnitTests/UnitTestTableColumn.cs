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
