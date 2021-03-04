using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public interface IQuery
    {
        string Run(DB database);
    }
}
