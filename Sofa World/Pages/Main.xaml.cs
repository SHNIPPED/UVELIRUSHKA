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
using System.IO;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace Sofa_World.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainWindow mainWindow;
        public Main(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            CreateProduct();
            LoadCategory();
            mainWindow.@out.Visibility = Visibility.Visible;
            mainWindow.cart.Visibility = Visibility.Visible;
            mainWindow.ord.Visibility = Visibility.Visible;
        }
        public void LoadCategory()
        {
            category.Items.Clear();
            for (int i= 0; i < mainWindow.categories.Count; i++)
            {
                //category.ItemsSource = mainWindow.categories[i].name;
                category.Items.Add(mainWindow.categories[i].name);
            }
        }
        public void CreateProduct()
        {
            int d = 0;  
            for (int i = 0; i < mainWindow.products.Count; i++)
            {
                var bc = new BrushConverter();
                if(Convert.ToInt32(mainWindow.products[i].amount_on_warehouse) != 0)
                {
                    Grid global = new Grid();
                    global.Height = 130;
                    global.Margin = new Thickness(10, 5, 10, 5);



                    Image logo = new Image();
                    if (File.Exists(mainWindow.localPath + @"/img/" + mainWindow.products[i].img_src))
                        logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"/img/" + mainWindow.products[i].img_src));
                    else
                        logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"/picture.png"));


                    logo.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    logo.Height = 100;
                    logo.Margin = new Thickness(10, 10, 0, 0);
                    logo.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    logo.Width = 100;
                    global.Children.Add(logo);

                    Label name = new Label();
                    name.Content = "Name:" + mainWindow.products[i].name;
                    name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    name.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    name.Margin = new Thickness(105, 0, 0, 0);
                    name.FontWeight = FontWeights.Bold;
                    global.Children.Add(name);

                    Label ProductDescription = new Label();
                    ProductDescription.Content = "Description:" + mainWindow.products[i].description;
                    ProductDescription.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ProductDescription.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ProductDescription.Margin = new Thickness(105, 30, 0, 0);
                    global.Children.Add(ProductDescription);

                    Label ProductManufacturer = new Label();
                    ProductManufacturer.Content = "Manufacturer:" + mainWindow.products[i].manufacturer;
                    ProductManufacturer.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ProductManufacturer.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ProductManufacturer.Margin = new Thickness(105, 60, 0, 0);
                    global.Children.Add(ProductManufacturer);

                    Label ProductCost = new Label();
                    ProductCost.Content = "Cost:" + mainWindow.products[i].price;
                    ProductCost.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ProductCost.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ProductCost.Margin = new Thickness(105, 90, 0, 0);
                    global.Children.Add(ProductCost);

                    Rectangle rectangle = new Rectangle();
                    rectangle.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    rectangle.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    rectangle.Margin = new Thickness(145, 105, 0, 0);
                    rectangle.Width = 50;
                    rectangle.Height = 2;
                    rectangle.Stroke = (Brush)bc.ConvertFrom("#FFFF0B0B");
                    rectangle.Fill = (Brush)bc.ConvertFrom("#FFFF0B0B");
                    rectangle.Visibility = Visibility.Hidden;
                    global.Children.Add(rectangle);

                    Label ProductDiscount = new Label();
                    ProductDiscount.Content = "Discount:" + mainWindow.products[i].discount + "%";
                    ProductDiscount.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    ProductDiscount.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ProductDiscount.Margin = new Thickness(0, 90, 135, 0);
                    ProductDiscount.FontWeight = FontWeights.Bold;
                    if (Convert.ToInt32(mainWindow.products[i].discount) > 0)
                    {
                        double newprice = Convert.ToDouble(mainWindow.products[i].price)- (Convert.ToDouble(mainWindow.products[i].price) / 100 * Convert.ToDouble(mainWindow.products[i].discount));
                        rectangle.Visibility = Visibility.Visible;
                        ProductCost.Content += "     " + newprice;
                    }
                    if (Convert.ToInt32(mainWindow.products[i].discount) > 14)
                    {
                        global.Background = (Brush)bc.ConvertFrom("#7fff00");
                    }
                    else
                    {
                        global.Background = (Brush)bc.ConvertFrom("#FF76E383");
                    }
                    global.Children.Add(ProductDiscount);


                    Label Amount_count = new Label();
                    Amount_count.Content = 1;
                    Amount_count.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    Amount_count.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    Amount_count.Margin = new Thickness(0, 0, 35, 0);
                    global.Children.Add(Amount_count);

                    Button plus = new Button();
                    plus.Content = "+";
                    plus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    plus.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    plus.Margin = new Thickness(0, 3, 5, 0);
                    plus.Width = 25;
                    plus.Tag = i;
                    plus.Click += delegate
                    {
                        int sum = Convert.ToInt32(plus.Tag);
                        int s = mainWindow.products[sum].id;
                        if (Convert.ToInt32(mainWindow.products[sum].amount_on_warehouse) == Convert.ToInt32(Amount_count.Content))
                        {

                        }
                        else
                        {
                            Amount_count.Content = (Convert.ToInt32(Amount_count.Content) + 1).ToString();
                        }
                    };
                    global.Children.Add(plus);


                    Button minus = new Button();
                    minus.Content = "-";
                    minus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    minus.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    minus.Margin = new Thickness(0, 3, 60, 0);
                    minus.Width = 25;
                    minus.Tag = i;
                    minus.Click += delegate
                    {
                        int sum = Convert.ToInt32(plus.Tag);
                        int s = mainWindow.products[sum].id;
                        if (Convert.ToInt32(Amount_count.Content) == 1)
                        {

                        }
                        else
                        {
                            Amount_count.Content = (Convert.ToInt32(Amount_count.Content) - 1).ToString();
                        }
                    };
                    global.Children.Add(minus);


                    Button Buy = new Button();
                    Buy.Content = "Buy";
                    Buy.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    Buy.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    Buy.Margin = new Thickness(0, 65, 5, 0);
                    Buy.Tag = i;
                    Buy.Click += delegate
                    {
                        int sum = Convert.ToInt32(Buy.Tag);
                        int s = mainWindow.products[sum].id;
                        d = Convert.ToInt32(mainWindow.products[sum].amount_on_warehouse);
                        d = d - Convert.ToInt32(Amount_count.Content);
                        string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
                        MySqlConnection mySqlconnection = new MySqlConnection(connection);
                        mySqlconnection.Open();
                        MySqlDataReader tiket_query = WorkingBD.Query(" INSERT INTO  `kp`.`orderscontent` (`order_id`, `product_article`, `amount` ,`id_client`) VALUES('" + s + "','" + mainWindow.products[sum].article + "', '" + mainWindow.products[sum].amount_on_warehouse + "', '" + mainWindow.IdUser + "');", mySqlconnection);
                        mySqlconnection.Close();
                        mainWindow.Loadre();
                        mainWindow.LoadreOrder();
                        parrent.Children.Clear();
                        CreateProduct();

                    };
                    global.Children.Add(Buy);

                    parrent.Children.Add(global);
                }
                else{
                  
                }
            }
        }
        public string text;
        public int catg = 0;
        public int dis = 0;
        public int dis1 = 0;
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            text = Search.Text;
            if (catg != 0)
            {      
                Searching();
            }
            else
            {
                mainWindow.products.Clear();
                string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
                MySqlConnection mySqlconnection = new MySqlConnection(connection);
                mySqlconnection.Open();
                MySqlDataReader tiket_query = WorkingBD.Query("SELECT * FROM kp.products where name like '%" + text + "%';", mySqlconnection);


                while (tiket_query.Read())
                {
                    mainWindow.products.Add(new Classes.Product(
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
                parrent.Children.Clear();
                CreateProduct();
            }
        }

        private void category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            catg = category.SelectedIndex + 1;  
             Searching();
        }

        public void Searching()
        {
            int _category = catg;
            string _name = text;
            mainWindow.products.Clear();
            string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
            MySqlConnection mySqlconnection = new MySqlConnection(connection);
            mySqlconnection.Open();
            MySqlDataReader tiket_query = WorkingBD.Query("SELECT * FROM kp.products where name like '%" + _name + "%'  and category_id like '" + _category + "%';", mySqlconnection);


            while (tiket_query.Read())
            {
                mainWindow.products.Add(new Classes.Product(
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
            parrent.Children.Clear();
            CreateProduct();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            text = "";
            LoadCategory();
            mainWindow.Loadre();
            parrent.Children.Clear();
            CreateProduct();
        }

    }
}