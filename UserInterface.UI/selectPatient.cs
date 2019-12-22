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
    public partial class selectPatient : Form
    {
        public selectPatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checking c = new checking("n");
            c.Show();
            this.Hide();
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //geeting the selected patient and sending it to another form
            string selected = this.patientNameCombo.GetItemText(this.patientNameCombo.SelectedItem);

            //open form for editing patient data
            EditPatientReading patientReading = new EditPatientReading(selected);
            patientReading.Show();
            this.Hide();
        }

        private void selectPatient_Load(object sender, EventArgs e)
        {
            // now connect to database and fill the dropdown from the database table

            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "select * from patients";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;
  
                connect.Open();
                reader = command.ExecuteReader();
                string name = "";
                while (reader.Read())
                {
                    // adding table data in dropdown
                    name= (string)reader["patientName"];
                    //checking for duplicate items
                    if (!patientNameCombo.Items.Contains(name))
                    {
                       
                        patientNameCombo.Items.Add(name);

                    }
                }
                connect.Close();
                patientNameCombo.SelectedItem = name;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //open the form of monitoring the reading of a patient
            string selected = this.patientNameCombo.GetItemText(this.patientNameCombo.SelectedItem);
            monitorPatient form = new monitorPatient();
            form.Show();
            this.Hide();
        }
    }
}
