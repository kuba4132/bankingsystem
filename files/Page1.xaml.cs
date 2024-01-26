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
    /// Interaction logic for Page1.xaml
    /// </summary>
    /// 


    public partial class Page1 : Page
    {

        public string PathToLogin = ((Directory.GetCurrentDirectory() + @"\login.txt"));
        public string PathToPin = ((Directory.GetCurrentDirectory() + @"\pin.txt"));


        //public string PathToLogin = @"C:\Users\kuba\source\repos\bankapp\login.txt";
        //public string PathToPin = @"C:\Users\kuba\source\repos\bankapp\pin.txt";
        public static string login;
        public string new_login;
        public string login_check;

        public string pin;
        public string pincheck;
        public string pin_bin;





        public Page1()
        {
            InitializeComponent();
        }

        public void BtnClickLogin(object sender, RoutedEventArgs e)
        {

            login = loginbox.Text;



            
            
            using(StreamReader read = new StreamReader(PathToLogin))
            {
                login_check = read.ReadLine();
            }

            using(StreamReader read = new StreamReader(PathToPin))
            {
                pincheck = read.ReadLine();
            }

            pin = pinbox.Text;
            if (pinbox.Text == string.Empty || loginbox.Text == string.Empty) {
                MessageBox.Show("Please enter a correct value");
            }
            else
            {
                int pin_int = Convert.ToInt32(pin);
                pin_bin = Convert.ToString(pin_int, 2);
            }










            if (login == login_check && pincheck == pin_bin)
            {

                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(new Uri("Page2.xaml", UriKind.Relative));
                
            }
            else
            {
                loginfail.Visibility = Visibility.Visible;

            }







        }
    }
}
