using System;
using System.Windows.Forms;


namespace CountryInfo
{
    public partial class SearchForm : Form
    {
        public string nameCountry;
        public SearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Field 'Name' coudnt be empty");
            }
            else
            {
                nameCountry = textBox1.Text;
                Form1 showOne = new Form1();
                showOne.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
