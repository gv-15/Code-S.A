using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Security
    {

        private List<User> m_users;
        private List<SecurityProfile> m_security_profiles;

        public Security(List<User> users)
        {
            m_users = users;
        }


        public void CreateSecurityProfile(SecurityProfile profile) 
        {
            m_security_profiles.Add(profile);
        }

        public void DropSecurityProfile(SecurityProfile profile)
        {
            m_security_profiles.Remove(profile);
        }

        public void Grant(string profileName, string tableName, Enum priviledgeType)
        {
            Priviledge priviledge = new Priviledge(priviledgeType,tableName);
            bool found = false;
            int i = 0;
            while (!found && i<m_security_profiles.Count)
            {
                if (m_security_profiles[i].GetName().Equals(profileName))
                {
                    
                    m_security_profiles[i].AddPriviledge(priviledge);
                    
                    found = true;
                }
                else
                {
                    i++;
                }
            }
        }

        public void Revoke(string profileName, string tableName, Enum priviledgeType)
        {
            Priviledge priviledge = new Priviledge(priviledgeType, tableName);
            bool found = false;
            int i = 0;
            while (!found && i < m_security_profiles.Count)
            {
                if (m_security_profiles[i].GetName().Equals(profileName))
                {
                    m_security_profiles[i].RemovePriviledge(priviledge);
                    found = true;
                }
                else
                {
                    i++;
                }
            }
        }

        public void AddUser(string name, string password, SecurityProfile profile)
        {
            User newUser = new User(name,password,profile);
            m_users.Add(newUser);
        }

        public string DeleteUser(string user)
        {
            int i = 0;
            bool found = false;
            while(!found && i< m_users.Count)
            {
                if (m_users[i].Equals(user))
                {
                    m_users.RemoveAt(i);
                    found = true;
                }
                else
                {
                    i++;
                }
            }

            return null;
        }
    }
}
