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
    public partial class managerLogin : Form
    {
        public managerLogin()
        {
            InitializeComponent();
        }

        private void managerLogin_Load(object sender, EventArgs e)
        {
            // adding usernames of medical staff in the drop down
            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "select * from managerLogin";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;

                connect.Open();
                reader = command.ExecuteReader();
                string name = "";
                while (reader.Read())
                {
                    // adding table data in dropdown
                    name = (string)reader["managerName"];
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
                    String Query = "select * from managerLogin where managerName='" + userName + "'";
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

                        management c = new management();
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
    }
}
