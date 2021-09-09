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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MySqlConnection connection;
        public AdminWindow()
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
            GenerateDataGrid();
            GenerateAdminList();

        }

        public void GenerateAdminList()
        {
            List<string> adminList = new List<string>();
            List<string> sortByAdminList = new List<string>();
            bool moreAdmins = true;
            int currentAdminId = 1;
            connection.Open();
            while (moreAdmins)
            {
                var checkRoleCommand = new MySqlCommand($"SELECT Role FROM login WHERE UserId = '{currentAdminId}';", connection);
                var adminId = checkRoleCommand.ExecuteScalar();
                if (adminId == null)
                {
                    moreAdmins = false;
                }
                else
                {
                    
                    string adminIdString = adminId.ToString();
                    if (adminIdString == "Admin")
                    {
                        var selectAdminName = new MySqlCommand($"SELECT UserName FROM login WHERE UserId = '{currentAdminId}' AND Role = 'Admin';", connection);
                        var getAdminName = selectAdminName.ExecuteScalar();
                        string adminNameString = getAdminName.ToString();
                        adminList.Add(adminNameString);

                    }
                    currentAdminId += 1;
                }
            }
            connection.Close();
            setAdminBox.ItemsSource = adminList;
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Close();
        }

        public void SelectRow(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Ticket selectedTicket = row.Item as Ticket;
            nameDisplaySelected.Text = selectedTicket.ticketName;
            emailDisplaySelected.Text = selectedTicket.ticketEmail;
            idDisplaySelected.Text = selectedTicket.ticketId;
            descriptionDisplaySelected.Text = selectedTicket.description;
            catagoryDisplaySelected.Text = selectedTicket.catagory;
            statusDisplaySelected.Text = selectedTicket.status;
            adminDisplaySelected.Text = selectedTicket.assignedTo;
            infoStorage.Text = selectedTicket.info;
           
            
            
        }


        public void SetAdmin(object sender, RoutedEventArgs e)
        {
            string nameString = nameDisplaySelected.Text;
            string emailString = emailDisplaySelected.Text;
            string ticketIdString = idDisplaySelected.Text;
            string descriptionString = descriptionDisplaySelected.Text;
            string catagoryString = catagoryDisplaySelected.Text;
            string statusString = statusDisplaySelected.Text;
            string adminString = setAdminBox.Text;
            string[] infoSplit = infoStorage.Text.Split(':');
            string realName = infoSplit[0];
            string job = infoSplit[1];

            int ticketIdNumerical = 0;
            bool idIsNumeric = int.TryParse(ticketIdString, out ticketIdNumerical);
            if (idIsNumeric)
            {
                connection.Open();
                var deleteCommand = new MySqlCommand($"DELETE FROM tickets WHERE TicketId = '{ticketIdNumerical}'", connection);
                deleteCommand.ExecuteNonQuery();
                string queryString = $"INSERT INTO tickets(RealName, Job, TicketId, Name, Email, Description, Status, Catagory, AssignedTo) VALUES ('{realName}', '{job}', '{ticketIdString}', '{nameString}', '{emailString}', '{descriptionString}', '{statusString}', '{catagoryString}', '{adminString}');";
                var sendTicket = new MySqlCommand(queryString, connection);
                sendTicket.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show($"Ticket Assigned to {adminString}");
                connection.Close();
            }
            AdminWindow AdminWindow = new AdminWindow();
            AdminWindow.Show();
            Close();

        }

        public void SetStatus(object sender, RoutedEventArgs e)
        {
            string nameString = nameDisplaySelected.Text;
            string emailString = emailDisplaySelected.Text;
            string ticketIdString = idDisplaySelected.Text;
            string descriptionString = descriptionDisplaySelected.Text;
            string catagoryString = catagoryDisplaySelected.Text;
            string statusString = setStatusBox.Text;
            string adminString = adminDisplaySelected.Text;
            string[] infoSplit = infoStorage.Text.Split(':');
            string realName = infoSplit[0];
            string job = infoSplit[1];

            int ticketIdNumerical = 0;
            bool idIsNumeric = int.TryParse(ticketIdString, out ticketIdNumerical);
            if (idIsNumeric)
            {
                connection.Open();
                var deleteCommand = new MySqlCommand($"DELETE FROM tickets WHERE TicketId = '{ticketIdNumerical}'", connection);
                deleteCommand.ExecuteNonQuery();
                string queryString = $"INSERT INTO tickets(RealName, Job, TicketId, Name, Email, Description, Status, Catagory, AssignedTo) VALUES ('{realName}', '{job}', '{ticketIdString}', '{nameString}', '{emailString}', '{descriptionString}', '{statusString}', '{catagoryString}', '{adminString}');";
                var sendTicket = new MySqlCommand(queryString, connection);
                sendTicket.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Status Succesfuly Modified");
                connection.Close();
            }
            AdminWindow AdminWindow = new AdminWindow();
            AdminWindow.Show();
            Close();

        }

        public void SetCatagory(object sender, RoutedEventArgs e)
        {
            string nameString = nameDisplaySelected.Text;
            string emailString = emailDisplaySelected.Text;
            string ticketIdString = idDisplaySelected.Text;
            string descriptionString = descriptionDisplaySelected.Text;
            string catagoryString = setCatagoryBox.Text;
            string statusString = statusDisplaySelected.Text;
            string adminString = adminDisplaySelected.Text;
            string[] infoSplit = infoStorage.Text.Split(':');
            string realName = infoSplit[0];
            string job = infoSplit[1];

            int ticketIdNumerical = 0;
            bool idIsNumeric = int.TryParse(ticketIdString, out ticketIdNumerical);
            if (idIsNumeric)
            {
                connection.Open();
                var deleteCommand = new MySqlCommand($"DELETE FROM tickets WHERE TicketId = '{ticketIdNumerical}'", connection);
                deleteCommand.ExecuteNonQuery();
                string queryString = $"INSERT INTO tickets(RealName, Job, TicketId, Name, Email, Description, Status, Catagory, AssignedTo) VALUES ('{realName}', '{job}', '{ticketIdString}', '{nameString}', '{emailString}', '{descriptionString}', '{statusString}', '{catagoryString}', '{adminString}');";
                var sendTicket = new MySqlCommand(queryString, connection);
                sendTicket.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Catagory Succesfuly Modified");
                connection.Close();
            }
            AdminWindow AdminWindow = new AdminWindow();
            AdminWindow.Show();
            Close();

        }

        public void GenerateDataGrid()
        {
            
            connection.Open();
            bool moreTicets = true;
            int currentTicketId = 1;
            int sumOfTickets = 1;

            while (moreTicets)
            {
                var checkRoleCommand = new MySqlCommand($"SELECT TicketId FROM tickets WHERE TicketId = {currentTicketId};", connection);
                var allTicketIds = checkRoleCommand.ExecuteScalar();
                if (allTicketIds == null)
                {
                    moreTicets = false;
                }
                else
                {
                    currentTicketId += 1;
                    sumOfTickets += 1;
                }
            }

            for(int i = 1; i < sumOfTickets; i++)
            {
                Ticket newTicket = new Ticket();
                var getName = new MySqlCommand($"SELECT Name FROM tickets WHERE TicketId = {i};", connection);
                var ticketNameScalar = getName.ExecuteScalar();
                string ticketNameString = ticketNameScalar.ToString();
                var getEmail = new MySqlCommand($"SELECT Email FROM tickets WHERE TicketId = {i};", connection);
                var ticketEmailScalar = getEmail.ExecuteScalar();
                string ticketEmailString = ticketEmailScalar.ToString();
                var getDescription = new MySqlCommand($"SELECT Description FROM tickets WHERE TicketId = {i};", connection);
                var ticketDescriptionScalar = getDescription.ExecuteScalar();
                string ticketDescriptionString = ticketDescriptionScalar.ToString();
                var getAssignedTo = new MySqlCommand($"SELECT AssignedTo FROM tickets WHERE TicketId = {i};", connection);
                var ticketAssignedScalar = getAssignedTo.ExecuteScalar();
                string ticketAssignedString = ticketAssignedScalar.ToString();
                var getStatus = new MySqlCommand($"SELECT Status FROM tickets WHERE TicketId = {i};", connection);
                var ticketStatusScalar = getStatus.ExecuteScalar();
                string ticketStatusString = ticketStatusScalar.ToString();
                var getCatagory = new MySqlCommand($"SELECT Catagory FROM tickets WHERE TicketId = {i};", connection);
                var ticketCatagoryScalar = getCatagory.ExecuteScalar();
                string ticketCatagoryString = ticketCatagoryScalar.ToString();
                var getRealName = new MySqlCommand($"SELECT RealName FROM tickets WHERE TicketId = {i};", connection);
                var ticketRealNameScalar = getRealName.ExecuteScalar();
                string ticketRealNameString = ticketRealNameScalar.ToString();
                var getJob = new MySqlCommand($"SELECT Job FROM tickets WHERE TicketId = {i};", connection);
                var ticketJobScalar = getJob.ExecuteScalar();
                string ticketJobString = ticketJobScalar.ToString();

                newTicket.ticketName = ticketNameString;
                newTicket.ticketEmail = ticketEmailString;
                newTicket.description = ticketDescriptionString;
                newTicket.assignedTo = ticketAssignedString;
                newTicket.status = ticketStatusString;
                newTicket.catagory = ticketCatagoryString;
                newTicket.ticketId = $"{i}";
                newTicket.info = $"{ticketRealNameScalar}:{ticketJobString}";
                ticketDisplay.Items.Add(newTicket);

            }
            connection.Close();
        }

        private void ticketDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Ticket
    {
        public string ticketId { get; set; }
        public string ticketName { get; set; }
        public string description { get; set; }
        public string ticketEmail { get; set; }
        public string assignedTo { get; set; }
        public string status { get; set; }
        public string catagory { get; set; }
        public string info { get; set; }
    }
}
