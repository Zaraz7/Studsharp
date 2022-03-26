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
        static String GroupCode;
        public GeneralPage()
        {
            InitializeComponent();
            GroupCb.ItemsSource = StudyBaseEntities.GetContext().Group.ToList();
            DisciplineCb.ItemsSource = StudyBaseEntities.GetContext().Discipline.ToList();

            JournalDg.ItemsSource = StudyBaseEntities.GetContext().Evaluation.ToList();

            
        }
        private void UpdateJournal() {
            var currentJournal = StudyBaseEntities.GetContext().Evaluation.ToList();

           // if (.SelectedIndex > 0)
        }

        private void GroupCbSelected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DisciplineCbSelected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
