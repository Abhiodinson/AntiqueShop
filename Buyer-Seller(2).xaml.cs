using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Buyer_Seller_2_.xaml
    /// </summary>
    public partial class Buyer_Seller_2_ : Window
    {
        ObservableCollection<CustomerName> customers;
        String filter = "";
        private bool storeData;

        public object Dgr_articles { get;  set; }
       

        public Buyer_Seller_2_()
        {
            InitializeComponent();
            //var lst = new List<CustomerName> { new CustomerName {  firstName = "xxx", lastName = "yyyy", Address = "zzz", Phone = "aaaa" },
            //    new CustomerName { firstName = "xxx", lastName = "yyyy", Address = "zzz", Phone = "aaaa"  },
            //    new CustomerName { firstName = "xxx", lastName = "yyyy", Address = "zzz", Phone = "aaaa"  },
            //    new CustomerName { firstName = "xxx", lastName = "yyyy", Address = "zzz", Phone = "aaaa"  }};
            //TestStorage.WriteXml<List<CustomerName>>(lst, "CustomerData.xml");
            customers = TestStorage.ReadXml<ObservableCollection<CustomerName>>("CustomerData.xml");
            Lbx_students.ItemsSource = customers;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            customers = GenerateCustomers(20);
            //TestStorage.WriteXml<ObservableCollection<CustomerName>>(customers, "CustomerTest.xml");
        }

        private ObservableCollection<CustomerName> GenerateCustomers(int cnt)
        {
            var lst = new ObservableCollection<CustomerName>();
            for (int i = 0; i < cnt; i++)
            {
                lst.Add(new CustomerName { firstName = "xxxx", lastName = "yyyy", Address = "zzz", Phone = "aaaa" });
            }
            return lst;

        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            var cust = new CustomerName { firstName = "Please edit!!!", lastName = "Please edit!!!",
                Address = "Please edit!!!", Phone = "Please edit!!!" };
            customers.Add(cust);
            Lbx_students.SelectedItem = cust;
            Lbx_students.ScrollIntoView(cust);

        }

        //private void Btn_delete_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Lbx_students.SelectedItem == null)
        //    {
        //        MessageBox.Show("Please select an item to be deleted", "Error");
        //        return;
        //    }
        //    customers.Remove(Lbx_students.SelectedItem as CustomerName);
        //    Tbx_filter.Text = "";

        //}



        private void Tbx_filter_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter.Text.ToLower();
            if (filter == "")
            {
                Lbx_students.ItemsSource = customers;
            }
            else
            {
                var results = from c in customers where c.lastName.ToLower().Contains(filter) select c;
                Lbx_students.ItemsSource = results;


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_firstName.Text == "" && tb_lastName.Text == "" && tb_address.Text =="" && tb_phone.Text == "" && tb_article.Text == "" && tb_price.Text == "")
            {
                MessageBox.Show("Please provide the information", "Error");

            }
            else
            {
                MessageBox.Show("Article is sold");
                var win = new ArticleInformation();
                win.Owner = this;
                win.Show();
                Visibility = Visibility.Hidden;
            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (tb_firstName.Text == "" && tb_lastName.Text == "" && tb_address.Text == "" && tb_phone.Text == "" && tb_article.Text == "" && tb_price.Text == "")
            {
                MessageBox.Show("Please provide the information", "Error");

            }
            else
            {
                MessageBox.Show("Article is bought");
                var win = new ArticleInformation();
                win.Owner = this;
                win.Show();
                Visibility = Visibility.Hidden;
            }            
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            storeData = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (storeData)
                TestStorage.WriteXml<ObservableCollection<CustomerName>>(customers, "CustomerTest.xml");

        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
            
        }

    }
}
