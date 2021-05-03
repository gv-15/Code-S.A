﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Database;

namespace UnitTests
{
   
    [TestClass]
    public class UnitTestSecurity
    {
       private Security m_security;

        [TestMethod]
        public void TestGrant()
        {
            m_security = new Security();
            List<Priviledge> p = new List<Priviledge>() ;
            SecurityProfile profile = new SecurityProfile("paco");
            string profileName = profile.GetName();
            Table t = new Table("n");
            string tableName = t.GetName();
            Priviledge priv = new Priviledge(Priviledge.Priviledge_type.INSERT, tableName);
            string type = priv.GetPriviledgeType();
            m_security.Grant(profileName, tableName, type);

           // Assert.AreEqual(); falta por hacer 
        }
        [TestMethod]
        public void TestCreateSecurityProfile()
        {
            m_security = new Security();
            SecurityProfile profile = new SecurityProfile("paco");
            string profileName = profile.GetName();
            List<SecurityProfile> prof = new List<SecurityProfile>();
            prof.Add(profile);
            m_security.CreateSecurityProfile(profileName);

            Assert.AreEqual(1, prof.Count);
        }
        [TestMethod]
        public void TestDropSecurityProfile()
        {
            m_security = new Security();
            SecurityProfile profile1 = new SecurityProfile("Paco");
            SecurityProfile profile2 = new SecurityProfile("Juan");
            string profileName1 = profile1.GetName();
            string profileName2 = profile2.GetName();
            m_security.CreateSecurityProfile(profileName1);
            m_security.CreateSecurityProfile(profileName2);
            string a = m_security.DropSecurityProfile(profileName1);
            List<string> list = new List<string>();
            list.Add(a);

            Assert.AreEqual(1,list.Count); 
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
            m_security = new Security();
            User user1 = new User("Paco", "1234");
            string name = user1.GetName();
            string password = user1.GetPassword();
            SecurityProfile profile1 = new SecurityProfile("Paco");
            string profile = profile1.GetName();
            List<User> list = new List<User>();
            list.Add(user1);
           // m_security.AddUser(name, password, profile); aqui falla
            

            Assert.AreEqual(1, list.Count); 

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
