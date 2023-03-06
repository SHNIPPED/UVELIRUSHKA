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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public MainWindow mainWindow;
        public Admin(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            mainWindow.@out.Visibility = Visibility.Visible;
            Loadlist();
        }
        public void Loadlist()
        {
            info.Items.Clear();
            info1.Items.Clear();
            info2.Items.Clear();
            for (int i = 0; i < mainWindow.orders.Count; i++)
                info.Items.Add(mainWindow.orders[i]);
            for (int i = 0; i < mainWindow.products.Count; i++)
                info1.Items.Add(mainWindow.products[i]);
            for (int i = 0; i < mainWindow.user.Count; i++)
                info2.Items.Add(mainWindow.user[i]);
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                int s = info.SelectedIndex;
                int j = mainWindow.orders[s].id;
                mainWindow.OpenUp(j);
                Loadlist();
                info.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Сделайте выбор");
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var select = info.SelectedItems.Cast<Object>().ToArray();
                int s = info.SelectedIndex;
                int j = mainWindow.orders[s].id;
                foreach (var item in select)
                {
                    for (int i = 0; i < mainWindow.orders.Count; i++)
                    {
                        mainWindow.orders.Remove(mainWindow.orders[i]);

                    }
                    info.Items.Remove(item); 

                }
                mainWindow.Delete(j);
                Loadlist();
            }
            catch
            {
                MessageBox.Show("Сделайте выбор");
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenAdd();
            Loadlist();
            info.Items.Refresh();
        }

        private void UpdateOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                int s = info1.SelectedIndex;
                int j = mainWindow.products[s].id;
                mainWindow.OpenUpOrder(j);
                Loadlist();
                info1.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Сделайте выбор");
            }
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenAddOrder();
            Loadlist();
            info1.Items.Refresh();
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                var select = info1.SelectedItems.Cast<Object>().ToArray();
                int s = info1.SelectedIndex;
                int j = mainWindow.products[s].id;
                foreach (var item in select)
                {
                    for (int i = 0; i < mainWindow.products.Count; i++)
                    {
                        mainWindow.products.Remove(mainWindow.products[i]);

                    }
                    info1.Items.Remove(item);

                }
                mainWindow.DeleteOrder(j);
                Loadlist();
            }
            catch
            {
                MessageBox.Show("Сделайте выбор");
            }
        }

        private void UpdateUser(object sender, RoutedEventArgs e)
        {
            try
            {
                int s = info2.SelectedIndex;
                int j = mainWindow.user[s].UserID;
                mainWindow.OpenUpUser(j);
                Loadlist();
                info2.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Сделайте выбор");
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenAddUser();
            Loadlist();
            info2.Items.Refresh();
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            try
            {
                var select = info2.SelectedItems.Cast<Object>().ToArray();
                int s = info2.SelectedIndex;
                int j = mainWindow.user[s].UserID;
                foreach (var item in select)
                {
                    for (int i = 0; i < mainWindow.user.Count; i++)
                    {
                        mainWindow.user.Remove(mainWindow.user[i]);

                    }
                    info2.Items.Remove(item);

                }
                mainWindow.DeleteUser(j);
                Loadlist();
            }
            catch
            {
                MessageBox.Show("Сделайте выбор");
            }
        }
    }
}
