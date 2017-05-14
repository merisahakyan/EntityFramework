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

            }
            table.Rows[0][0] = 5;
            table.Rows[1].Delete();

            //table.AcceptChanges();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Console.WriteLine("About ID");
                if (table.Rows[i].RowState.ToString() != "Deleted")
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        Console.WriteLine(table.Columns[j].ColumnName + ":" + table.Rows[i][j]);
                    }

                    Console.WriteLine("RowState:" + table.Rows[i].RowState);
                    Console.WriteLine("Original value:" + table.Rows[i][0, DataRowVersion.Original]);
                    Console.WriteLine("Current value:" + table.Rows[i][0, DataRowVersion.Current]);
                    Console.WriteLine("Defoult value:" + table.Rows[i][0, DataRowVersion.Default]);
                }

                else
                {
                    Console.WriteLine($"RowState: the {i}th is " + table.Rows[i].RowState);
                }
                Console.WriteLine();
            }
        }
    }
}
