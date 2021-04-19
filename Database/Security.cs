using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Security
    {

        private List<User> m_users;

        public Security(List<User> users)
        {
            m_users = users;
        }


        public void CreateSecurityProfile() 
        {
            
        }

        public void DropSecurityProfile()
        {

        }

        public void Grant()
        {

        }

        public void Revoke()
        {

        }

        public void AddUser(string user, string password, SecurityProfile profile)
        {

        }

        public void DeleteUser()
        {

        }
    }
}
