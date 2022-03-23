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
    /// Логика взаимодействия для GeneralStudentPage.xaml
    /// </summary>
    public partial class GeneralStudentPage : Page
    {
        public GeneralStudentPage()
        {
            InitializeComponent();
            DisciplineCb.ItemsSource = StudyBaseEntities.GetContext().Discipline.ToList();
            DisciplineCb.SelectedIndex = 0;

            UpdateJournal();
        }
        private void UpdateJournal()
        {
            var CurrentJournal = StudyBaseEntities.GetContext().Evaluation.ToList();
            /*
            if (DisciplineCb.SelectedIndex > 0)
                CurrentJournal = CurrentJournal.Where(p => p.Teacher_Discipline.DisciplineID(DisciplineCb.SelectedItem as Discipline)).toList;
            */
            JournalLv.ItemsSource = CurrentJournal;
        }
        private void DisciplineCbSelected(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
