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
    public partial class medicalStaffLogin : Form
    {
        public medicalStaffLogin()
        {
            InitializeComponent();
        }

        private void medicalStaffLogin_Load(object sender, EventArgs e)
        {
            // adding usernames of medical staff in the drop down
            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "select * from loginUser";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;

                connect.Open();
                reader = command.ExecuteReader();
                string name = "";
                while (reader.Read())
                {
                    // adding table data in dropdown
                    name = (string)reader["userName"];
                    //checking for duplicate items
                    if (!comboBox1.Items.Contains(name))
                    {

                        comboBox1.Items.Add(name);

                    }
                }
                connect.Close();
                comboBox1.SelectedItem = name;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            { MessageBox.Show("enter Password!!"); }
            else
            {
                // authenticating login

                string userName = (String)comboBox1.SelectedItem;
                try
                { //you need to add your server name to connect on your computer
                    String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                    String Query = "select * from loginUser where userName='" + userName + "'";
                    SqlConnection connect = new SqlConnection(conString);
                    SqlCommand command = new SqlCommand(Query, connect);
                    SqlDataReader reader;

                    connect.Open();
                    reader = command.ExecuteReader();

                    string password = "";
                    while (reader.Read())
                    {


                        password = (string)reader["password"];

                    }
                    String eneteredPassword = textBox1.Text;
                    if (eneteredPassword == password)
                    {

                        checking c = new checking(userName);
                        c.Show();
                        this.Hide();


                    }
                    else
                    {


                        MessageBox.Show("Wrong Password");
                    }

                    connect.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
