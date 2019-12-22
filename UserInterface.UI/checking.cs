using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.UI
{
    public partial class checking : Form
    {
        string userName;
        public checking(string un)
        {
            userName = un;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Hide();

        }

        private void checking_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm:ss:tt");
           
            // adding check in data in table
            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "UPDATE checkingUser set checking = 'in', time ='"+time+"' WHERE userName='"+userName+"'";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;

                connect.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                }
                connect.Close();
                MessageBox.Show("you have checked in");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            selectPatient sp = new selectPatient();
            sp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm:ss:tt");

            // adding check in data in table
            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "UPDATE checkingUser set checking = 'out', time ='" + time + "' WHERE userName='" + userName + "'";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;

                connect.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                }
                connect.Close();
                MessageBox.Show("you have checked out");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Hide();
        }
    }
}
