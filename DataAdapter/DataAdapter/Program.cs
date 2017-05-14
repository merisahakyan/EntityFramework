using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS ; Initial Catalog=Users ;  Integrated Security=true");
            SqlCommand command = new SqlCommand("Select * from MyUsers",connection);
            SqlDataAdapter ad = new SqlDataAdapter(command);
            DataSet set = new DataSet();
            ad.Fill(set);
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                for(int j=0;j<set.Tables[0].Columns.Count;j++)
                {
                    Console.WriteLine(set.Tables[0].Columns[j].ColumnName+":"+ set.Tables[0].Rows[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
