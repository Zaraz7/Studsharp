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
        private Evaluation evaluation = new Evaluation();
        public AddEditPage(Teacher _sessionTeacher, Evaluation _evaluation)
        {
            sessionTeacher = _sessionTeacher;
            if (_evaluation != null)
                evaluation = _evaluation;

            InitializeComponent();
            var disciplineList = StudyBaseEntities.GetContext().Teacher_Discipline.ToList();
            disciplineList = disciplineList.Where(a => a.TeacherID == sessionTeacher.ID).ToList();

            ComboDiscipline.ItemsSource = disciplineList;
            GroupCb.ItemsSource = StudyBaseEntities.GetContext().Group.ToList();

            ReturnDp.SelectedDate = DateTime.Now;
            
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
            StringBuilder errors = new StringBuilder();

            byte eval = 0;
            try
            {
                eval = Convert.ToByte(EvalTb.Text);
                if (eval < 2 || eval > 5)
                    errors.AppendLine("Оценка должна быть в пределах от 2 до 5");
            }
            catch
            {
                errors.AppendLine("Оценка должна быть целым числом");
            }
            var discipline = ComboDiscipline.SelectedItem as Teacher_Discipline;
            if (discipline == null)
                errors.AppendLine("Необходимо выбрать предмет");
            var student = ComboStudent.SelectedItem as Student;
            if (student == null)
                errors.AppendLine("Необходимо выбрать студента");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            evaluation.DateReturn = ReturnDp.SelectedDate;
            evaluation.Eval = eval;
            evaluation.StudentID = student.ID;
            evaluation.TDID = discipline.ID;
            if (evaluation.ID == 0)
            {
                Debug.WriteLine("Adding.");
                StudyBaseEntities.GetContext().Evaluation.Add(evaluation);
            } else
            {
                Debug.WriteLine("Editting");

            }
            try
            {
                StudyBaseEntities.GetContext().SaveChanges();
                Debug.WriteLine("Secsess");
                MessageBox.Show("Оценка выставлена.");
                Manager.MainFrame.Navigate(new GeneralPage(sessionTeacher));
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtnAbort_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new GeneralPage(sessionTeacher));
        }
    }
}
