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

namespace Sofa_World.Adding
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public MainWindow mainWindow;
        public Add(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }


        private void Add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                int k = mainWindow.orders.Count + 1;
                string connection = "server=localhost;port=3306;database=practice;uid=root;pwd=Asdfg123";
                MySqlConnection mySqlconnection = new MySqlConnection(connection);
                mySqlconnection.Open();
                MySqlDataReader tiket_query = WorkingBD.Query(" INSERT INTO  `kp`.`orders` (`order_date`,`delivery_date`,`point_of_issue`,`id_client`,`receive_code` ,`order_status` ) " +
                                                                " VALUES('" + order_date.Text + "','" + delivery_date.Text + "', '" + point_of_issue.Text + "', '" + id_client.Text + "', '" + receive_code.Text + "', '" + order_status.Text + "');", mySqlconnection);
                mySqlconnection.Close();
                mainWindow.LoadreOrders();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
