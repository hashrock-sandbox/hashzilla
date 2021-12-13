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
using Microsoft.Web.WebView2.Core;

namespace hash_browser
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
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
      // update the address bar
      addressBar.Text = new Uri(e.Uri).AbsoluteUri;
    }

    private void OnNavigationCompletedHandler(object sender, CoreWebView2NavigationCompletedEventArgs e)
    {
      // addressBar.Text = e.Uri.AbsoluteUri;
    }
  }

}
