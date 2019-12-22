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
    public partial class registerUser : Form
    {
       

        public registerUser()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("enter password!!");
            }
            else
            {
                List<String> userNames = new List<string>();
                bool flag = false;
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
                        userNames.Add((string)reader["userName"]);

                    }
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //registering user in data base

                string userName = textBox1.Text;
                string password = textBox2.Text;
                for (int i = 0; i < userNames.Count; i++)
                {
                    if (userNames[i] == userName)
                    {
                        flag = false;
                        MessageBox.Show("user already exists");

                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    try
                    { //you need to add your server name to connect on your computer
                        String conString3 = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                        String Query3 = "INSERT INTO loginUser (userName, password) VALUES('" + userName + "', '" + password + "')";
                        SqlConnection connect3 = new SqlConnection(conString3);
                        SqlCommand command3 = new SqlCommand(Query3, connect3);
                        SqlDataReader reader3;

                        connect3.Open();
                        reader3 = command3.ExecuteReader();
                        while (reader3.Read())
                        {
                        }
                        connect3.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    { //you need to add your server name to connect on your computer
                        String conString2 = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                        String Query2 = "INSERT INTO checkingUser (userName,checking,time) VALUES('" + userName + "','-','-')";
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
                    MessageBox.Show("new user Added");

                }
                else
                {
                    management mng = new management();
                    mng.Show();
                    this.Hide();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            management mng = new management();
            mng.Show();
            this.Hide();
        }

        private void registerUser_Load(object sender, EventArgs e)
        {

        }
    }
}
