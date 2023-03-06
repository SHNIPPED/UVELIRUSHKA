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
    /// Логика взаимодействия для UpProduct.xaml
    /// </summary>
    public partial class UpProduct : Window
    {
        public MainWindow mainWindow;
        int h = 0;
        public UpProduct(MainWindow _mainWindow, int i)
        {
            InitializeComponent();
            h = i;
            mainWindow = _mainWindow;
            Load();
        }
        private void Load()
        {
            for (int i = 0; i < mainWindow.upProduct.Count; i++)
            {
                article.Text = mainWindow.upProduct[i].article;
                name.Text = mainWindow.upProduct[i].name;
                measure_unit.Text = mainWindow.upProduct[i].measure_unit;
                price.Text = Convert.ToString(mainWindow.upProduct[i].price);
                max_discount.Text = mainWindow.upProduct[i].max_discount;
                manufacturer.Text = mainWindow.upProduct[i].manufacturer;
                supplier.Text = mainWindow.upProduct[i].supplier;
                category_id.Text = mainWindow.upProduct[i].category_id;
                discount.Text = mainWindow.upProduct[i].discount;
                amount_on_warehouse.Text = mainWindow.upProduct[i].amount_on_warehouse;
                description.Text = mainWindow.upProduct[i].description;
                img_src.Text = mainWindow.upProduct[i].img_src;
            }
        }
        private void update_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.upProduct.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("UPDATE kp.products SET `article` = '" + article.Text + "', " +
                "`name` = '" + name.Text + "', " +
                "`measure_unit` = '" + measure_unit.Text + "'," +
                " `price` = '" + price.Text + "' ," +
                " `max_discount` = '" + max_discount.Text + "' ," +
                " `manufacturer` = '" + manufacturer.Text + "' ," +
                " `supplier` = '" + supplier.Text + "'," +
                " `category_id` = '" + category_id.Text + "'," +
                " `discount` = '" + discount.Text + "', " +
                "`amount_on_warehouse` = '" + amount_on_warehouse.Text + "'," +
                "`description` = '" + description.Text + "'," +
                "`img_src` = '" + img_src.Text + "'" +
                " WHERE (`id` = '" + h + " ');", mySqlconnection);
            mySqlconnection.Close();
            mainWindow.Loadre();
            this.Close();
        }
    }
}
