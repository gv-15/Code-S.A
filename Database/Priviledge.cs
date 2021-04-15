using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Priviledge
    {
        public enum priviledge_type { DELETE, INSERT, SELECT, UPDATE};

        private Enum m_type;


        public Priviledge(Enum type)
        {
            m_type = type;
        }
    }
}
