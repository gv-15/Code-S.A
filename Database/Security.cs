using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Security
    {

        private List<SecurityProfile> m_security_profiles;

        public Security(List<User> users)
        {
         
        }


        public string CreateSecurityProfile(string profileName) 
        {
            SecurityProfile newProfile = new SecurityProfile(profileName);
            m_security_profiles.Add(newProfile);
            return "Security profile created";
        }

        public string DropSecurityProfile(string profileName)
        {
            SecurityProfile newProfile = m_security_profiles.Find(prof => prof.GetName() == profileName);
            m_security_profiles.Remove(newProfile);
            return "Security profile deleted";
        }

        public string Grant(string profileName, string tableName, string priviledgeType)
        {
            if (priviledgeType.Equals("DELETE")|| priviledgeType.Equals("INSERT") || priviledgeType.Equals("SELECT") || priviledgeType.Equals("UPDATE"))
            {
                Priviledge priviledge;
                if (priviledgeType.Equals("DELETE"))
                {
                    priviledge = new Priviledge(Priviledge.Priviledge_type.DELETE, tableName);
                }
                else if (priviledgeType.Equals("INSERT"))
                {
                    priviledge = new Priviledge(Priviledge.Priviledge_type.INSERT, tableName);
                }
                else if (priviledgeType.Equals("SELECT"))
                {
                    priviledge = new Priviledge(Priviledge.Priviledge_type.SELECT, tableName);
                }
                else
                {
                    priviledge = new Priviledge(Priviledge.Priviledge_type.UPDATE, tableName);
                }

                bool found = false;
                int i = 0;
                while (!found && i < m_security_profiles.Count)
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
            else
            {
                return "The priviledge hasn't been granted";
            }
        }

        public string Revoke(string profileName, string tableName, string priviledgeType)
        {


            if (priviledgeType.Equals("DELETE") || priviledgeType.Equals("INSERT") || priviledgeType.Equals("SELECT") || priviledgeType.Equals("UPDATE"))
            {

                Priviledge priviledge;
                if (priviledgeType.Equals("DELETE"))
                {
                    priviledge = new Priviledge(Priviledge.Priviledge_type.DELETE, tableName);
                }
                else if (priviledgeType.Equals("INSERT"))
                {
                    priviledge = new Priviledge(Priviledge.Priviledge_type.INSERT, tableName);
                }
                else if (priviledgeType.Equals("SELECT"))
                {
                    priviledge = new Priviledge(Priviledge.Priviledge_type.SELECT, tableName);
                }
                else
                {
                    priviledge = new Priviledge(Priviledge.Priviledge_type.UPDATE, tableName);
                }


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
            else
            {
                return "The priviledge hasn't been revoked";
            }
        }

        public string AddUser(string name, string password, string profile)
        {
            
            


            SecurityProfile newProfile = m_security_profiles.Find(prof => prof.GetName() == profile);
            int index = m_security_profiles.IndexOf(newProfile);
            User newUser = new User(name, password);

            m_security_profiles[index].AddUser(newUser);
            return "User added to security profile";

        }

        public string DeleteUser(string user)
        {
            
            for(int i=0; i< m_security_profiles.Count;i++)
            {

                m_security_profiles[i].DeleteUser(user);
                                
            }
            return "User deleted from security profile";
            
        }
    }
}
