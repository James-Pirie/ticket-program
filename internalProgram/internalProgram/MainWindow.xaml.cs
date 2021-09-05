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

            var cmd = new MySqlCommand($"SELECT UserName FROM login WHERE UserName = @username AND Password = @password;", connection);
            // use parameters to proctect against SQL injection
            cmd.Parameters.AddWithValue("@username", usernameBox.Text);
            cmd.Parameters.AddWithValue("@password", passwordBox.Password);
            connection.Open();
            string user = (string)cmd.ExecuteScalar();
            connection.Close();

            if (String.IsNullOrEmpty(user))
            {
                MessageBox.Show("Wrong username/password");
            }
            else
            {
                ControlWindow ControlWindow = new ControlWindow();
                ControlWindow.Show();
                Close();
            }

        }
    }
}
