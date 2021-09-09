using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace internalProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name = "asdf";
        MySqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = string.Format(
            "Server=nimbus.rangitoto.school.nz;" +
            "Port=3307;" +
            "database=student2021131404;" +
            "UID=2021131404;" +
            "password=131404;" +
            "sslmode=none;");
            connection = new MySqlConnection(connectionString);

        }
            
        public void ButtonLoginClick(object sender, RoutedEventArgs e)
        {
            var checkUsernameCommand = new MySqlCommand($"SELECT UserName FROM login WHERE UserName = @username AND Password = @password;", connection);
            // use parameters to proctect against SQL injection
            checkUsernameCommand.Parameters.AddWithValue("@username", usernameBox.Text);
            checkUsernameCommand.Parameters.AddWithValue("@password", passwordBox.Password);
            connection.Open();
            string user = (string)checkUsernameCommand.ExecuteScalar();

            if (String.IsNullOrEmpty(user))
            {
                MessageBox.Show("Wrong username/password");
                connection.Close();
            }
            else
            {
                var checkRoleCommand = new MySqlCommand($"SELECT Role FROM login WHERE UserName = '{usernameBox.Text}' AND Password = '{passwordBox.Password}';", connection);
                var userRole = checkRoleCommand.ExecuteScalar();
                string userRoleString = userRole.ToString();

                if (userRoleString == "Admin") 
                {
                    AdminWindow AdminWindow = new AdminWindow();
                    AdminWindow.Show();
                }
                

                else if (userRoleString == "Standard")
                {
                    ControlWindow ControlWindow = new ControlWindow();
                    ControlWindow.Show();
                }
                connection.Close();
                Close();
            }
        }
    }
}

