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
       

        [TestMethod]
        public void TestGrant()
        {
            DB db = new DB("MyDB", "admin", "admin");
            List<Priviledge> p = new List<Priviledge>() ;
            db.GetSecurity().CreateSecurityProfile("paco");
            
            Table t = new Table("n");
            string tableName = t.GetName();
            Priviledge priv = new Priviledge(Priviledge.Priviledge_type.INSERT, tableName);
            string type = priv.GetPriviledgeType();
            db.GetSecurity().Grant("paco", tableName, type);
            SecurityProfile s = db.GetSecurity().GetSecurityProfiles().Find(sec => sec.GetName().Equals("paco"));
            bool a = s.CheckPriviledge(priv);

            Assert.IsTrue(a);

            
            
        }
        [TestMethod]
        public void TestCreateSecurityProfile()
        {
            DB db = new DB("MyDB", "admin", "admin");
            SecurityProfile profile = new SecurityProfile("paco");
            string profileName = profile.GetName();
            
            db.GetSecurity().CreateSecurityProfile(profileName);

            Assert.AreEqual(1, db.GetSecurity().GetSecurityProfiles().Count);
        }
        [TestMethod]
        public void TestDropSecurityProfile()
        {
            DB db = new DB("MyDB", "admin", "admin");
            SecurityProfile profile1 = new SecurityProfile("Paco");
            SecurityProfile profile2 = new SecurityProfile("Juan");
            string profileName1 = profile1.GetName();
            string profileName2 = profile2.GetName();
            db.GetSecurity().CreateSecurityProfile(profileName1);
            db.GetSecurity().CreateSecurityProfile(profileName2);
            db.GetSecurity().DropSecurityProfile(profileName1);
            

            Assert.AreEqual(1,db.GetSecurity().GetSecurityProfiles().Count); 
        }
        [TestMethod]
        public void TestLogin()
        {
           
        }
        [TestMethod]
        public void TestAddUser()
        {
            DB db = new DB("MyDB", "admin", "admin");
            User user1 = new User("Paco", "1234");
            string name = user1.GetName();
            string password = user1.GetPassword();
            SecurityProfile profile1 = new SecurityProfile("Paco");
            string profile = profile1.GetName();
            db.GetSecurity().CreateSecurityProfile(profile);
            
            
            db.GetSecurity().AddUser(name, password, profile); 
            

            Assert.AreEqual(1,db.GetSecurity().getUserList().Count ); 

        }
    }
}
