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

        public SecurityProfile(string name, string password, List<Priviledge> priviledges)
        {
            m_name = name;
            m_priviledges = priviledges;
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
            if (!m_users.Contains(user)) 
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
    }
}
