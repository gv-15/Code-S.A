using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class User
    {
        private string m_name;
        private string m_password;

        public User(string name, string password)
        {
            m_name = name;
            m_password = password;

        }

        public string GetName()
        {
            return m_name;
        }
        public void SetName(string name)
        {
            m_name = name;
        }
        public string GetPassword()
        {
            return m_password;
        }
        public void SetPassword(string password)
        {
            m_password = password;
        }

    }
}
