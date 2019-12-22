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
    public partial class patientAlarm : Form
    {
        public patientAlarm()
        {
            InitializeComponent();
        }

        private void patientAlarm_Load(object sender, EventArgs e)
        {
            //listing all the paatiet alarm time
            List<String> patients = new List<string>();
            List<String> module = new List<string>();
            List<string> time = new List<string>();
            readings.Controls.Clear();
            patientNames.Controls.Clear();
            moduleNames.Controls.Clear();

            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "select * from patientAlarm";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;

                connect.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //checking for null
                    
                    patients.Add((string)reader["patientName"]); 
                    module.Add((string)reader["module"]);   
                    time.Add((string)reader["time"]); 

                }
                connect.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // creating runtime labels to show on screen using lists of staff


            for (int i = 0; i < patients.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + i.ToString() + "";
                label.Text = patients[i];
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);
                patientNames.Controls.Add(label);

            }

            for (int i = 0; i < module.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + i.ToString() + "";
                label.Text = module[i];
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

        private void button2_Click(object sender, EventArgs e)
        {
            management m = new management();
            m.Show();
            this.Hide();
        }
    }
}
