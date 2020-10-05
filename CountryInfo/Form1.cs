using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountryInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }
        
        public async Task LoadCountry()
        {
            SearchForm sf = new SearchForm();
            var country = await DataProcessor.LoadData(sf.nameCountry);
            NameMonitor.Text = country.Name;
            CodeMonitor.Text = country.CallingCodes.ToString();
            CapitalMonitor.Text = country.Capital;
            AreaMonitor.Text = country.Area.ToString();
            RegionMonitor.Text = country.Region;
            PopulationMonitor.Text = country.Population.ToString();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadCountry();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.NameMonitor.Text.Length != 0 && this.CodeMonitor.Text.Length != 0 && this.CapitalMonitor.Text.Length != 0 && this.AreaMonitor.Text.Length != 0 && this.PopulationMonitor.Text.Length != 0 && this.RegionMonitor.Text.Length != 0)
            {
                string connectionString = "Data Source = DESKTOP - 3RHQUS2/SQLEXPRESS; Initial Catalog = CountryInfo; Integrated Security = True";
                string firstQuery = "insert CountryInfo.Countries (Country_name,Country_code,Area,Population) values('" + this.NameMonitor + "','" + this.CodeMonitor + "','" + this.AreaMonitor + "','" + this.PopulationMonitor + "'";
                string secondQuery = "insert CountryInfo.Cyties (City_name) values('"+this.CapitalMonitor+"')";
                string thirdQuery = "insert CountryInfo.Regions (Region_name) values('" + this.RegionMonitor + "')";
                MySqlConnection conDataBase = new MySqlConnection(connectionString);
                MySqlCommand fcmdDataBase = new MySqlCommand(firstQuery, conDataBase);
                MySqlCommand scmdDataBase = new MySqlCommand(secondQuery, conDataBase);
                MySqlCommand tcmdDataBase = new MySqlCommand(thirdQuery, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = fcmdDataBase.ExecuteReader();
                    myReader = scmdDataBase.ExecuteReader();
                    myReader = tcmdDataBase.ExecuteReader();
                    MessageBox.Show("Saved!");
                    while (myReader.Read()) { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fields coudnt be empty");
            }
        }
    }
}
