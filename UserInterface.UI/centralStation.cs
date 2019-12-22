using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.UI
{
    public partial class cntralStation : Form
    {
        string patient;
        String module;
        List<String> patients = new List<string>();
        public cntralStation(String p, string m)
        {
            patient = p;
            module=m;
            InitializeComponent();
            patient = p;
        }

        private void cntralStation_Load(object sender, EventArgs e)
        {
            
        Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            showPatients.Controls.Clear();
            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "select * from patients";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;

                connect.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    patients.Add((string)reader["patientName"]);
                   

                }
                connect.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // creating runtime labels to show on screen using lists of patients, module and readings

               patients= patients.Distinct().ToList();

            for (int i = 0; i < patients.Count; i++)
            {
                    Label label = new Label();
                    label.Name = "label" + i.ToString() + "";
                    label.Text = patients[i];
                    label.AutoSize = true;
                    label.Font = new Font("Arial", 20);
                    if (patients[i] == patient)
                    {
                        label.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        label.BackColor = System.Drawing.Color.Green;

                    }
                    showPatients.Controls.Add(label);

                }
            SoundPlayer alarm = new SoundPlayer(Resource1.alarm);

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPage ap = new AdminPage();
            ap.Show();
        }
    }
}
