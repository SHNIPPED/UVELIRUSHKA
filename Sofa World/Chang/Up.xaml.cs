using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Sofa_World.Chang
{
    /// <summary>
    /// Логика взаимодействия для Up.xaml
    /// </summary>
    public partial class Up : Window
    {
        public MainWindow mainWindow;
        int h = 0;
        public Up(MainWindow _mainWindow, int i)
        {
            InitializeComponent();
            h = i;
            mainWindow = _mainWindow;
            Load();
        }
        private void Load()
        {
            for (int i = 0; i < mainWindow.up.Count; i++)
            {
                order_date.Text = mainWindow.up[i].order_date;
                delivery_date.Text = mainWindow.up[i].delivery_date;
                point_of_issue.Text = mainWindow.up[i].point_of_issue;
                id_client.Text = Convert.ToString(mainWindow.up[i].id_client);
                receive_code.Text = mainWindow.up[i].receive_code;
                order_status.Text = mainWindow.up[i].order_status;
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.up.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("UPDATE kp.orders SET `order_date` = '" + order_date.Text + "', `delivery_date` = '" + delivery_date.Text + "', `point_of_issue` = '" + point_of_issue.Text + "', `id_client` = '" + id_client.Text + "' , `receive_code` = '" + receive_code.Text + "' , `order_status` = '" + order_status.Text + "'  WHERE (`id` = '" + h + " ');", mySqlconnection);
            mySqlconnection.Close();
            mainWindow.LoadreOrders();
            this.Close();
        }
    }
}
