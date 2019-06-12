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
    /// Interaction logic for ArticleInformation.xaml
    /// </summary>
    public partial class ArticleInformation : Window
    {
        ObservableCollection<ArticleInfo> articleinfo;
        String filter = "";
        private bool storeData;

        public ArticleInformation()
        {
            InitializeComponent();
            //var lst = new List<ArticleInfo> { new ArticleInfo {  firstName = "xxx", lastName = "yyyy", soldarticleName = "zzz",
            //          purchasedarticleName = "aaaa", price="ssss"},
            //new ArticleInfo {  firstName = "xxx", lastName = "yyyy", soldarticleName = "zzz", purchasedarticleName = "aaaa", price="ssss"},
            //new ArticleInfo {  firstName = "xxx", lastName = "yyyy", soldarticleName = "zzz", purchasedarticleName = "aaaa", price="ssss"},
            //new ArticleInfo {  firstName = "xxx", lastName = "yyyy", soldarticleName = "zzz", purchasedarticleName = "aaaa", price="ssss"} };
            //TestStorage.WriteXml<List<ArticleInfo>>(lst, "ArticleInfo.xml");
            //articleinfo = TestStorage.ReadXml<ObservableCollection<ArticleInfo>>("ArticleInfo.xml");


        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter.Text.ToLower();
            if (filter == "")
            {
                Lbx_articles.ItemsSource = articleinfo;
            }
            else
            {
                var results = from a in articleinfo where a.lastName.ToLower().Contains(filter) select a;
                Lbx_articles.ItemsSource = results;


            }

            storeData = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            articleinfo = TestStorage.ReadXml<ObservableCollection<ArticleInfo>>("ArticleInfo.xml");
            //articleinfo = GenerateArticleInfo(20);
            //TestStorage.WriteXml<ObservableCollection<ArticleInfo>>(articleinfo, "ArticleInfo.xml");
            Lbx_articles.ItemsSource = articleinfo;
        }

        private ObservableCollection<ArticleInfo> GenerateArticleInfo(int count)
        {
            {
                var lst1 = new ObservableCollection<ArticleInfo>();
                for (int i = 0; i < count; i++)
                {
                    lst1.Add(new ArticleInfo { firstName = "xxx", lastName = "yyyy", soldarticleName = "zzz",
                        purchasedarticleName = "aaaa", price = "ssss" });
                }
                return lst1;

            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (storeData)
                TestStorage.WriteXml<ObservableCollection<ArticleInfo>>(articleinfo, "ArticleInfo.xml");
            Owner.Visibility = Visibility.Visible;

        }
    }
}
