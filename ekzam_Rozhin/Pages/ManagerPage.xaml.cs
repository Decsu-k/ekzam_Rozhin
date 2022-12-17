using ekzam_Rozhin.AppDataFile;
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
using Task = ekzam_Rozhin.AppDataFile.Task;

namespace ekzam_Rozhin.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            DGridExecutor.ItemsSource = ekzam_RozhinEntities.GetContext().Task.ToList();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPageE((sender as Button).DataContext as Task));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Manager.MainFrame.Navigate(new AddEditPageE(null));
            MessageBox.Show("В данный момент вы не можете добавить данные. " +
                "Данная функция находиться в разработке!");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var taskForRemoving = DGridExecutor.SelectedItems.Cast<Task>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {taskForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ekzam_RozhinEntities.GetContext().Task.RemoveRange(taskForRemoving);
                    ekzam_RozhinEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridExecutor.ItemsSource = ekzam_RozhinEntities.GetContext().Task.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ekzam_RozhinEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridExecutor.ItemsSource = ekzam_RozhinEntities.GetContext().Task.ToList();
        }
    }
}
