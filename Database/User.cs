using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class User
    {
        private string m_name;
        private string m_password;
        private SecurityProfile m_securityProfile;

        public User(string name, string password, SecurityProfile profile)
        {
            m_name = name;
            m_password = password;
            m_securityProfile = profile;

        }

    }
}
