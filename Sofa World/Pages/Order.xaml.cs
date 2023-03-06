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
using System.IO;
using System.Data.Entity;

namespace Sofa_World.Pages
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public MainWindow mainWindow;
        public Order(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            CreateProduct();
            mainWindow.@out.Visibility = Visibility.Visible;
            mainWindow.cart.Visibility = Visibility.Visible;
        }
        public void CreateProduct()
        {
            for (int i = 0; i < mainWindow.ordProd.Count; i++)
            {
                var bc = new BrushConverter();
                if (Convert.ToInt32(mainWindow.ordProd[i].amount_on_warehouse) != 0)
                {
                    Grid global = new Grid();
                    global.Height = 130;
                    global.Margin = new Thickness(10, 5, 10, 5);



                    Image logo = new Image();
                    if (File.Exists(mainWindow.localPath + @"/img/" + mainWindow.ordProd[i].img_src))
                        logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"/img/" + mainWindow.ordProd[i].img_src));
                    else
                        logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"/picture.png"));


                    logo.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    logo.Height = 100;
                    logo.Margin = new Thickness(10, 10, 0, 0);
                    logo.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    logo.Width = 100;
                    global.Children.Add(logo);

                    Label name = new Label();
                    name.Content = "Name:" + mainWindow.ordProd[i].name;
                    name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    name.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    name.Margin = new Thickness(105, 0, 0, 0);
                    name.FontWeight = FontWeights.Bold;
                    global.Children.Add(name);

                    Label ProductDescription = new Label();
                    ProductDescription.Content = "Description:" + mainWindow.ordProd[i].description;
                    ProductDescription.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ProductDescription.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ProductDescription.Margin = new Thickness(105, 30, 0, 0);
                    global.Children.Add(ProductDescription);

                    Label ProductManufacturer = new Label();
                    ProductManufacturer.Content = "Manufacturer:" + mainWindow.ordProd[i].manufacturer;
                    ProductManufacturer.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ProductManufacturer.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ProductManufacturer.Margin = new Thickness(105, 60, 0, 0);
                    global.Children.Add(ProductManufacturer);

                    Label ProductDiscount = new Label();
                    ProductDiscount.Content = "Discount:" + mainWindow.ordProd[i].discount;
                    ProductDiscount.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    ProductDiscount.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ProductDiscount.Margin = new Thickness(0, 90, 135, 0);
                    ProductDiscount.FontWeight = FontWeights.Bold;
                    if (Convert.ToInt32(mainWindow.ordProd[i].discount) > 14)
                    {
                        global.Background = (Brush)bc.ConvertFrom("#7fff00");
                    }
                    else
                    {
                        global.Background = (Brush)bc.ConvertFrom("#FF76E383");
                    }
                    global.Children.Add(ProductDiscount);



                    Label ProductCost = new Label();
                    ProductCost.Content = "Cost:" + (Convert.ToInt32(mainWindow.ordProd[i].price) - (Convert.ToInt32(mainWindow.ordProd[i].price) / 100 * Convert.ToInt32(mainWindow.ordProd[i].discount)));
                    ProductCost.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ProductCost.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ProductCost.Margin = new Thickness(105, 90, 0, 0);
                    global.Children.Add(ProductCost);


                    Button Buy = new Button();
                    Buy.Content = "Order";
                    Buy.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    Buy.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    Buy.Margin = new Thickness(0, 65, 5, 0);
                    Buy.Tag = i;
                    Buy.Click += delegate
                    {
                        int code = 711 + mainWindow.orders.Count;
                        Random rnb = new Random();
                        int point = rnb.Next(1, 45);
                        string b = "7";
                        DateTime dt = DateTime.Now;
                        DateTime dn = DateTime.Now.Add(TimeSpan.Parse(b));
                        string Date = dt.ToShortDateString();
                        string DateNext = dn.ToShortDateString();
                        int sum = Convert.ToInt32(Buy.Tag);
                        int s = mainWindow.products[sum].id;
                        int d = Convert.ToInt32(mainWindow.ordProd[sum].amount_on_warehouse);
                        d--;
                        string connection = "server=localhost;port=3306;database=kp;uid=root;pwd=Asdfg123";
                        MySqlConnection mySqlconnection = new MySqlConnection(connection);
                        mySqlconnection.Open();
                        MySqlDataReader tiket_query = WorkingBD.Query(" INSERT INTO  `kp`.`orders` (`order_date`, `delivery_date`, `point_of_issue`,`id_client`,`receive_code`,`order_status`) VALUES('" + Date + "', '" + DateNext + "', '" + point + "' ,'" + mainWindow.IdUser + "' ,'" + code + "' ,' новый ');", mySqlconnection);
                        mySqlconnection.Close();
                        mainWindow.Loadre();
                        mainWindow.LoadreOrder();
                        mainWindow.LoadreOrders();
                        parrent.Children.Clear();
                        CreateProduct();

                    };
                    global.Children.Add(Buy);

                    parrent.Children.Add(global);
                }
                else
                {

                }
            }
        } 
    }
}
