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
        public int stationId { get; set; }
        public int seasonTicketID { get; set; }
        public Employee()
        {
            InitializeComponent();
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
    }
}
