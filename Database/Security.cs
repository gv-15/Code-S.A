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


        public string CreateSecurityProfile(SecurityProfile profile) 
        {
            m_security_profiles.Add(profile);
            return "Security profile created";
        }

        public string DropSecurityProfile(SecurityProfile profile)
        {
            m_security_profiles.Remove(profile);
            return "Security profile deleted";
        }

        public string Grant(string profileName, string tableName, Enum priviledgeType)
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
            if (found)
            {
                return "The priviledge has been granted";
            }
            else
            {
                return "The priviledge hasn't been granted";
            }
        }

        public string Revoke(string profileName, string tableName, Enum priviledgeType)
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
            if (found)
            {
                return "The priviledge has been revoked";
            }
            else
            {
                return "The priviledge hasn't been revoked";
            }
        }

        public string AddUser(string name, string password, SecurityProfile profile)
        {
            User newUser = new User(name,password,profile);
            m_users.Add(newUser);
            return "User added to security profile";

        }

        public string DeleteUser(string user)
        {
            int i = 0;
            bool found = false;
            while(!found && i< m_users.Count)
            {
                if (m_users[i].GetName().Equals(user))
                {
                    m_users.RemoveAt(i);
                    found = true;
                }
                else
                {
                    i++;
                }
            }
            if (found)
            {
                return "User deleted from security profile";
            }
            else
            {
                return "The user hasn't been deleted";
            }
        }
    }
}
