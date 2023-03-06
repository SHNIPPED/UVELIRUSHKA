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

namespace Sofa_World
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int IdUser;
        public string page = "";
        public string localPath;
        public List<Classes.Product> products = new List<Classes.Product>();
        public List<Classes.Product> upProduct = new List<Classes.Product>();
        public List<Classes.Product> ordProd = new List<Classes.Product>();
        public List<Classes.OrderProduct> orderProducts = new List<Classes.OrderProduct>();
        public List<Classes.User> users = new List<Classes.User>();
        public List<Classes.User> user = new List<Classes.User>();
        public List<Classes.User> upUser = new List<Classes.User>();
        public List<Classes.Order> orders = new List<Classes.Order>();
        public List<Classes.Order> up = new List<Classes.Order>();
        public List<Classes.Order> ordersUser = new List<Classes.Order>();
        public List<Classes.Categories> categories = new List<Classes.Categories>();
        public List<Classes.Chech> checks = new List<Classes.Chech>();

        public MainWindow()
        {
            InitializeComponent();
            LoaderUsers();
            Loadre();
            LoadreOrder();
            LoadreOrders();
            LoaderCategories();
            localPath = System.IO.Directory.GetCurrentDirectory();
            OpenPages(pages.Login);
            page = "login";
        }
        public enum pages
        {
            Login,
            Main,
            Order,
            korz,
            Manager,
            Admin
        }
        public void OpenPages(pages _pages)
        {
            if (_pages == pages.Login)
                frame.Navigate(new Pages.Login(this));
            if (_pages == pages.Main)
                frame.Navigate(new Pages.Main(this));
            if (_pages == pages.Order)
                frame.Navigate(new Pages.Order(this));
            if (_pages == pages.korz)
                frame.Navigate(new Pages.korz(this));
            if (_pages == pages.Manager)
                frame.Navigate(new Pages.Manager(this));
            if (_pages == pages.Admin)
                frame.Navigate(new Pages.Admin(this));
        }
        private void out_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (page == "login")
            {
                Environment.Exit(1);
            }
            if (page == "Main")
            {
                page = "login";
                Loadre();
                OpenPages(pages.Login);
            }
            if (page == "orders")
            {
                page = "Main";
                OpenPages(pages.Main);
            }
        }
        private void ord_MouseDown (object sender, MouseButtonEventArgs e)
        {
            ordersUser.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("SELECT * FROM kp.orders where id_client = '" + IdUser + "';", mySqlconnection);


            while (tiket_query.Read())
            {
                ordersUser.Add(new Classes.Order(
                    Convert.ToInt32(tiket_query.GetValue(0)),
                    tiket_query.GetValue(1).ToString(),
                    tiket_query.GetValue(2).ToString(),
                    tiket_query.GetValue(3).ToString(),
                   Convert.ToInt32(tiket_query.GetValue(4)),
                    tiket_query.GetValue(5).ToString(),
                    tiket_query.GetValue(6).ToString()
                    ));
            }
            mySqlconnection.Close();
            page = "orders";
            createinfochec(IdUser);
            Loadre();
            OpenPages(pages.korz);
        }

        private void cart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ordProd.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("SELECT products.id, products.article, products.name, products.measure_unit, products.price, products.max_discount, products.manufacturer, products.supplier, products.category_id, products.discount, products.amount_on_warehouse, products.description, products.img_src FROM kp.orderscontent,kp.products,kp.`user`" +
                                                            "where products.article = orderscontent.product_article and orderscontent.id_client = user.ID and user.ID ='" + IdUser + "'; ", mySqlconnection);


            while (tiket_query.Read())
            {
                ordProd.Add(new Classes.Product(
                    Convert.ToInt32(tiket_query.GetValue(0)),
                    tiket_query.GetValue(1).ToString(),
                    tiket_query.GetValue(2).ToString(),
                    tiket_query.GetValue(3).ToString(),
                    tiket_query.GetValue(4).ToString(),
                    tiket_query.GetValue(5).ToString(),
                    tiket_query.GetValue(6).ToString(),
                    tiket_query.GetValue(7).ToString(),
                    tiket_query.GetValue(8).ToString(),
                    tiket_query.GetValue(9).ToString(),
                    tiket_query.GetValue(10).ToString(),
                    tiket_query.GetValue(11).ToString(),
                    tiket_query.GetValue(12).ToString()
                    ));
            }
            mySqlconnection.Close();
            page = "orders";
            Loadre();
            OpenPages(pages.Order);
        }
        public void Loadre()
        {
            products.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("SELECT * FROM kp.products;", mySqlconnection);


            while (tiket_query.Read())
            {
                products.Add(new Classes.Product(
                    Convert.ToInt32(tiket_query.GetValue(0)),
                    tiket_query.GetValue(1).ToString(),
                    tiket_query.GetValue(2).ToString(),
                    tiket_query.GetValue(3).ToString(),
                    tiket_query.GetValue(4).ToString(),
                    tiket_query.GetValue(5).ToString(),
                    tiket_query.GetValue(6).ToString(),
                    tiket_query.GetValue(7).ToString(),
                    tiket_query.GetValue(8).ToString(),
                    tiket_query.GetValue(9).ToString(),
                    tiket_query.GetValue(10).ToString(),
                    tiket_query.GetValue(11).ToString(),
                    tiket_query.GetValue(12).ToString()
                    ));
            }
            mySqlconnection.Close();
          
        }

        public void LoadreOrder()
        {
            orderProducts.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("SELECT * FROM kp.orderscontent;", mySqlconnection);


            while (tiket_query.Read())
            {
                orderProducts.Add(new Classes.OrderProduct(
                    Convert.ToInt32(tiket_query.GetValue(0)),
                    Convert.ToInt32(tiket_query.GetValue(1)),
                     tiket_query.GetValue(2).ToString(),
                      tiket_query.GetValue(3).ToString(),
                      Convert.ToInt32(tiket_query.GetValue(4))
                    ));
            }
            mySqlconnection.Close();
        }
        public void LoadreOrders()
        {
            orders.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("SELECT * FROM kp.orders;", mySqlconnection);


            while (tiket_query.Read())
            {
                orders.Add(new Classes.Order(
                    Convert.ToInt32(tiket_query.GetValue(0)),
                    tiket_query.GetValue(1).ToString(),
                     tiket_query.GetValue(2).ToString(),
                      tiket_query.GetValue(3).ToString(),
                      Convert.ToInt32(tiket_query.GetValue(4)),
                      tiket_query.GetValue(5).ToString(),
                      tiket_query.GetValue(6).ToString()
                    ));
            }
            mySqlconnection.Close();
        }

        public void LoaderUsers()
        {
            user.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("SELECT * FROM kp.user;", mySqlconnection);


            while (tiket_query.Read())
            {
                user.Add(new Classes.User(
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
        }
        public void LoaderCategories()
        {
            categories.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("SELECT * FROM kp.categories;", mySqlconnection);


            while (tiket_query.Read())
            {
                categories.Add(new Classes.Categories(
                    Convert.ToInt32(tiket_query.GetValue(0)),
                    tiket_query.GetValue(1).ToString()
                    ));
            }
            mySqlconnection.Close();
        }
        public void OpenUp(int i)
        {
            up.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("Select * FROM kp.orders where `id` like '" + i + "';", mySqlconnection);
            int h = i;

            while (tiket_query.Read())
            {
                up.Add(new Classes.Order(
                       Convert.ToInt32(tiket_query.GetValue(0)),
                    tiket_query.GetValue(1).ToString(),
                     tiket_query.GetValue(2).ToString(),
                      tiket_query.GetValue(3).ToString(),
                      Convert.ToInt32(tiket_query.GetValue(4)),
                      tiket_query.GetValue(5).ToString(),
                      tiket_query.GetValue(6).ToString()
                    ));
            }
            mySqlconnection.Close();
            new Chang.Up(this, h).ShowDialog();
        }
        public void OpenUpOrder(int i)
        {
            upProduct.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("Select * FROM kp.products where `id` like " + i + ";", mySqlconnection);
            int h = i;

            while (tiket_query.Read())
            {
                upProduct.Add(new Classes.Product(
                    Convert.ToInt32(tiket_query.GetValue(0)),
                    tiket_query.GetValue(1).ToString(),
                    tiket_query.GetValue(2).ToString(),
                    tiket_query.GetValue(3).ToString(),
                    tiket_query.GetValue(4).ToString(),
                    tiket_query.GetValue(5).ToString(),
                    tiket_query.GetValue(6).ToString(),
                    tiket_query.GetValue(7).ToString(),
                    tiket_query.GetValue(8).ToString(),
                    tiket_query.GetValue(9).ToString(),
                    tiket_query.GetValue(10).ToString(),
                    tiket_query.GetValue(11).ToString(),
                    tiket_query.GetValue(12).ToString()
                    ));
            }
            mySqlconnection.Close();
            new Chang.UpProduct(this, h).ShowDialog();
        }

        public void OpenUpUser(int i)
        {
            upUser.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("Select * FROM kp.user where `id` like " + i + ";", mySqlconnection);
            int h = i;

            while (tiket_query.Read())
            {
                upUser.Add(new Classes.User(
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
            new Chang.UpUser(this, h).ShowDialog();
        }
        public void Delete(int i)
        {
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("DELETE FROM kp.orders WHERE(`id` = '" + i + "');", mySqlconnection);
            mySqlconnection.Close();
            LoadreOrders();
        }
        public void DeleteOrder(int i)
        {
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("DELETE FROM kp.products WHERE(`id` = '" + i + "');", mySqlconnection);
            mySqlconnection.Close();
            Loadre();
        }

        public void DeleteUser(int i)
        {
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("DELETE FROM kp.user WHERE(`id` = '" + i + "');", mySqlconnection);
            mySqlconnection.Close();
            LoaderUsers();
        }

        public void DeleteOrdersContent(int i)
        {
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("DELETE FROM kp.orderscontent WHERE(`id` = '" + i + "');", mySqlconnection);
            mySqlconnection.Close();
            LoaderUsers();
        }

        public void OpenAdd()
        {
            new Adding.Add(this).ShowDialog();
        }
        public void OpenAddOrder()
        {
            new Adding.AddProduct(this).ShowDialog();
        }
        public void OpenAddUser()
        {
            new Adding.AddUser(this).ShowDialog();
        }

        public void createinfochec(int i)
        {
            checks.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("SELECT orders.id,products.name,products.price,products.discount,orders.order_date FROM kp.orderscontent, kp.products, kp.orders where  orders.id_client = " + i+" and orders.id = orderscontent.order_id and orderscontent.product_article = products.article; ", mySqlconnection);
            while (tiket_query.Read())
            {
                checks.Add(new Classes.Chech(
                    Convert.ToInt32(tiket_query.GetValue(0)),
                    tiket_query.GetValue(1).ToString(),
                    tiket_query.GetValue(2).ToString(),
                    tiket_query.GetValue(3).ToString()
                    ));
            }
            mySqlconnection.Close();
        }
    }
}
