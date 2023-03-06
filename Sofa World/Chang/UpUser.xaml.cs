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
    /// Логика взаимодействия для UpUser.xaml
    /// </summary>
    public partial class UpUser : Window
    {
        public MainWindow mainWindow;
        int h = 0;
        public UpUser(MainWindow _mainWindow, int i)
        {
            InitializeComponent();
            h = i;
            mainWindow = _mainWindow;
            Load();
        }

        private void Load()
        {
            for (int i = 0; i < mainWindow.upUser.Count; i++)
            {
                surname.Text = mainWindow.upUser[i].Surname;
                name.Text = mainWindow.upUser[i].Name;
                lastname.Text = mainWindow.upUser[i].Patronymic;
                login.Text = Convert.ToString(mainWindow.upUser[i].Login);
                pwd.Text = mainWindow.upUser[i].Password;
                role.Text = mainWindow.upUser[i].Role;
            }
        }
        private void update_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.upUser.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("UPDATE kp.user SET `surname` = '" + surname.Text + "', " +
                "`name` = '" + name.Text + "', " +
                "`lastname` = '" + lastname.Text + "', " +
                "`login` = '" + login.Text + "' ," +
                " `pwd` = '" + pwd.Text + "' , " +
                "`role` = '" + role.Text + "'" +
                "  WHERE (`id` = '" + h + " ');", mySqlconnection);
            mySqlconnection.Close();
            mainWindow.LoaderUsers();
            this.Close();
        }
    }
}
