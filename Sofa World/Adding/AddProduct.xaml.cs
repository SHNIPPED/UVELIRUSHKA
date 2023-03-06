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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public MainWindow mainWindow;
        public AddProduct(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int k = mainWindow.products.Count + 1;
                string connection = "server=localhost;port=3306;database=practice;uid=root;pwd=Asdfg123";
                MySqlConnection mySqlconnection = new MySqlConnection(connection);
                mySqlconnection.Open();
                MySqlDataReader tiket_query = WorkingBD.Query("INSERT INTO `kp`.`products` (`article`, " +
                    "`name`, " +
                    "`measure_unit`, " +
                    "`price`, " +
                    "`max_discount`, " +
                    "`manufacturer`, " +
                    "`supplier`, " +
                    "`category_id`, " +
                    "`discount`, " +
                    "`amount_on_warehouse`, " +
                    "`description`, " +
                    "`img_src`) " +
                    "VALUES('" + article.Text+ "', " +
                    "'" + name.Text + "', " +
                    "'" + measure_unit.Text + "', " +
                    "'" + price.Text + "', " +
                    "'" + max_discount.Text + "', " +
                    "'" + manufacturer.Text + "', " +
                    "'" + supplier.Text + "', '" + category_id.Text + "', '" + discount.Text + "', '" + amount_on_warehouse.Text + "', '" + description.Text + "' , '" +img_src.Text+".jpg');", mySqlconnection);
                mySqlconnection.Close();
                mainWindow.Loadre();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }   
    }
}
