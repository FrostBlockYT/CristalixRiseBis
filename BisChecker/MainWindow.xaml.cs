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

namespace BisChecker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double tier9_valuse=0, tier10_valuse=0, tier9_count=0, tier10_count=0;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tier9_count++;
            UpdateValue();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tier10_count++;
            UpdateValue();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            UpdateValue();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tier9.IsReadOnly = true;
            tier9.IsEnabled = false;
            try
            {
                tier9_valuse = double.Parse(tier9.Text.ToString().Replace(@".", ","));
            }
            catch (Exception ex)
            { MessageBox.Show("Undefined value"); tier9.IsReadOnly = false; tier9.IsEnabled = true; }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tier10.IsReadOnly = true;
            tier10.IsEnabled = false;
            try
            {
                tier10_valuse = double.Parse(tier10.Text.ToString().Replace(@".", ","));
            }
            catch (Exception ex)
            { MessageBox.Show("Undefined value"); tier10.IsReadOnly = false; tier10.IsEnabled = true; }
        }

        private void UpdateValue()
        {
            bool localB = (localbis.IsChecked == true);
            bool globalB = (globalbis.IsChecked == true);
            bool localS = (localsvalks.IsChecked == true);
            bool globalS = (globalsvalk.IsChecked == true);
            double localBv = 0, globalBv = 0, localSv = 0, globalSv = 0;
            double multiplier = 1;
            if(localB)
            {
                localBv = 1.5;
            }
            if(globalB)
            {
                globalBv = 1.5;
            }
            if(localS)
            {
                localSv = 1.5;
            }
            if(globalS)
            {
                globalSv = 1.5;
            }
            multiplier = globalSv + globalBv + localSv + localBv;
            if(multiplier==0)
            {
                multiplier = 1;
            }
            double kek = (tier10_valuse * tier10_count  + tier9_count * tier9_valuse)*multiplier;
            if(kek >= 1000)
            {
                amount.Content = "Amount: " + Math.Round(kek/1000, 2, MidpointRounding.ToEven) + "Q" ;
            }
            else
                amount.Content = "Amount: " + Math.Round(kek, 2, MidpointRounding.ToEven) + "T";
        }
    }
}
