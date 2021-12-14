using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Web.WebView2.Core;

namespace hash_browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = new Model();
            DataContext = _vm;
            if(!File.Exists(@"bookmarks.txt")){
                StreamWriter streamWriter = File.CreateText(@"bookmarks.txt");
                streamWriter.WriteLine("https://duckduckgo.com/");
                streamWriter.Close();
            }

            try{
                var logFile = File.ReadAllLines(@"bookmarks.txt");
                foreach (string url in logFile){
                    _vm.Items.Add(url);
                }
            }catch(IOException e){
                Console.Error.WriteLine(e.Message);
            }
        }

        void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(addressBar.Text);
            }
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ButtonGo_Click(sender, e);
            }
        }
        private void OnNavigationStartingHandler(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            addressBar.Text = new Uri(e.Uri).AbsoluteUri;
        }

        private void OnNavigationCompletedHandler(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            //addressBar.Text = new Uri(e.Uri).AbsoluteUri;
        }
    }

}
