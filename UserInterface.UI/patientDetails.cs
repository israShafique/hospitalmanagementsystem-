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
    public partial class patientDetails : Form
    {
        public patientDetails()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void patientDetails_Load(object sender, EventArgs e)
        {
            //listing all the patientDetails
            List<String> patients = new List<string>();
            List<int> age = new List<int>();
            List<string> gender = new List<string>();
            readings.Controls.Clear();
            patientNames.Controls.Clear();
            moduleNames.Controls.Clear();

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
                        if (patients[i]==chekPatient)
                        {
                            flag = false;
                        }
                    }
                    if (flag == false)
                    { }
                    else
                    {
                        patients.Add((string)reader["patientName"]);
                        age.Add((int)reader["age"]);
                        gender.Add((string)reader["gender"]);
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

            for (int i = 0; i < age.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + i.ToString() + "";
                label.Text = age[i].ToString();
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);
                moduleNames.Controls.Add(label);

            }


            for (int i = 0; i < gender.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + (i + 21).ToString() + "";
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);

                label.Text = gender[i];
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
