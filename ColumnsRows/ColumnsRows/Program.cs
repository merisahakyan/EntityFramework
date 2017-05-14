using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColumnsRows
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("UserID", typeof(int));
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            for (int i = 0; i < 3; i++)
            {
                table.LoadDataRow(new Object[] { i, $"firstname{i}", $"lastname{i}" }, true);
                table.AcceptChanges();
            }
            for(int i=0;i<table.Rows.Count;i++)
            {
                for(int j=0;j<table.Columns.Count;j++)
                {
                    Console.WriteLine(table.Columns[j].ColumnName+":"+table.Rows[i][j]);
                }
                Console.WriteLine("RowState:" + table.Rows[i].RowState);
                Console.WriteLine();
            }
        }
    }
}
