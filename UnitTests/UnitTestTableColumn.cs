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
            List<String> listaR = new List<String>();
            listaR.Add("name");
            
            for(int i = 0; i>list1.Count; i++)            
            {
                Assert.AreEqual(listaR., list.Select(list1, condition));
            }

            Assert.AreEqual(null, list.Select(list1, condition));
        }
    }
}
