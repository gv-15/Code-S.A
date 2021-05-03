using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Security
    {

        private List<SecurityProfile> m_security_profiles;
        private List<User> m_users;
        public Security(List<User> users)
        {
            m_users = users;
            m_security_profiles = new List<SecurityProfile>();
        }
        public Security()
        {
            m_users = new List<User>();
            m_security_profiles = new List<SecurityProfile>();
            //Este constructor esta credao porque en database no tenemos una lista de usuarios para pasarle por parametro no tenia sentido usar el parametrizado
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

        public string Grant(string profileName, string tableName, string priviledgeType) //Esto esta cambiado para pasarle solo 2 parametros al metodo que es lo que se puede cojer con el parser
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


                SecurityProfile newProfile = m_security_profiles.Find(prof => prof.GetName() == profileName);
                if (newProfile == null)
                {
                    return "Security priviledge not granted";
                }
                else
                {
                    newProfile.AddPriviledge(priviledge);
                    return "Security priviledge granted";
                }
                

            }
            else
            {
                return "Security priviledge not granted";
            }
        }

        public bool Login(string name, string password)
        {
            List<User> users = m_users.FindAll(userName => userName.GetName() == name);
            User user = users.Find(userPass => userPass.GetPassword() == password);
            if (user == null) 
            {
                return false;
            }
            else
            {
                return true;
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


                SecurityProfile newProfile = m_security_profiles.Find(prof => prof.GetName() == profileName);
                if (newProfile == null)
                {
                    newProfile.RemovePriviledge(priviledge);
                    return "Security priviledge revoked";
                }
                else
                {
                    return "Security priviledge not revoked";
                }
            }
            else
            {
                return "Security priviledge not revoked";
            }
        }

        public string AddUser(string name, string password, string profile)
        {


            SecurityProfile newProfile = m_security_profiles.Find(prof => prof.GetName() == profile);
            int index = m_security_profiles.IndexOf(newProfile);
            User newUser = new User(name, password);
            m_users.Add(newUser);
            m_security_profiles[index].AddUser(newUser);
            return "User added to security profile";

        }

        public string DeleteUser(string user)
        {

            for (int i=0; i< m_security_profiles.Count;i++)
            {

                m_security_profiles[i].DeleteUser(user);
                                
            }
            User user1 = m_users.Find(user2 => user2.GetName() == user);
            m_users.Remove(user1);

            return "User deleted from security profile";
            
        }

        public bool CheckUserAction(string userName, string tableName, string priviledgeType) // We assume that the user has already logged in and therefore, we don't need to check if it either exist or not
        {
            if (userName.Equals("admin"))
            {
                return true;
            }
            else
            {
                User userL = m_users.Find(us => us.GetName() == userName);
                List<SecurityProfile> profiles = m_security_profiles.FindAll(prof => prof.FindUser(userName) == userL);
                int i = 0;
                bool found = false;
                while (i<profiles.Count && !found)
                {
                    List<Priviledge> tablePriviledges = profiles[i].FindPriviledgesByTable(tableName);
                    Priviledge priviledge = tablePriviledges.Find(priv => priv.GetPriviledgeType() == priviledgeType);

                    if (priviledge == null)
                    {
                        i++;
                    }
                    else
                    {
                        found = true;
                        
                    }
                }

                return found;
            }
        }
    }
}
