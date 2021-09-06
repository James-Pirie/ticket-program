using MySql.Data.MySqlClient;
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

namespace internalProgram
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        public MySqlConnection connection;

        public ControlWindow()
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

        public void SubmitTicket(object sender, RoutedEventArgs e)
        {
            string nameString = nameBox.Text;
            string emailString = emailBox.Text;
            string descriptionString = issueBox.Text;
            int ticketID = 1;
            var sendTicket = new MySqlCommand($"INSERT INTO tickets(TicketId, Name, Email, Description) VALUES ('{ticketID}', '{nameString}', '{emailString}', '{descriptionString}');", connection);
            connection.Open();
            sendTicket.ExecuteNonQuery();
            connection.Close();
        }

        public void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Close();
        }

        private void issueBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
