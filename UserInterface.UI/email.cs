using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.UI
{
    public partial class email : Form
    {
        string name;
        public email(string n)
        {
            name = n;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            try
            {
                MailAddress m = new MailAddress(email);
                try
                { //you need to add your server name to connect on your computer
                    String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                    String Query = "update consultant set email = '" + email+"' where consultantName ='" + name + "'";
                    SqlConnection connect = new SqlConnection(conString);
                    SqlCommand command = new SqlCommand(Query, connect);
                    SqlDataReader reader;

                    connect.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                    connect.Close();
                    MessageBox.Show("email updates");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void email_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Hide();

        }
    }
}
