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
            DB db = new DB("people", "admin", "admin");

            db.GetSecurity().CreateSecurityProfile("Employee");

            db.GetSecurity().AddUser("Lana", "111", "Employee");
            db.GetSecurity().AddUser("Mikel", "333", "Employee");

            bool b = db.GetSecurity().Login("Lana", "111");
            Assert.IsTrue(b);

            bool b2 = db.GetSecurity().Login("Lana", "121");
            Assert.IsFalse(b2);
        }

        public void TestRevoke()
        {
            DB db = new DB("people", "admin", "admin");

            db.GetSecurity().CreateSecurityProfile("Employee");

            db.GetSecurity().AddUser("Hana", "121", "Employee");
            db.GetSecurity().AddUser("Lisa", "345", "Employee");

            Table t = new Table("girls");
            db.GetDBTableList().Add(t);

            db.GetSecurity().Grant("Employee", "girls", "SELECT");
            bool yes = db.GetSecurity().CheckUserAction("Hana", "girls", "SELECT");
            Assert.IsTrue(yes);

            db.GetSecurity().Revoke("Employee", "girls", "SELECT");
            bool no = db.GetSecurity().CheckUserAction("Hana", "girls", "SELECT");
            Assert.IsFalse(no);
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

        [TestMethod]
        public void TestDeleteUser()
        {
            DB db = new DB("people", "admin","admin");

            db.GetSecurity().CreateSecurityProfile("Employee");

            db.GetSecurity().AddUser("Lana", "111","Employee");
            db.GetSecurity().AddUser("Mikel", "333", "Employee");


            db.GetSecurity().DeleteUser("Lana");

            int i =  db.GetSecurity().GetUsers().Count;
            Assert.AreEqual(1, i);

            Assert.AreEqual("Mikel", db.GetSecurity().GetUsers()[0].GetName());

        }

        [TestMethod]
        public void TestCheckUserAction()
        {
            //El usuario tiene los permisos para hacer las acciones que está intentando
            DB db = new DB("people", "admin", "admin");

            db.GetSecurity().CreateSecurityProfile("Employee");

            db.GetSecurity().AddUser("Lana", "111", "Employee");
            db.GetSecurity().AddUser("Mikel", "333", "Employee");

            Table t = new Table("girls");
            db.GetDBTableList().Add(t);

            db.GetSecurity().Grant("Employee", "girls", "SELECT");

            db.GetSecurity().Login("Lana", "111");

            bool b = db.GetSecurity().CheckUserAction("Lana","girls", "DELETE");
            Assert.IsFalse(b);

            bool b2 = db.GetSecurity().CheckUserAction("Lana", "girls", "SELECT");
            Assert.IsTrue(b2);

        }

        
    }
}
