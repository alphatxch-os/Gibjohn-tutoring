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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
namespace Gibjohn_tutoring
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        string connStr = "server=ND-COMPSCI;" +
                 "username=TL_S2201761;" +
                 "database=TL_S2201761_gj;" +
                 "port=3306;" +
                 "password=Notre021205";
        public Register()
        {
            InitializeComponent();
        }

        private void registerbutton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = passwordBox.Password;
            string email = EmailBox.Text;
            string name = NameBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email)) 
            {
                MessageBox.Show("Please make sure you put all your details in.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "INSERT INTO login (Username, Password, Email, Name) VALUES (@Username, @Password, @Email, @Name )";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue ("@Password", password);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Added to the system.");
                        UsernameBox.Text = string.Empty;
                        EmailBox.Text= string.Empty;
                        NameBox.Text = string.Empty;
                        passwordBox.Password = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Failed");
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

