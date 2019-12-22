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
    public partial class EditPatientReading : Form
    {
        String patientName;
        public EditPatientReading(String pn)
        {
            InitializeComponent();
            patientName = pn;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
       // only enter numbers
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // now connect to database and fill the dropdown from the database table

            try
            { //you need to add your server name to connect on your computer

               String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";

                //getting all the values from the editPatientReading
                string min = minValue.Text;
                string max = maxValue.Text;
                double minVal = System.Convert.ToDouble(min);
                double maxVal = System.Convert.ToDouble(max);
                string selectedModule = this.moduleComboBox.GetItemText(this.moduleComboBox.SelectedItem);

                //update query to update min and max value
                String Query = "UPDATE patients SET min = "+ minVal + ", max = "+ maxVal + "WHERE patientName='"+patientName+"' and module='"+ selectedModule + "'"; ;
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                connect.Open();
                int n = command.ExecuteNonQuery();
                if(n>=0)
                {
                    MessageBox.Show("Data is updated");
                }
                connect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // after saving open previous screen
            this.Hide();
            selectPatient sp = new selectPatient();
            sp.Show();
        }

        private void EditPatientReading_Load(object sender, EventArgs e)
        {
            // now connect to database and fill the dropdown from the database table

            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "select * from patients where patientName='"+patientName +"'";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;

                connect.Open();
                reader = command.ExecuteReader();
                string moduleName = "";
                while (reader.Read())
                {
                    // adding table data in dropdown
                    moduleName = (string)reader["module"];
                    //checking for duplicate items
                    if (!moduleComboBox.Items.Contains(moduleName))
                    {

                        moduleComboBox.Items.Add(moduleName);

                    }
                }
                connect.Close();
                moduleComboBox.SelectedItem = moduleName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void minValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void maxValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void maxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only enter numbers
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            selectPatient c = new selectPatient();
            c.Show();
            this.Hide();
        }
    }
    }
