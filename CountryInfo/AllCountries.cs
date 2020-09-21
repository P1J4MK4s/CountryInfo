using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CountryInfo
{
    public partial class AllCountries : Form
    {
        public AllCountries()
        {
            InitializeComponent();
        }

        private void countriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.countriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.countryInfoDataSet);

        }

        private void AllCountries_Load(object sender, EventArgs e)
        {
            this.countriesTableAdapter.Fill(this.countryInfoDataSet.Countries);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.countriesTableAdapter.Fill(this.countryInfoDataSet.Countries);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LoadData()
        {
            string connectionString = "Data Source = DESKTOP - 3RHQUS2/SQLEXPRESS; Initial Catalog = CountryInfo; Integrated Security = True";
            SqlConnection mySqlConnection = new SqlConnection(connectionString);
            mySqlConnection.Open();
            string Query = "SELECT Countries.Country_name , Countries.Country_code , Cyties.City_name , Countries.Area , Countries.Population , Regions.Region_name " +
                            "FROM Countries,Cyties,Regions " +
                            "WHERE Countries.Region = Regions.Id AND" +
                            "Countries.Capital = Cyties.Id";
            SqlCommand command = new SqlCommand(Query, mySqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[6]);
                for(int i = 0; i < 7; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString();
                }
                reader.Close();
                mySqlConnection.Close();
                foreach (string[] s in data)
                {
                    dataGridView1.Rows.Add(s);
                }
            }

        }
    }
}
