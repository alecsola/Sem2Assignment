using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Http;
using System.Security.Claims;
using LogicLayer.Services;
using Factory;
using LogicLayer.Class;

namespace DeckstopApp
{
    public partial class LogIn : Form
    {
        LogInService LS = FactoryService.createlogInUser();
        public LogIn()
        {
            InitializeComponent();
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            User loggedInUser = (LS.ValidateUserCredentials(TB_Username.Text, TB_Password.Text,null));

            if (loggedInUser != null)
            {
                this.Hide();
                var Managment = new Employee(loggedInUser);
                Managment.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Password or Username");
            }
        }
    }
}