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
using System.Data.SqlClient;

namespace Studsharp
{
    /// <summary>
    /// Логика взаимодействия для GeneralStudentPage.xaml
    /// </summary>
    public partial class GeneralStudentPage : Page
    {
        private Student _currentStudent = new Student();
        public GeneralStudentPage(Student sessionStudent, string fullName)
        {
            InitializeComponent();
            _currentStudent = sessionStudent;

            var allDiscipline = StudyBaseEntities.GetContext().Discipline.ToList();
            allDiscipline.Insert(0, new Discipline{ Name = "Все предметы" });
            
            DisciplineCb.ItemsSource = allDiscipline;
            DisciplineCb.SelectedIndex = 0;
            FLNameTb.Text = fullName;

            UpdateJournal();
        }
        private void UpdateJournal()
        {
            var CurrentJournal = StudyBaseEntities.GetContext().Evaluation.ToList();
            CurrentJournal = CurrentJournal.Where(p => p.StudentID == _currentStudent.ID).ToList();
            if (DisciplineCb.SelectedIndex > 0) {
                Debug.WriteLine("--------");
                
                var selectedItem = DisciplineCb.SelectedItem as Discipline;
                Debug.WriteLine(selectedItem);
                Debug.WriteLine(selectedItem.ID);
                Debug.WriteLine(selectedItem.ID == 3);

                Debug.WriteLine("--------");
                
                CurrentJournal = CurrentJournal.Where(p => p.Teacher_Discipline.DisciplineID == (DisciplineCb.SelectedItem as Discipline).ID).ToList();
            }
            Debug.WriteLine(_currentStudent.ToString());
            Debug.WriteLine(_currentStudent.ID.ToString());
            JournalLv.ItemsSource = CurrentJournal;
        }
        private void DisciplineCbSelected(object sender, SelectionChangedEventArgs e)
        {
            UpdateJournal();
        }
    }
}
