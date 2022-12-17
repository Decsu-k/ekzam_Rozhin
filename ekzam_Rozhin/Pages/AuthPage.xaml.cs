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
using System.Windows.Threading;

namespace ekzam_Rozhin.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object s, EventArgs ev) =>
            {
                this.myDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }, this.Dispatcher);
            timer.Start();
        }

        private void ButtonAuthE_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ExecutorPage());
        }

        private void ButtonAuthM_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ManagerPage());
        }
    }
}
