using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Factory;
using LogicLayer.Class;
using LogicLayer.Services;

namespace DeckstopApp
{
    public partial class Employee : Form
    {
        
        SeasonTicketsService STS = FactoryService.createseasonTickets();
        StationService SS = FactoryService.createStation();
        TicketService TS = FactoryService.createTicket();
        public int stationId { get; set; }
        public int seasonTicketID { get; set; }
        public int TicketId { get; set; }
        public Employee()
        {
            InitializeComponent();
            PopulateComboboxes();
            
        }
        public void Checkbox()
        {

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

            FilterTicket(startingStation, destinationStation, null); // or
            FilterTicket(startingStation, destinationStation, (DateSearch.Value).ToString("yyyy-MM-dd"));

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
            stationsSearch2.Insert(0, None);
            

            List<Station> stations = SS.GetAllStations();
            List<Station> stations3 = new List<Station>(stations);
            List<Station> stations4 = new List<Station>(stations);
            List<Station> stations5 = new List<Station>(stations);
            List<Station> stations6 = new List<Station>(stations);
      
            

            CB_StartingStation.Items.Clear();
            CB_StartingStation.DataSource = null;
            CB_StartingStation.DataSource = stationsSearch;
            CB_StartingStation.DisplayMember = "Name";
            CB_StartingStation.ValueMember = "Id";


            CB_DestinationStation.Items.Clear();
            CB_DestinationStation.DataSource = null;
            CB_DestinationStation.DataSource = stationsSearch2;
            CB_DestinationStation.DisplayMember = "Name";
            CB_DestinationStation.ValueMember = "Id";


            CB_UpdateTicket_Starting.Items.Clear();
            CB_UpdateTicket_Starting.DataSource = null;
            CB_UpdateTicket_Starting.DataSource = stations3;
            CB_UpdateTicket_Starting.DisplayMember = "Name";
            CB_UpdateTicket_Starting.ValueMember = "Id";


            CB_UpdateTicket_Ending.Items.Clear();
            CB_UpdateTicket_Ending.DataSource = null;
            CB_UpdateTicket_Ending.DataSource = stations4;
            CB_UpdateTicket_Ending.DisplayMember = "Name";
            CB_UpdateTicket_Ending.ValueMember = "Id";


            CB_AddTicket_Starting.Items.Clear();
            CB_AddTicket_Starting.DataSource = null;
            CB_AddTicket_Starting.DataSource = stations5;
            CB_AddTicket_Starting.DisplayMember = "Name";
            CB_AddTicket_Starting.ValueMember = "Id";


            CB_AddTicket_Destination.Items.Clear();
            CB_AddTicket_Destination.DataSource = null;
            CB_AddTicket_Destination.DataSource = stations6;
            CB_AddTicket_Destination.DisplayMember = "Name";
            CB_AddTicket_Destination.ValueMember = "Id";
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

        private void btn_UpdateStation_update_Click(object sender, EventArgs e)
        {
            string Name = TB_UpdateStation_Name.Text;
            decimal Latitude = TB_UpdateStation_Latitude.Value;
            decimal Longitude = TB_UpdateStation_Longitude.Value;

            SS.UpdateStation(stationId,Name, Latitude, Longitude);
            RefreshStationList();
        }

        private void Add_Station_Click(object sender, EventArgs e)
        {
            Station station = new Station(stationId, TB_AddStation_Name.Text, (double)TB_AddStation_Latitude.Value, (double)TB_AddStation_Longitude.Value);
            SS.AddStation(station);
            RefreshStationList();
        }

        private void btn_Remove_Station_Click(object sender, EventArgs e)
        {
            
            SS.RemoveStation(stationId);
            RefreshStationList();
            ClearTBStation();
        }


        //SeasonTickets

        private void btn_UpdateSeasonTicket_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = open.FileName;
                string relativePath = "\\" + Path.Combine("Images", "SeasonTickets", Path.GetFileName(fileName));

                TB_UpdateSeasonTicket_Image.Text = relativePath;

                // Save relativePath to your database
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
            string Name = TB_UpdateSeasonTicket_Name.Text;
            decimal Price = TB_UpdateSeasonTicket_Price.Value;
            string Description = TB_UpdateSeasonTicket_Description.Text;
            string Image = TB_UpdateSeasonTicket_Image.Text;

            STS.UpdateSeasonTicket(seasonTicketID,Name,Price,Description,Image);
            RefreshSeasonTicketList();
        }

        private void btn_AddSeasonTicket_Click(object sender, EventArgs e)
        {
            SeasonTickets seasonTicket = new SeasonTickets(seasonTicketID, TB_AddSeasonTicket_Name.Text, TB_AddSeasonTicket_Price.Value, TB_AddSeasonTicket_Description.Text, TB_AddSeasonTicket_Image.Text);
            STS.AddSeasonTicket(seasonTicket);
            RefreshSeasonTicketList();
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
            STS.RemoveSeasonTicket(seasonTicketID);
            ClearTBSeasonTicket();
            RefreshSeasonTicketList();

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
            Station startingStation = CB_UpdateTicket_Starting.SelectedItem as Station;
            Station destinationStation = CB_UpdateTicket_Ending.SelectedItem as Station;
            string DepartureDate = TB_UpdateTicket_Date.Text;
            string Time = TB_UpdateTicket_Time.Text;
            TS.UpdateTicket(TicketId, startingStation, destinationStation, DepartureDate, Time);
            RefreshTicketList();
        }

        private void btn_RemoveTicket_Click(object sender, EventArgs e)
        {
            TS.RemoveTicket(TicketId);
            RefreshTicketList();
        }

        private void btn_AddTicket_Click(object sender, EventArgs e)
        {
            Station startingStation = CB_AddTicket_Starting.SelectedItem as Station;
            Station destinationStation = CB_AddTicket_Destination.SelectedItem as Station;
            Ticket ticket = new Ticket(TicketId, startingStation, destinationStation, TB_AddTicket_Date.Text, TB_AddTicket_Time.Text);
            TS.AddTicket(ticket);
            RefreshTicketList();
        }
    }
}
