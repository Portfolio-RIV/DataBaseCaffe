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

namespace DataBase.pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            int pass = psbPassword.Password.GetHashCode();
            User UserObject = BaseConnect.BaseModel.User.FirstOrDefault(u => u.Login == txbLogin.Text && u.Password == pass);
            if (UserObject == null)
            {
                MessageBox.Show("Такого пользователя нет");
            }
            else
            {
                switch (UserObject.Key_Role)
                {
                    case 1:
                        MessageBox.Show("Вы вошли как администратор");
                        FrameLoad.FrameMain.Navigate(new PageAdminMenu());
                        break;
                    default:
                        MessageBox.Show("Системная ошибка");
                        break;
                }
            }
            
        }
    }
}
