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

namespace kyrsovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
         public void move()
        {
            openpage.Margin = new Thickness(1000,0,0,0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn.Margin = new Thickness(1000,0,0,0);
            openpage.Margin = new Thickness(1000,0,0,0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btn.Margin = new Thickness(300, 350, 300, 50);
            openpage.Margin = new Thickness(0, 0, 0, 0);
        }
    }
}
