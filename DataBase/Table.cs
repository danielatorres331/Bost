using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Table
    {
        public String Name;
        public List<Column> Columns = new List<Column>();

        Table(String name, List<Column> columns)
        {
            Name = name;
            Columns = columns;
        }

        public void AddColumn(Column column)
        {
            Columns.Add(column);
        }

        public void DeleteColumn(Column column)
        {
            Columns.Remove(column);
        }

        public void UpdateTable()
        {

        }

        public Column GetColumn(String name) 
        {
            return null;
        }

        public void AddRow()
        {
            
        }

        public Table GetTable()
        {
            return this;
        }

        public Column SearchColumnByName(String name)
        {
            return null;
        }
    }
}
