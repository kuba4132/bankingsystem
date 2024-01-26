using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;




namespace bankapp
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        public string PathToBalance = ((Directory.GetCurrentDirectory() + @"\Balance.txt"));

        //public string PathToBalance = @"C:\Users\kuba\source\repos\bankapp\balance.txt";
        public string balance;
        public Page2()
        {
            
            InitializeComponent();
            displaylogin.Text = Page1.login;

            using (StreamReader read = new StreamReader(PathToBalance))
            {
                balance = read.ReadLine();   
            }
            balanceblock.Text = balance;



            

        }

        private void withdrawbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("withdrawpage.xaml", UriKind.Relative));
        }

        private void logoutbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }

        private void depositebtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("depositepage.xaml", UriKind.Relative));
        }
    }
}
