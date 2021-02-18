﻿using Database;
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
            names.AddColumn("Ane");
            names.AddColumn("Joseba");

            names.DeleteFrom("Ane");

            int num = names.GetColumn().Count;

            Assert.AreEqual(1, num);
        }

        [TestMethod]
        public void TestAddColumn()
        {
            TableColumn names = new TableColumn("myColumn");
            names.AddColumn("Ane");

            int num = names.GetColumn().Count;

            Assert.AreEqual(1,num);
        }

        public void TestDeleteCondition()
        {

        }

        public void TestSelect()
        {
        
        }
    }
}
