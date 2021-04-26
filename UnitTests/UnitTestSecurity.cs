using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Database;

namespace UnitTests
{
   
    [TestClass]
    public class UnitTestSecurity
    {
        private string name;
        private string password;
        private List<Priviledge> priviledges;

        [TestMethod]
        public void TestGrant()
        {
            List<Priviledge> p = new List<Priviledge>() ;
            SecurityProfile profile = new SecurityProfile("paco", "1234", p  );
            string profileName = profile.GetName();
            Table t = new Table("n");
            string tableName = t.GetName();
           // Priviledge type = new Priviledge(type.GetPriviledgeType(), tableName);
        }
    }
}
