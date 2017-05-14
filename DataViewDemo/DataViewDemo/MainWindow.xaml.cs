using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=Users; Integrated Security=true";
        string command = "select * from MyUsers";
        DataTable users = new DataTable();
        SqlDataAdapter adapter;
        DataView usersView;
        public MainWindow()
        {
            InitializeComponent();
            users.TableName = "Users";
            adapter = new SqlDataAdapter(command, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(users);
            usersView = new DataView(users, "", "ID", DataViewRowState.CurrentRows);
            dataGrid1.ItemsSource = users.DefaultView;
            dataGrid.ItemsSource = usersView;
        }

        private void findbutton_Click(object sender, RoutedEventArgs e)
        {
            usersView.RowFilter = filter.Text;
            usersView.Sort = sort.Text;
        }
    }
}
