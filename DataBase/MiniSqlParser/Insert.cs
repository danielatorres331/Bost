﻿using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.MiniSqlParser
{
    public class Insert : IQuery
    {
        private string m_table;
        private string[] m_values;

        public string Table()
        {
            return m_table;
        }

        public string[] values()
        {
            return m_values;
        }
        public Insert(string table, string[] values)
        {
            m_table = table;
            m_values = values;
        }

        public string Run(BostDB.DataBase database)
        {
            throw null;
        }
    }
}
