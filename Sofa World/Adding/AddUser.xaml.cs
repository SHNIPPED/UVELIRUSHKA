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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public MainWindow mainWindow;
        public AddUser(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int k = mainWindow.user.Count + 1;
                string connection = "server=localhost;port=3306;database=practice;uid=root;pwd=Asdfg123";
                MySqlConnection mySqlconnection = new MySqlConnection(connection);
                mySqlconnection.Open();
                MySqlDataReader tiket_query = WorkingBD.Query(" INSERT INTO  `kp`.`user` (`surname`," +
                "`name` ," +
                "`lastname`  ," +
                "`login` ," +
                " `pwd`," +
                "`role`)" +
                " VALUES('" + surname.Text + "','" + name.Text + "', '" + lastname.Text + "', '" + login.Text + "', '" + pwd.Text + "', '" + role.Text + "');", mySqlconnection);
                mySqlconnection.Close();
                mainWindow.LoaderUsers();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
