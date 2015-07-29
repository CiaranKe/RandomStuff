using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace RandomApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conn;
        private string db;


        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source = .; Database=Northwind; Integrated Security=true;");
        }

        private void getDBlist()
        {
            this.conn.Open();
            SqlCommand cmd = new SqlCommand("EXEC sp_databases", conn);
            SqlDataAdapter reader = new SqlDataAdapter("EXEC sp_databases", conn);
            DataSet dset = new DataSet();
            reader.Fill(dset);
            DBSelect.ItemsSource = dset.Tables[0].DefaultView;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.conn.Open();
            SqlDataAdapter reader = new SqlDataAdapter(this.QueryBox.Text, conn);
            DataSet dset = new DataSet();
            try
            {
                reader.Fill(dset);
                DataDisplay.ItemsSource = dset.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                this.QueryBox.Text = "Sorry There was a problem:" + ex.Message;
            }
            this.conn.Close();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void QueryBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
