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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Sofa_World.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public MainWindow mainWindow;
        public Login(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            mainWindow.@out.Visibility = Visibility.Visible;
            mainWindow.cart.Visibility = Visibility.Hidden;
            mainWindow.ord.Visibility = Visibility.Hidden;
        }

        private void sign_up_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.page = "Main";
            mainWindow.frame.Navigate(new Pages.Main(mainWindow));
        }

        private void sign_in_Click(object sender, RoutedEventArgs e)
        {
            string pas = Password.Password;

            mainWindow.users.Clear();
            MySqlDataReader tiket_query;
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            tiket_query = WorkingBD.Query("SELECT * FROM kp.user where `login` like '" + LogIn.Text + "' and `pwd` like '" + pas + "';", mySqlconnection);
            while (tiket_query.Read())
            {
                mainWindow.users.Add(new Classes.User(
                    Convert.ToInt32(tiket_query.GetValue(0)),
                     tiket_query.GetValue(1).ToString(),
                     tiket_query.GetValue(2).ToString(),
                     tiket_query.GetValue(3).ToString(),
                     tiket_query.GetValue(4).ToString(),
                     tiket_query.GetValue(5).ToString(),
                     tiket_query.GetValue(6).ToString()
                     ));
            }
            mySqlconnection.Close();
            if (mainWindow.users.Count != 0) // если пользователь найден
            {
                for (int i = 0; i < mainWindow.users.Count; i++)
                {
                    if (mainWindow.users[i].Role == "Клиент")
                    {
                        if (cap.Text == "captcha")
                        {
                            mainWindow.page = "Main";
                            mainWindow.IdUser = mainWindow.users[i].UserID;
                            mainWindow.frame.Navigate(new Pages.Main(mainWindow)); //переходим на страницу заказа 
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели капчу неправильно", "Ошибюка");
                        }
                    }
                    else if (mainWindow.users[i].Role == "Администратор")
                    {
                        if (cap.Text == "captcha")
                        {
                            mainWindow.page = "Main";
                            mainWindow.IdUser = mainWindow.users[i].UserID;
                            mainWindow.frame.Navigate(new Pages.Admin(mainWindow)); //переходим на страницу админа 
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели капчу неправильно", "Ошибюка");
                        }
                    }
                    else if (mainWindow.users[i].Role == "Менеджер")
                    {
                        if (cap.Text == "captcha")
                        {
                            mainWindow.page = "Main";
                            mainWindow.IdUser = mainWindow.users[i].UserID;
                            mainWindow.frame.Navigate(new Pages.Manager(mainWindow)); //переходим на страницу manager
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели капчу неправильно", "Ошибюка");
                        }
                    }

                } 
            }
            else
            {
                MessageBox.Show("Вы ввели данные неправильно","Ошибюка");
            }
        }
    }
}
