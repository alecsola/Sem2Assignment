using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Factory;
using LogicLayer.Class;
using LogicLayer.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DeckstopApp
{
    public partial class Employee : Form
    {
        
        SeasonTicketsService STS = FactoryService.createseasonTickets();
        StationService SS = FactoryService.createStation();
        TicketService TS = FactoryService.createTicket();
        LogInService LS = FactoryService.createlogInUser();
        
        public int stationId { get; set; }
        public int seasonTicketID { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public Employee(User loggedInUser)
        {
            InitializeComponent();
            PopulateComboboxes();
            lb_welcome.Text = $"Welcome {loggedInUser.FirstName} {loggedInUser.LastName}";

        }
        
       public void RefreshComboboxes()
        {
            PopulateComboboxes();
        }
        public void RefreshStationList()
        {
            LV_Station.Items.Clear();
            FilterStation(TB_station_search.Text);
        }
        public void RefreshSeasonTicketList()
        {
            LV_SeasonTicket.Items.Clear();
            FilterSeasonTicket(TB_SeasonTicket_search.Text);
        }
        public void RefreshTicketList()
        {
            LV_Ticket.Items.Clear();
            Station startingStation = CB_StartingStation.SelectedItem as Station;
            Station destinationStation = CB_DestinationStation.SelectedItem as Station;
            if (!DateSearch.Enabled)
            {
                FilterTicket(startingStation, destinationStation, null);
            }
            else
            {
                FilterTicket(startingStation, destinationStation, (DateSearch.Value).ToString("yyyy-MM-dd"));
            }
          
            

        }
        public void FilterStation(string Name)
        {
            var stationList = SS.GetAllStations();
            var filteredStations = stationList
                .OfType<Station>()
                .Where(a =>
                    (string.IsNullOrEmpty(Name) || a.Name.ToLower().Contains(Name.ToLower())));
            foreach(Station station in filteredStations)
            {
                ListViewItem stationInfo = new ListViewItem(new[] { station.Name, station.Latitude.ToString(), station.Longitude.ToString() });
                stationInfo.Tag = station.Id.ToString();
                LV_Station.Items.Add(stationInfo);
            }
        }
        public void FilterSeasonTicket(string Name)
        {
            var seasonTicketList = STS.GetAllSeasonTickets();
            var filteredSeasonTickets = seasonTicketList
                .OfType<SeasonTickets>()
                .Where(b =>
                    (string.IsNullOrEmpty(Name) || b.SeasonTicketName.ToLower().Contains(Name.ToLower())));
            foreach (SeasonTickets seasonTicket in filteredSeasonTickets)
            {
                ListViewItem seasonTicketInfo = new ListViewItem(new[] { seasonTicket.SeasonTicketName, seasonTicket.Price.ToString(),seasonTicket.Description,seasonTicket.Image });
                seasonTicketInfo.Tag = seasonTicket.Id.ToString();
                LV_SeasonTicket.Items.Add(seasonTicketInfo);
            }
        }

        public void FilterTicket(Station startingStation, Station destinationStation, string? Date)
        {
            
            var ticketList = TS.GetAllTickets();
            var selectedStartingStation = ((Station)CB_StartingStation.SelectedItem).Name;
           
            

            var filteredTickets = ticketList
         .OfType<Ticket>()
         .Where(a =>
             (startingStation == null || startingStation.Name == "All" || a.StartingStation.Name.Equals(startingStation.Name))
             && (destinationStation == null || destinationStation.Name == "All" || a.DestinationStation.Name.Equals(destinationStation.Name))
             && (string.IsNullOrEmpty(Date) || a.DepartureDate == Date));


            foreach (Ticket ticket in filteredTickets)
            {
                ListViewItem ticketInfo = new ListViewItem(new[] { ticket.StartingStation.Name, ticket.DestinationStation.Name, ticket.DepartureDate, ticket.Time });
                ticketInfo.Tag = ticket.Id.ToString();
                LV_Ticket.Items.Add(ticketInfo);
            }
        }
        public void ClearTBStation()
        {
            TB_UpdateStation_Name.Text = null;
            TB_UpdateStation_Latitude.Value = 0;
            TB_UpdateStation_Longitude.Value = 0;
        }
        public void ClearTBSeasonTicket()
        {
            TB_UpdateSeasonTicket_Name.Text = null;
            TB_UpdateSeasonTicket_Price.Value = 0;
            TB_UpdateSeasonTicket_Description.Text = null;
            TB_UpdateSeasonTicket_Image.Text = null;
        }

        public void PopulateComboboxes()
        {
            
            List<Station> stationsSearch = SS.GetAllStations();
            Station None = new Station(-1, "All", 0, 0);
            stationsSearch.Insert(0, None);
            List<Station> stationsSearch2 = new List<Station>(stationsSearch);
           
            

            List<Station> stations = SS.GetAllStations();
            List<Station> stations3 = new List<Station>(stations);
            List<Station> stations4 = new List<Station>(stations);
            List<Station> stations5 = new List<Station>(stations);
            List<Station> stations6 = new List<Station>(stations);
      
            

            
            CB_StartingStation.DataSource = stationsSearch;
            CB_StartingStation.DisplayMember = "Name";
            CB_StartingStation.ValueMember = "Id";


           
            CB_DestinationStation.DataSource = stationsSearch2;
            CB_DestinationStation.DisplayMember = "Name";
            CB_DestinationStation.ValueMember = "Id";


          
            CB_UpdateTicket_Starting.DataSource = stations3;
            CB_UpdateTicket_Starting.DisplayMember = "Name";
            CB_UpdateTicket_Starting.ValueMember = "Id";


            
            CB_UpdateTicket_Ending.DataSource = stations4;
            CB_UpdateTicket_Ending.DisplayMember = "Name";
            CB_UpdateTicket_Ending.ValueMember = "Id";


          
            CB_AddTicket_Starting.DataSource = stations5;
            CB_AddTicket_Starting.DisplayMember = "Name";
            CB_AddTicket_Starting.ValueMember = "Id";


            
            CB_AddTicket_Destination.DataSource = stations6;
            CB_AddTicket_Destination.DisplayMember = "Name";
            CB_AddTicket_Destination.ValueMember = "Id";
            stationsSearch.Clear();
        }

        //WELCOME PAGE
        private void btn_Welcome_StationManagment_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = StationManagment;
        }

        private void btn_Welcome_SeasonTicketManagment_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = SeasonTicketManagment;
        }
        private void btn_TicketManagment_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Ticket;
        }
        private void btn_RegisterEmployee_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Register;
        }




        //STATION MANAGMENT
        private void btn_Station_search_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshStationList();
            }
            catch
            {
                MessageBox.Show("There was a problem");
            }
        }

        private void LV_Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LV_Station.SelectedItems.Count > 0)
                {
                    List<Station> stationList = SS.GetAllStations().OfType<Station>().ToList();

                    Station selectedStation = stationList.Find(station => station.Id == Convert.ToInt32(LV_Station.SelectedItems[0].Tag));

                    //Station
                    stationId = Convert.ToInt32(LV_Station.SelectedItems[0].Tag);
                    TB_UpdateStation_Name.Text = selectedStation.Name;
                    TB_UpdateStation_Latitude.Value = (decimal)selectedStation.Latitude;
                    TB_UpdateStation_Longitude.Value = (decimal)selectedStation.Longitude;
                }
            }
            catch
            {
                MessageBox.Show("There was a problem");
            }
            

        }

        private void btn_UpdateStation_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (LV_Station.SelectedItems.Count > 0)
                {
                    if (TB_UpdateStation_Name.Text.Length > 0 && TB_UpdateStation_Latitude.Value > 0 && TB_UpdateStation_Longitude.Value > 0)
                    {
                        string Name = TB_UpdateStation_Name.Text;
                        decimal Latitude = TB_UpdateStation_Latitude.Value;
                        decimal Longitude = TB_UpdateStation_Longitude.Value;

                        SS.UpdateStation(stationId, Name, Latitude, Longitude);
                        MessageBox.Show("You have updated a Station");
                        RefreshStationList();
                        RefreshComboboxes();
                    }
                    else
                    {
                        MessageBox.Show("You haven't entered the fields correctly");
                    }
                }
                else
                {
                    MessageBox.Show("Nothing was selected");
                }
                    
                    
            }
            catch
            {
                MessageBox.Show("There was an error trying to update the Station");
            }
            
        }

        private void Add_Station_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_AddStation_Name.Text.Length > 0 && TB_AddStation_Latitude.Value > 0 && TB_AddStation_Longitude.Value > 0)
                {
                    Station station = new Station(stationId, TB_AddStation_Name.Text, (double)TB_AddStation_Latitude.Value, (double)TB_AddStation_Longitude.Value);
                    SS.AddStation(station);
                    MessageBox.Show("You have succesfully added a Station");
                    RefreshStationList();
                    RefreshComboboxes();
                }
                else
                {
                    MessageBox.Show("You haven't entered the fields correctly");
                }

            }
            catch
            {
                MessageBox.Show("There was an unexpected error while adding a station");
            }
        }

        private void btn_Remove_Station_Click(object sender, EventArgs e)
        {
            try
            {
                if (LV_Station.SelectedItems.Count > 0)
                {
                    if (TB_UpdateStation_Name.Text.Length > 0 && TB_UpdateStation_Latitude.Value > 0 && TB_UpdateStation_Longitude.Value > 0)
                    {
                        Station station = new Station(stationId, TB_UpdateStation_Name.Text, (double)TB_UpdateStation_Latitude.Value, (double)TB_UpdateStation_Longitude.Value);
                        TS.RemoveTicketByStation(station);
                        SS.RemoveStation(stationId);
                        RefreshStationList();
                        MessageBox.Show("You have removed a Station");
                        ClearTBStation();
                        RefreshComboboxes();
                    }
                    else
                    {
                        MessageBox.Show("You haven't entered the fields correctly");
                    }
                }
                else
                {
                    MessageBox.Show("Nothing was selected");
                }
                   
                
            }
            catch
            {
                MessageBox.Show("You first have to remove the tickets where the station is involved");
            }
            
           
        }




        //SeasonTickets

        private void btn_UpdateSeasonTicket_OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string fileName = open.FileName;
                    string relativePath = "\\" + Path.Combine("Images", "SeasonTickets", Path.GetFileName(fileName));

                    TB_UpdateSeasonTicket_Image.Text = relativePath;

                    // Save relativePath to your database
                }
                else
                {
                    MessageBox.Show("There was a problem");
                }
            }
            catch
            {
                MessageBox.Show("There was an error");
            }
            
        }

        private void btn_SeasonTicket_search_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshSeasonTicketList();
            }
            catch
            {
                MessageBox.Show("There occurred an error");
            }
        }
        
        private void LV_SeasonTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_SeasonTicket.SelectedItems.Count > 0)
            {
                List<SeasonTickets> seasonTicketList = STS.GetAllSeasonTickets().OfType<SeasonTickets>().ToList();

                SeasonTickets selectedSeasonTicket = seasonTicketList.Find(seasonTicket => seasonTicket.Id == Convert.ToInt32(LV_SeasonTicket.SelectedItems[0].Tag));

                //SEASON TICKET
                seasonTicketID = Convert.ToInt32(LV_SeasonTicket.SelectedItems[0].Tag);
                TB_UpdateSeasonTicket_Name.Text = selectedSeasonTicket.SeasonTicketName;
                TB_UpdateSeasonTicket_Price.Value = selectedSeasonTicket.Price;
                TB_UpdateSeasonTicket_Description.Text = selectedSeasonTicket.Description;
                TB_UpdateSeasonTicket_Image.Text= selectedSeasonTicket.Image;
            }
        }

        private void btn_updateSeasonTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (LV_SeasonTicket.SelectedItems.Count > 0)
                {
                    if (TB_UpdateSeasonTicket_Name.Text != null && TB_UpdateSeasonTicket_Price.Value > 0 && TB_UpdateSeasonTicket_Description.Text != null && TB_UpdateSeasonTicket_Image.Text != null)
                    {
                        string Name = TB_UpdateSeasonTicket_Name.Text;
                        decimal Price = TB_UpdateSeasonTicket_Price.Value;
                        string Description = TB_UpdateSeasonTicket_Description.Text;
                        string Image = TB_UpdateSeasonTicket_Image.Text;

                        STS.UpdateSeasonTicket(seasonTicketID, Name, Price, Description, Image);
                        MessageBox.Show("You have updated a Season Ticket");
                        RefreshSeasonTicketList();
                    }
                    else
                    {
                        MessageBox.Show("You haven't put the correct fields");
                    }
                }
                else
                {
                    MessageBox.Show("Nothing was selected");
                }
                   
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
           
            
        }

        private void btn_AddSeasonTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_AddSeasonTicket_Name.Text != null && TB_AddSeasonTicket_Description.Text != null && TB_AddSeasonTicket_Image.Text != null)
                {
                    SeasonTickets seasonTicket = new SeasonTickets(seasonTicketID, TB_AddSeasonTicket_Name.Text, TB_AddSeasonTicket_Price.Value, TB_AddSeasonTicket_Description.Text, TB_AddSeasonTicket_Image.Text);
                    STS.AddSeasonTicket(seasonTicket);
                    MessageBox.Show("You have added a Season Ticket");
                    RefreshSeasonTicketList();
                }
                else
                {
                    MessageBox.Show("You haven't entered the fields correctly");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
           
            
        }

        private void btn_AddSeasonTicket_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = open.FileName;
                string relativePath = "\\" + Path.Combine("Images", "SeasonTickets", Path.GetFileName(fileName));

                TB_AddSeasonTicket_Image.Text = relativePath;

                
            }
        }

        private void btn_RemoveSeasonTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (LV_SeasonTicket.SelectedItems.Count > 0)
                {
                    if (TB_UpdateSeasonTicket_Name.Text != null && TB_UpdateSeasonTicket_Description.Text != null && TB_UpdateSeasonTicket_Image.Text != null)
                    {
                        STS.RemoveSeasonTicket(seasonTicketID);
                        ClearTBSeasonTicket();
                        MessageBox.Show("You have removed a season ticket");
                        RefreshSeasonTicketList();
                    }
                    else
                    {
                        MessageBox.Show("You didn't input the fields correctly");
                    }
                }
                else
                {
                    MessageBox.Show("Nothing was selected");
                }
                    

            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
            
                

        }




        //Tickets
        private void btn_Ticket_search_Click(object sender, EventArgs e)
        {
            RefreshTicketList();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox.Checked == true)
            {
                DateSearch.Enabled = true;
            }
            else
            {
                DateSearch.Enabled = false;
            }
        }

        private void LV_Ticket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Ticket.SelectedItems.Count > 0)
            {
                List<Ticket> ticketList = TS.GetAllTickets().OfType<Ticket>().ToList();

                Ticket selectedTicket = ticketList.Find(ticket => ticket.Id == Convert.ToInt32(LV_Ticket.SelectedItems[0].Tag));

                //SEASON TICKET
                TicketId = Convert.ToInt32(LV_Ticket.SelectedItems[0].Tag);
                CB_UpdateTicket_Starting.Text = selectedTicket.StartingStation.Name;
                CB_UpdateTicket_Ending.Text = selectedTicket.DestinationStation.Name;
                TB_UpdateTicket_Date.Text = selectedTicket.DepartureDate;
                TB_UpdateTicket_Time.Text = selectedTicket.Time;
                
            }
        }

        private void btn_UpdateTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (LV_Ticket.SelectedItems.Count > 0)
                {
                    if (CB_UpdateTicket_Starting.Text != null && CB_UpdateTicket_Ending.Text != null)
                    {
                        if (CB_UpdateTicket_Starting.Text != CB_UpdateTicket_Ending.Text)
                        {
                            Station startingStation = CB_UpdateTicket_Starting.SelectedItem as Station;
                            Station destinationStation = CB_UpdateTicket_Ending.SelectedItem as Station;
                            string DepartureDate = TB_UpdateTicket_Date.Value.ToString("yyyy-MM-dd");
                            string Time = TB_UpdateTicket_Time.Text;
                            TS.UpdateTicket(TicketId, startingStation, destinationStation, DepartureDate, Time);
                            MessageBox.Show("You have succesfully updated a Ticket");
                            RefreshTicketList();
                        }
                        else
                        {
                            MessageBox.Show("You can't have two same stations");
                        }

                    }
                    else
                    {
                        MessageBox.Show("The fields weren't filled correctly");
                    }
                }
                else
                {
                    MessageBox.Show("Nothing was selected");
                }
                    
            }
            catch
            {
                MessageBox.Show("There was an error");
            }
            
            
        }

        private void btn_RemoveTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (LV_Ticket.SelectedItems.Count > 0)
                {
                    TS.RemoveTicket(TicketId);
                    MessageBox.Show("You have removed a ticket");

                    RefreshTicketList();
                }
                else
                {
                    MessageBox.Show("Nothing is selected");
                }
                    
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
            
        }

        private void btn_AddTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (CB_AddTicket_Starting.Text != null && CB_AddTicket_Destination.Text != null)
                {
                    if (CB_AddTicket_Starting.Text != CB_AddTicket_Destination.Text)
                    {
                        Station startingStation = CB_AddTicket_Starting.SelectedItem as Station;
                        Station destinationStation = CB_AddTicket_Destination.SelectedItem as Station;
                        
                        Ticket ticket = new Ticket(TicketId, startingStation, destinationStation, TB_AddTicket_Date.Value.ToString("yyyy-MM-dd"), TB_AddTicket_Time.Text);
                        TS.AddTicket(ticket);
                        MessageBox.Show("You have added a ticket");
                        RefreshTicketList();
                    }
                    else
                    {
                        MessageBox.Show("You can't have two same stations");
                    }
                }
                else
                {
                    MessageBox.Show("The fields are not correct");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
            
        }


        //LOGOUT

        private void btn_logout1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btn_logout2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btn_logout3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void bt_logout4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void btn_logout5__Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

       


        //REGISTER
        private void btn_Register_Click(object sender, EventArgs e)
        {
            if(TB_Register_Password.Text.Length > 6)
            {
                bool registrationSuccessful = LS.RegisterUser(UserId, TB_Register_FirstName.Text, TB_Register_LastName.Text, TB_Register_Username.Text, TB_Register_Password.Text, TB_Register_Email.Text, TB_Register_PhoneNumber.Text, TB_Register_BirthDate.Value.ToString("yyyy-MM-dd"), TB_Register_Adress.Text, "1");
                if (registrationSuccessful)
                {
                    // Redirect to the login page if registration was successful

                    MessageBox.Show("You have added an Employee");

                }
                else
                {
                    MessageBox.Show("Employee couldn't be added");
                }
            }
            else
            {
                MessageBox.Show("Password must have 6 characters");
            }
            
        }

        
    }
}
