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
    /// Логика взаимодействия для GeneralPage.xaml
    /// </summary>
    public partial class GeneralPage : Page
    {
        public GeneralPage()
        {
            InitializeComponent();
            JournalDg.ItemsSource = StudyBaseEntities.GetContext().Evaluation.ToList();

            var allDiscipline = StudyBaseEntities.GetContext().Discipline.ToList();
            allDiscipline.Insert(0, new Discipline { Name = "Все предметы" });

            DisciplineCb.ItemsSource = allDiscipline;
            DisciplineCb.SelectedIndex = 0;

            var allGroups = StudyBaseEntities.GetContext().Group.ToList();
            allGroups.Insert(0, new Group { Code = "Все группы" });

            GroupCb.ItemsSource = allGroups;
            GroupCb.SelectedIndex = 0;

            UpdateJournal();
        }

        private void UpdateJournal()
        {
            var CurrentJournal = StudyBaseEntities.GetContext().Evaluation.ToList();

            if (DisciplineCb.SelectedIndex > 0)
            {
                CurrentJournal = CurrentJournal.Where(p => p.Teacher_Discipline.DisciplineID == (DisciplineCb.SelectedItem as Discipline).ID).ToList();
            }
            if (GroupCb.SelectedIndex > 0)
            {
                CurrentJournal = CurrentJournal.Where(p => p.Student.GroupCode == (GroupCb.SelectedItem as Group).Code).ToList();
            }
            JournalDg.ItemsSource = CurrentJournal;
        }

        private void GroupCbSelected(object sender, SelectionChangedEventArgs e)
        {
            UpdateJournal();
        }

        private void DisciplineCbSelected(object sender, SelectionChangedEventArgs e)
        {
            UpdateJournal();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }
    }
}
