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
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace Sofa_World.Pages
{
    /// <summary>
    /// Логика взаимодействия для korz.xaml
    /// </summary>
    public partial class korz : Page
    {
        public MainWindow mainWindow;
        public korz(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            CreateProduct();
            mainWindow.@out.Visibility = Visibility.Visible;
            mainWindow.cart.Visibility = Visibility.Visible;
        }
        public void CreateProduct()
        {
            for (int i = 0; i < mainWindow.ordersUser.Count; i++)
            {
                var bc = new BrushConverter();

                Grid global = new Grid();
                global.Height = 130;
                global.Margin = new Thickness(10, 5, 10, 5);
                global.Background = (Brush)bc.ConvertFrom("#FF76E383");


                Label name = new Label();
                name.Content = "order_date:" + mainWindow.ordersUser[i].order_date;
                name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                name.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                name.Margin = new Thickness(105, 0, 0, 0);
                name.FontWeight = FontWeights.Bold;
                global.Children.Add(name);

                Label ProductDescription = new Label();
                ProductDescription.Content = "delivery_date:" + mainWindow.ordersUser[i].delivery_date;
                ProductDescription.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                ProductDescription.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                ProductDescription.Margin = new Thickness(105, 30, 0, 0);
                global.Children.Add(ProductDescription);

                Label ProductManufacturer = new Label();
                ProductManufacturer.Content = "point_of_issue:" + mainWindow.ordersUser[i].point_of_issue;
                ProductManufacturer.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                ProductManufacturer.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                ProductManufacturer.Margin = new Thickness(105, 60, 0, 0);
                global.Children.Add(ProductManufacturer);

                Label ProductDiscount = new Label();
                ProductDiscount.Content = "receive_code:" + mainWindow.ordersUser[i].receive_code;
                ProductDiscount.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                ProductDiscount.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                ProductDiscount.Margin = new Thickness(0, 90, 135, 0);
                ProductDiscount.FontWeight = FontWeights.Bold;
                global.Children.Add(ProductDiscount);


                Label ProductCost = new Label();
                ProductCost.Content = "order_status:" + mainWindow.ordersUser[i].order_status;
                ProductCost.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                ProductCost.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                ProductCost.Margin = new Thickness(105, 90, 0, 0);
                global.Children.Add(ProductCost);

                Button Buy = new Button();
                Buy.Content = "сheque";
                Buy.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                Buy.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                Buy.Margin = new Thickness(0, 65, 5, 0);
                Buy.Tag = i;
                Buy.Click += delegate
                {

                    Random rand = new Random();
                    PdfDocument document = new PdfDocument();
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XFont font = new XFont("MS Comic Sans", 12);
                    XFont fontX = new XFont("MS Comic Sans", 30, XFontStyle.Bold);
                    double Width = 0;
                    double Height = 0;
                    double sum = 0;
                    string sumD = "";
                    gfx.DrawString("Состав заказа: ", font, XBrushes.Black, new XRect(5, 5, Width, Height), XStringFormats.CenterLeft);

                        int id = int.Parse(Buy.Tag.ToString());
                        Width += 40;
                        Height += 40;
                        sum += (Convert.ToInt32(mainWindow.checks[id].price) - (Convert.ToInt32(mainWindow.checks[id].price) / 100 * Convert.ToInt32(mainWindow.checks[id].discount)));
                        sumD += mainWindow.checks[id].discount;
                        gfx.DrawString(mainWindow.checks[id].Name, font, XBrushes.Black, new XRect(5, 5, Width, Height), XStringFormats.CenterLeft);
                   
                    Width += 40;
                    Height += 40;
                    gfx.DrawString("Дата заказа: " + DateTime.Now.Date.ToString(), font, XBrushes.Black, new XRect(5, 5, Width, Height), XStringFormats.CenterLeft);
                    Width += 40;
                    Height += 40;
                    gfx.DrawString("Номер заказа: " + mainWindow.ordersUser.Count(), font, XBrushes.Black, new XRect(5, 5, Width, Height), XStringFormats.CenterLeft);
                    Width += 40;
                    Height += 40;
                    gfx.DrawString("Сумма заказа: " + sum.ToString(), font, XBrushes.Black, new XRect(5, 5, Width, Height), XStringFormats.CenterLeft);
                    Width += 40;
                    Height += 40;
                    gfx.DrawString("Сумма скидки: " + sumD.ToString(), font, XBrushes.Black, new XRect(5, 5, Width, Height), XStringFormats.CenterLeft);
                    Width += 40;
                    Height += 40;
                    Width += 40;
                    Height += 40;
                    Width += 40;
                    Height += 40;
                    gfx.DrawString("Код получения: " + rand.Next(1, 1000).ToString(), fontX, XBrushes.Black, new XRect(0, 0, Width, Height), XStringFormats.Center);
                    string filename = "Чек " + mainWindow.ordersUser.Count() + ".pdf";
                    document.Save(filename);
                    Process.Start(filename);

                };
                global.Children.Add(Buy);
                parrent.Children.Add(global);

            }
        }
    }
}
