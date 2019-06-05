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

namespace Wpf_AntiqueShop
{
    /// <summary>
    /// Interaction logic for Buyer_Seller.xaml
    /// </summary>
    public partial class Buyer_Seller : Window
    {
        public Buyer_Seller()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Article is sold");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Article is bought");


        }
    }
}
