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

namespace Sofa_World.Pages
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Page
    {
        public MainWindow mainWindow;
        public Manager(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            mainWindow.@out.Visibility = Visibility.Visible;
            Loadlist();
        }
        public void Loadlist()
        {
            info.Items.Clear();
            for (int i = 0; i < mainWindow.orders.Count; i++)
                info.Items.Add(mainWindow.orders[i]);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = mainWindow.orders[info.SelectedIndex].id;
                mainWindow.OpenUp(j);
                Loadlist();
            }
            catch
            {
                MessageBox.Show("Сделайте выбор");
            }
        }
    }
}
