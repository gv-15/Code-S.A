using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class AddUser: IQuery
    {
        private string m_name;
        private string m_password;
        private SecurityProfile sp;
        public AddUser(string name, string password, SecurityProfile profile)
        {
            m_name = name;
            m_password = password;
            sp = profile;
        }

        public string Run(DB database)
        {

            return database.GetSecurity().AddUser(m_name, m_password, sp);

           
        }

    }
}
