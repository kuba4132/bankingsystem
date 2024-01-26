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
    /// Interaction logic for withdrawpage.xaml
    /// </summary>
    public partial class withdrawpage : Page
    {

        public string PathToBalance = ((Directory.GetCurrentDirectory() + @"\Balance.txt"));
        //public string PathToBalance = @"C:\Users\kuba\source\repos\bankapp\balance.txt";
        public static double balance_reed_double;
        public string new_balance_str;
        public static double balancefromBox;


        public withdrawpage()
        {
            InitializeComponent();
        }

        private void menubutton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Page2.xaml", UriKind.Relative));
        }


        //button logic
        private void withdrawbutton_click(object sender, RoutedEventArgs e)
        {
            using (StreamReader read = new StreamReader(PathToBalance))
            {
                string balance_reed = read.ReadLine();
                balance_reed_double = Convert.ToInt32(balance_reed);
            }
            
            balancefromBox = Convert.ToDouble(withdrawBox.Text);
            //int balance_reed_int = Convert.ToInt32(balance_reed);
            double new_balance = balance_reed_double - balancefromBox;

            new_balance_str = Convert.ToString(new_balance);

            using(StreamWriter write = new StreamWriter(PathToBalance))
            {
                write.WriteLine(new_balance);
            }
            MessageBox.Show("New balance is: "+new_balance_str);

            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Page2.xaml", UriKind.Relative));

        }
    }
}
