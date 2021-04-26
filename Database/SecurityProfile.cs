using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class SecurityProfile
    {
        private string m_name;

        private List<Priviledge> m_priviledges;

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

        public bool CheckPriviledge(Priviledge priviledge)
        {
            
            bool found = false;
            int i = 0;
            if (m_priviledges.Count!=0)
            {
                while (!found && i < m_priviledges.Count)
                {
                    if (m_priviledges[i].Equals(priviledge))
                    {
                        found = true;
                    }
                    else
                    {
                        i++;
                    }
                }

            }

            return found;
        }
    }
}
