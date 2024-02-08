using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Gibjohn_tutoring
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        string connStr = "server=ND-COMPSCI;" +
                     "username=TL_S2201761;" +
                     "database=TL_S2201761_gj;" +
                     "port=3306;" +
                     "password=Notre021205";

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string NewPassword = NewPasswordBox.Text;
            string username = UsernameChangeBox.Text;
            string OldPassword = PasswordChangeBox.Text;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "UPDATE login SET Password = @NewPassword WHERE Username = @Username and Password=@OldPassword ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@NewPassword", NewPassword);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@OldPassword", OldPassword);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated");
                    }
                    else
                    {
                        MessageBox.Show("failed to update password.");
                    }
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
