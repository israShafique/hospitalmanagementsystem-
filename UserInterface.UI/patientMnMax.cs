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
    public partial class patientMnMax : Form
    {
        public patientMnMax()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void patientMnMax_Load(object sender, EventArgs e)
        {
            //listing all the patientDetails about min and max
            List<String> patients = new List<string>();
            List<String> module = new List<string>();
            List<string> min = new List<string>();
            List<string> max = new List<string>();

            readings.Controls.Clear();
            patientNames.Controls.Clear();
            moduleNames.Controls.Clear();
            MAX.Controls.Clear();


            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "select * from patients";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;
                string chekPatient = "";
                bool flag = true;
                connect.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chekPatient = (string)reader["patientName"];
                    for (int i = 0; i < patients.Count; i++)
                    {
                        if (patients[i] == chekPatient)
                        {
                            flag = false;
                        }
                    }
                    if (flag == false)
                    { }
                    else
                    {
                        patients.Add((string)reader["patientName"]);
                        module.Add((string)reader["module"]);
                        min.Add(reader["min"].ToString());
                        max.Add(reader["max"].ToString());

                    }

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
                label.Text = module[i].ToString();
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);
                moduleNames.Controls.Add(label);

            }


            for (int i = 0; i < min.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + (i + 21).ToString() + "";
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);

                label.Text = min[i].ToString();
                readings.Controls.Add(label);


            }
            for (int i = 0; i < max.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + (i + 31).ToString() + "";
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);

                label.Text = max[i].ToString();
                MAX.Controls.Add(label);


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Hide();
        }
    }
}
