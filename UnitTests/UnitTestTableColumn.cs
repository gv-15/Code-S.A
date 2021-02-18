using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Database;

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
            Condition condition = new Condition();
            int resultado = TableColumn.DeleteCondition(list.GetColumn(),condition);

            

        }
        [TestMethod]
        public void TestSelect()
        {
        
        }
    }
}
