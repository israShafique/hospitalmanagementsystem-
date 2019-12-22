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
    public partial class staffDetail : Form
    {
        public staffDetail()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Hide();

        }

        private void moduleNames_Paint(object sender, PaintEventArgs e)
        {

        }

        private void patientNames_Paint(object sender, PaintEventArgs e)
        {

        }

        private void readings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void staffDetail_Load(object sender, EventArgs e)
        {
            //listing all the staff checking in time 
            List<String> staffNames = new List<string>();
            List<String> checking = new List<string>();
            List<string> time = new List<string>();
            readings.Controls.Clear();
            patientNames.Controls.Clear();
            moduleNames.Controls.Clear();

            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "select * from checkingUser";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;

                connect.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //checking for null
                    if (reader["userName"] == null)
                    { staffNames.Add("-"); }
                    else { staffNames.Add((string)reader["userName"]); }


                    if (reader["checking"] == null)
                    { checking.Add("-"); }
                    else { checking.Add((string)reader["checking"]); }


                    if (reader["time"] == null)
                    { time.Add("-"); }
                    else { time.Add((string)reader["time"]); }


                   
                   

                }
                connect.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // creating runtime labels to show on screen using lists of staff


            for (int i = 0; i < staffNames.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + i.ToString() + "";
                label.Text = staffNames[i];
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);
                patientNames.Controls.Add(label);

            }

            for (int i = 0; i < checking.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + i.ToString() + "";
                label.Text = checking[i];
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);
                moduleNames.Controls.Add(label);

            }

     
            for (int i = 0; i < time.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + (i + 21).ToString() + "";
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);
               
                label.Text = time[i];
                readings.Controls.Add(label);


            }
        
        }
    }
}
