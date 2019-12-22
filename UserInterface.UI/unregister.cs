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
    public partial class unregister : Form
    {
        public unregister()
        {
            InitializeComponent();
        }

        private void unregister_Load(object sender, EventArgs e)
        {

            //showing user names
            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "select * from checkingUser";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = (string)comboBox1.SelectedItem;
            //unregistering user 
            try
            { //you need to add your server name to connect on your computer
                String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query = "DELETE FROM checkingUser WHERE userName='"+userName + "'";
                SqlConnection connect = new SqlConnection(conString);
                SqlCommand command = new SqlCommand(Query, connect);
                SqlDataReader reader;

                connect.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                }
                connect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            { //you need to add your server name to connect on your computer
                String conString2 = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                String Query2 = "DELETE FROM loginUser WHERE userName='" + userName + "'";
                SqlConnection connect2 = new SqlConnection(conString2);
                SqlCommand command2 = new SqlCommand(Query2, connect2);
                SqlDataReader reader2;

                connect2.Open();
                reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {

                }
                connect2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("user unregistered");
            management mn = new management();
            mn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            management mng = new management();
            this.Hide();
            mng.Show();
        }
    }
}
