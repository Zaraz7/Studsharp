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

namespace Studsharp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        public AddEditPage()
        {
            InitializeComponent();
            ComboDiscipline.ItemsSource = StudyBaseEntities.GetContext().Discipline.ToList();
            GroupCb.ItemsSource = StudyBaseEntities.GetContext().Group.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GroupCbSelected(object sender, SelectionChangedEventArgs e)
        {
            ComboStudent.IsEnabled = true;

            var studentList = StudyBaseEntities.GetContext().Student.ToList();
            studentList = studentList.Where(a => a.GroupCode == (GroupCb.SelectedItem as Group).Code).ToList();
            ComboStudent.ItemsSource = studentList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new GeneralPage());
        }
    }
}
