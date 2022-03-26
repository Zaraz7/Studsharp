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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void EnterClk(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordTb.Password))
            {
                MessageBox.Show("Сначало введите пароль!");
                return;
            }
            using (var db = new StudyBaseEntities())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == LoginTb.Text && u.Password == PasswordTb.Password);
                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    return;
                }
                var teacher = db.Teacher.AsNoTracking().FirstOrDefault(t => t.UserID == user.ID);
                if (teacher != null)
                {
                    MessageBox.Show("Вы успешно авторизировались, учитель.");
                    Manager.MainFrame.Navigate(new GeneralPage());
                    return;
                }
                var student = db.Student.AsNoTracking().FirstOrDefault(t => t.UserID == user.ID);
                if (student != null)
                {
                    string fullName = student.FirstName + " " + student.LastName;
                    MessageBox.Show($"Вы успешно авторизировались, {fullName}.");
                    Manager.MainFrame.Navigate(new GeneralStudentPage(student, fullName));
                }
                else
                {
                    MessageBox.Show("Ваш аккаунт не явлется подтвержденным.");
                }
                return;
            } 
        }
    }
}
