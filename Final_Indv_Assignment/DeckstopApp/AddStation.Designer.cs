namespace DeckstopApp
{
    partial class Employee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MainMenu = new System.Windows.Forms.TabPage();
            this.btn_Welcome_AddSeasonTicket = new System.Windows.Forms.Button();
            this.btn_Welcome_AddStation = new System.Windows.Forms.Button();
            this.lb_welcome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddStation = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_AddStation_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_AddStation_Latitude = new System.Windows.Forms.NumericUpDown();
            this.TB_AddStation_Longitude = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Add_Station = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AddSeasonTicket = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LV_Station = new System.Windows.Forms.ListView();
            this.label12 = new System.Windows.Forms.Label();
            this.TB_station_search = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_UpdateStation_update = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_UpdateStation_Longitude = new System.Windows.Forms.NumericUpDown();
            this.TB_UpdateStation_Name = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TB_UpdateStation_Latitude = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_Station_search = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.AddStation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_AddStation_Latitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_AddStation_Longitude)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.AddSeasonTicket.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_UpdateStation_Longitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_UpdateStation_Latitude)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MainMenu);
            this.tabControl1.Controls.Add(this.AddStation);
            this.tabControl1.Controls.Add(this.AddSeasonTicket);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1780, 845);
            this.tabControl1.TabIndex = 0;
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.AntiqueWhite;
            this.MainMenu.Controls.Add(this.btn_Welcome_AddSeasonTicket);
            this.MainMenu.Controls.Add(this.btn_Welcome_AddStation);
            this.MainMenu.Controls.Add(this.lb_welcome);
            this.MainMenu.Controls.Add(this.label2);
            this.MainMenu.Controls.Add(this.label1);
            this.MainMenu.Location = new System.Drawing.Point(4, 29);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(3);
            this.MainMenu.Size = new System.Drawing.Size(1772, 812);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Main Menu";
            // 
            // btn_Welcome_AddSeasonTicket
            // 
            this.btn_Welcome_AddSeasonTicket.BackColor = System.Drawing.Color.Red;
            this.btn_Welcome_AddSeasonTicket.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Welcome_AddSeasonTicket.ForeColor = System.Drawing.Color.White;
            this.btn_Welcome_AddSeasonTicket.Location = new System.Drawing.Point(827, 452);
            this.btn_Welcome_AddSeasonTicket.Name = "btn_Welcome_AddSeasonTicket";
            this.btn_Welcome_AddSeasonTicket.Size = new System.Drawing.Size(399, 75);
            this.btn_Welcome_AddSeasonTicket.TabIndex = 6;
            this.btn_Welcome_AddSeasonTicket.Text = "Add Season Ticket";
            this.btn_Welcome_AddSeasonTicket.UseVisualStyleBackColor = false;
            // 
            // btn_Welcome_AddStation
            // 
            this.btn_Welcome_AddStation.BackColor = System.Drawing.Color.Red;
            this.btn_Welcome_AddStation.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Welcome_AddStation.ForeColor = System.Drawing.Color.White;
            this.btn_Welcome_AddStation.Location = new System.Drawing.Point(827, 339);
            this.btn_Welcome_AddStation.Name = "btn_Welcome_AddStation";
            this.btn_Welcome_AddStation.Size = new System.Drawing.Size(399, 75);
            this.btn_Welcome_AddStation.TabIndex = 5;
            this.btn_Welcome_AddStation.Text = "Add Station";
            this.btn_Welcome_AddStation.UseVisualStyleBackColor = false;
            // 
            // lb_welcome
            // 
            this.lb_welcome.AutoSize = true;
            this.lb_welcome.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_welcome.Location = new System.Drawing.Point(772, 175);
            this.lb_welcome.Name = "lb_welcome";
            this.lb_welcome.Size = new System.Drawing.Size(295, 81);
            this.lb_welcome.TabIndex = 4;
            this.lb_welcome.Text = "Welcome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(98, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 57);
            this.label2.TabIndex = 3;
            this.label2.Text = "Express";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 57);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ease";
            // 
            // AddStation
            // 
            this.AddStation.BackColor = System.Drawing.Color.AntiqueWhite;
            this.AddStation.Controls.Add(this.label17);
            this.AddStation.Controls.Add(this.btn_Station_search);
            this.AddStation.Controls.Add(this.label16);
            this.AddStation.Controls.Add(this.groupBox2);
            this.AddStation.Controls.Add(this.TB_station_search);
            this.AddStation.Controls.Add(this.label12);
            this.AddStation.Controls.Add(this.LV_Station);
            this.AddStation.Controls.Add(this.label7);
            this.AddStation.Controls.Add(this.label8);
            this.AddStation.Controls.Add(this.pictureBox1);
            this.AddStation.Controls.Add(this.groupBox1);
            this.AddStation.Controls.Add(this.label3);
            this.AddStation.Location = new System.Drawing.Point(4, 29);
            this.AddStation.Name = "AddStation";
            this.AddStation.Padding = new System.Windows.Forms.Padding(3);
            this.AddStation.Size = new System.Drawing.Size(1772, 812);
            this.AddStation.TabIndex = 1;
            this.AddStation.Text = "Add Station";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(24, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1373, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = "Add a Station";
            // 
            // TB_AddStation_Name
            // 
            this.TB_AddStation_Name.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TB_AddStation_Name.Location = new System.Drawing.Point(24, 84);
            this.TB_AddStation_Name.Name = "TB_AddStation_Name";
            this.TB_AddStation_Name.Size = new System.Drawing.Size(276, 36);
            this.TB_AddStation_Name.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(24, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "Latitude";
            // 
            // TB_AddStation_Latitude
            // 
            this.TB_AddStation_Latitude.DecimalPlaces = 6;
            this.TB_AddStation_Latitude.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TB_AddStation_Latitude.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TB_AddStation_Latitude.Location = new System.Drawing.Point(24, 179);
            this.TB_AddStation_Latitude.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TB_AddStation_Latitude.Name = "TB_AddStation_Latitude";
            this.TB_AddStation_Latitude.Size = new System.Drawing.Size(276, 36);
            this.TB_AddStation_Latitude.TabIndex = 4;
            // 
            // TB_AddStation_Longitude
            // 
            this.TB_AddStation_Longitude.DecimalPlaces = 6;
            this.TB_AddStation_Longitude.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TB_AddStation_Longitude.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TB_AddStation_Longitude.Location = new System.Drawing.Point(24, 277);
            this.TB_AddStation_Longitude.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TB_AddStation_Longitude.Name = "TB_AddStation_Longitude";
            this.TB_AddStation_Longitude.Size = new System.Drawing.Size(276, 36);
            this.TB_AddStation_Longitude.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(24, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Longitude";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Add_Station);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TB_AddStation_Longitude);
            this.groupBox1.Controls.Add(this.TB_AddStation_Name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TB_AddStation_Latitude);
            this.groupBox1.Location = new System.Drawing.Point(1332, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 446);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Station";
            // 
            // Add_Station
            // 
            this.Add_Station.BackColor = System.Drawing.Color.Red;
            this.Add_Station.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Add_Station.ForeColor = System.Drawing.Color.White;
            this.Add_Station.Location = new System.Drawing.Point(49, 354);
            this.Add_Station.Name = "Add_Station";
            this.Add_Station.Size = new System.Drawing.Size(220, 43);
            this.Add_Station.TabIndex = 8;
            this.Add_Station.Text = "Add Station";
            this.Add_Station.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1032, 222);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 530);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AddSeasonTicket
            // 
            this.AddSeasonTicket.BackColor = System.Drawing.Color.AntiqueWhite;
            this.AddSeasonTicket.Controls.Add(this.label11);
            this.AddSeasonTicket.Controls.Add(this.label9);
            this.AddSeasonTicket.Controls.Add(this.label10);
            this.AddSeasonTicket.Location = new System.Drawing.Point(4, 29);
            this.AddSeasonTicket.Name = "AddSeasonTicket";
            this.AddSeasonTicket.Size = new System.Drawing.Size(1772, 812);
            this.AddSeasonTicket.TabIndex = 2;
            this.AddSeasonTicket.Text = "Add Season Ticket";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(99, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 57);
            this.label7.TabIndex = 10;
            this.label7.Text = "Express";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(4, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 57);
            this.label8.TabIndex = 9;
            this.label8.Text = "Ease";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(97, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 57);
            this.label9.TabIndex = 5;
            this.label9.Text = "Express";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(2, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 57);
            this.label10.TabIndex = 4;
            this.label10.Text = "Ease";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(667, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(456, 62);
            this.label11.TabIndex = 6;
            this.label11.Text = "Add a Season Ticket";
            // 
            // LV_Station
            // 
            this.LV_Station.Location = new System.Drawing.Point(98, 222);
            this.LV_Station.Name = "LV_Station";
            this.LV_Station.Size = new System.Drawing.Size(574, 530);
            this.LV_Station.TabIndex = 11;
            this.LV_Station.UseCompatibleStateImageBehavior = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(99, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 28);
            this.label12.TabIndex = 12;
            this.label12.Text = "Name:";
            // 
            // TB_station_search
            // 
            this.TB_station_search.Location = new System.Drawing.Point(173, 177);
            this.TB_station_search.Name = "TB_station_search";
            this.TB_station_search.Size = new System.Drawing.Size(125, 27);
            this.TB_station_search.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_UpdateStation_update);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.TB_UpdateStation_Longitude);
            this.groupBox2.Controls.Add(this.TB_UpdateStation_Name);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.TB_UpdateStation_Latitude);
            this.groupBox2.Location = new System.Drawing.Point(688, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 446);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update Station";
            // 
            // btn_UpdateStation_update
            // 
            this.btn_UpdateStation_update.BackColor = System.Drawing.Color.Red;
            this.btn_UpdateStation_update.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_UpdateStation_update.ForeColor = System.Drawing.Color.White;
            this.btn_UpdateStation_update.Location = new System.Drawing.Point(38, 364);
            this.btn_UpdateStation_update.Name = "btn_UpdateStation_update";
            this.btn_UpdateStation_update.Size = new System.Drawing.Size(220, 43);
            this.btn_UpdateStation_update.TabIndex = 8;
            this.btn_UpdateStation_update.Text = "Update Station";
            this.btn_UpdateStation_update.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(6, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 32);
            this.label13.TabIndex = 1;
            this.label13.Text = "Name";
            // 
            // TB_UpdateStation_Longitude
            // 
            this.TB_UpdateStation_Longitude.DecimalPlaces = 6;
            this.TB_UpdateStation_Longitude.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TB_UpdateStation_Longitude.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TB_UpdateStation_Longitude.Location = new System.Drawing.Point(8, 277);
            this.TB_UpdateStation_Longitude.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TB_UpdateStation_Longitude.Name = "TB_UpdateStation_Longitude";
            this.TB_UpdateStation_Longitude.Size = new System.Drawing.Size(276, 36);
            this.TB_UpdateStation_Longitude.TabIndex = 6;
            // 
            // TB_UpdateStation_Name
            // 
            this.TB_UpdateStation_Name.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TB_UpdateStation_Name.Location = new System.Drawing.Point(6, 84);
            this.TB_UpdateStation_Name.Name = "TB_UpdateStation_Name";
            this.TB_UpdateStation_Name.Size = new System.Drawing.Size(276, 36);
            this.TB_UpdateStation_Name.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(6, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 32);
            this.label14.TabIndex = 5;
            this.label14.Text = "Longitude";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(2, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 32);
            this.label15.TabIndex = 3;
            this.label15.Text = "Latitude";
            // 
            // TB_UpdateStation_Latitude
            // 
            this.TB_UpdateStation_Latitude.DecimalPlaces = 6;
            this.TB_UpdateStation_Latitude.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TB_UpdateStation_Latitude.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TB_UpdateStation_Latitude.Location = new System.Drawing.Point(6, 179);
            this.TB_UpdateStation_Latitude.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TB_UpdateStation_Latitude.Name = "TB_UpdateStation_Latitude";
            this.TB_UpdateStation_Latitude.Size = new System.Drawing.Size(276, 36);
            this.TB_UpdateStation_Latitude.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 20.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(688, 222);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(277, 46);
            this.label16.TabIndex = 15;
            this.label16.Text = "Update a Station";
            // 
            // btn_Station_search
            // 
            this.btn_Station_search.Location = new System.Drawing.Point(325, 175);
            this.btn_Station_search.Name = "btn_Station_search";
            this.btn_Station_search.Size = new System.Drawing.Size(94, 29);
            this.btn_Station_search.TabIndex = 16;
            this.btn_Station_search.Text = "Search";
            this.btn_Station_search.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(83)))), ((int)(((byte)(122)))));
            this.label17.Location = new System.Drawing.Point(782, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(404, 57);
            this.label17.TabIndex = 17;
            this.label17.Text = "Station Managment";
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1794, 862);
            this.Controls.Add(this.tabControl1);
            this.Name = "Employee";
            this.Text = "AddStation";
            this.tabControl1.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.AddStation.ResumeLayout(false);
            this.AddStation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_AddStation_Latitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_AddStation_Longitude)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.AddSeasonTicket.ResumeLayout(false);
            this.AddSeasonTicket.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_UpdateStation_Longitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_UpdateStation_Latitude)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage MainMenu;
        private TabPage AddStation;
        private Button btn_Welcome_AddStation;
        private Label lb_welcome;
        private Label label2;
        private Label label1;
        private Button btn_Welcome_AddSeasonTicket;
        private Label label4;
        private Label label3;
        private NumericUpDown TB_AddStation_Longitude;
        private Label label6;
        private NumericUpDown TB_AddStation_Latitude;
        private Label label5;
        private TextBox TB_AddStation_Name;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Button Add_Station;
        private Label label17;
        private Button btn_Station_search;
        private Label label16;
        private GroupBox groupBox2;
        private Button btn_UpdateStation_update;
        private Label label13;
        private NumericUpDown TB_UpdateStation_Longitude;
        private TextBox TB_UpdateStation_Name;
        private Label label14;
        private Label label15;
        private NumericUpDown TB_UpdateStation_Latitude;
        private TextBox TB_station_search;
        private Label label12;
        private ListView LV_Station;
        private Label label7;
        private Label label8;
        private TabPage AddSeasonTicket;
        private Label label11;
        private Label label9;
        private Label label10;
    }
}