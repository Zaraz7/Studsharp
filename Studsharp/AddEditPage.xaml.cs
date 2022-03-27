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
using System.Diagnostics;

namespace Studsharp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Teacher sessionTeacher = new Teacher();
        public AddEditPage(Teacher _sessionTeacher)
        {
            sessionTeacher = _sessionTeacher;

            InitializeComponent();
            var disciplineList = StudyBaseEntities.GetContext().Teacher_Discipline.ToList();
            disciplineList = disciplineList.Where(a => a.TeacherID == sessionTeacher.ID).ToList();

            ComboDiscipline.ItemsSource = disciplineList;
            GroupCb.ItemsSource = StudyBaseEntities.GetContext().Group.ToList();
        }


        private void GroupCbSelected(object sender, SelectionChangedEventArgs e)
        {
            ComboStudent.IsEnabled = true;

            var studentList = StudyBaseEntities.GetContext().Student.ToList();
            studentList = studentList.Where(a => a.GroupCode == (GroupCb.SelectedItem as Group).Code).ToList();
            ComboStudent.ItemsSource = studentList;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine((ComboStudent.SelectedItem as Student).ID);
            Debug.WriteLine((ComboDiscipline.SelectedItem as Teacher_Discipline).ID);
            Debug.WriteLine(EvalTb.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new GeneralPage(sessionTeacher));
        }
    }
}
