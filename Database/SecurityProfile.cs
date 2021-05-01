﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class SecurityProfile
    {
        private string m_name;
        private List<Priviledge> m_priviledges;
        private List<User> m_users;

        public SecurityProfile(string name)
        {
            m_name = name;
            m_priviledges = new List<Priviledge>();
        }
        public string GetName()
        {
            return m_name;
        }
        public List<Priviledge> GetPriviledgeList()
        {
            return m_priviledges;
        }

        public void AddPriviledge(Priviledge priviledge)
        {
            if (!CheckPriviledge(priviledge))
            {
                m_priviledges.Add(priviledge);
            }

        }

        public void RemovePriviledge(Priviledge priviledge)
        {
            if (CheckPriviledge(priviledge))
            {
                m_priviledges.Remove(priviledge);
            }

        }

        public void AddUser(User user)
        {
            if (CheckUser(user.GetName())) 
            {
                m_users.Add(user);
            }
            
        }

        public void DeleteUser(string userName)
        {
            User user = m_users.Find(usuario => usuario.GetName() == userName);
            m_users.Remove(user);
        }

        public bool CheckPriviledge(Priviledge priviledge)
        {
            if (m_priviledges.Contains(priviledge))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckUser(string userName)
        {
            User user = m_users.Find(usuario => usuario.GetName() == userName);
            if (user.Equals(null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<User> GetUsers()
        {
            return m_users;
        }
        public User FindUser(string userName)
        {
            User user = m_users.Find(usuario => usuario.GetName() == userName);
            return user;
        }
        public List<Priviledge> FindPriviledgesByTable(string tableName)
        {
            List<Priviledge> priviledges = m_priviledges.FindAll(priv => priv.GetTableName() == tableName);
            return priviledges;
        }
    }
}
