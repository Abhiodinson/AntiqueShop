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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_AntiqueShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ArticleName> articles;
        String filter = "";
        private bool storeData;
        Random rnd = new Random();
        public MainWindow()
        {

            InitializeComponent();
            var lst = new List<ArticleName> { new ArticleName { id = "i", name = "xxx", description = "m", price = "p", }, new ArticleName { id = "i", name = "xxx", description = "m", price = "p", }, new ArticleName { id = "i", name = "xxx", description = "m", price = "p", }, new ArticleName { id = "i", name = "xxx", description = "m", price = "p", }, new ArticleName { id = "i", name = "xxx", description = "m", price = "p", }, new ArticleName { id = "i", name = "xxx", description = "m", price = "p", }, new ArticleName { id = "i", name = "xxx", description = "m", price = "p", } };
            //TestStorage.WriteXml<List<ArticleName>>(lst, "ArticleData.xml");
            articles= TestStorage.ReadXml<ObservableCollection<ArticleName>>( "ArticleData.xml");
            Dgr_articles.ItemsSource = articles;



            //TestStorage.WriteXml<List<ArticleName>>(lst, "ArticleNameD.xml");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            articles = GenerateArticles(7);
            //TestStorage.WriteXml<ObservableCollection<ArticleName>>(articles, "StudentsTest.xml");
        }

        private ObservableCollection<ArticleName> GenerateArticles(int count)
        {
            
            var lst = new ObservableCollection<ArticleName>();
            for (int i = 0; i < count; i++)
            {
                lst.Add(new ArticleName { id = "i", name = "xxxx", description = "m", price = "p" });
            }
            return lst;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var win = new Buyer_Seller();
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Hidden;
        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter.Text.ToLower();
            if (filter=="")
            {
                Dgr_articles.ItemsSource = articles;
            }
            else
            {
                var results = from a in articles where a.name.ToLower().Contains(filter) select a;
                Dgr_articles.ItemsSource = results;

            }
        }
    }
}

