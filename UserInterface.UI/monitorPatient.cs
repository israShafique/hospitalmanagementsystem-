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
using System.Media;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace UserInterface.UI
{
    
    public partial class monitorPatient : Form
    {
        List<String> email = new List<string>();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        List<String> patients = new List<string>();
        List<String> module = new List<string>();
        List<double> min = new List<double>();
        List<double> max = new List<double>();
        List<double> rand = new List<double>();
         int counter = 0;
                    string oldValue = "";



        public monitorPatient()
        {
            timer.Interval = ( 1000); //  5ecs
            timer.Tick += new EventHandler(timer_Tick);
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Hide();

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            // clearing every array and controls for refreshing page again
            counter = counter + 1;
            patients.Clear();
            module.Clear();
            min.Clear();
            max.Clear();
            patientNames.Controls.Clear();
            moduleNames.Controls.Clear();
            readings.Controls.Clear();
            monitorPatient_Load(sender, e);
        }

        private void monitorPatient_Load(object sender, EventArgs e)
        {
             Thread childThread;
          
            timer.Stop();
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
                while (reader.Read())
                {
                    patients.Add((string)reader["patientName"]);                   
                    module.Add((string)reader["module"]);
                    min.Add(Convert.ToDouble(reader["min"]));
                    max.Add(Convert.ToDouble(reader["max"]));

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
                String Query2 = "select * from consultant";
                SqlConnection connect2 = new SqlConnection(conString2);
                SqlCommand command2 = new SqlCommand(Query2, connect2);
                SqlDataReader reader2;

                connect2.Open();
                reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    email.Add((string)reader2["email"]);
                    
                }
                connect2.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // creating runtime labels to show on screen using lists of patients, module and readings


            for (int i=0;i<patients.Count;i++)
            {
                Label label = new Label();
                label.Name = "label"+i.ToString()+"";
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
            // creating random values for reading and generating an alarm in case of abnormal reading.
            Random random = new Random();
            String toText;
            for (int i = 0; i < max.Count; i++)
            {
                Label label = new Label();
                label.Name = "label" + (i+21).ToString() + "";
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);
                double rand2 = random.NextDouble() * ((max[i] + 0.5) - (min[i] - 0.5)) + (min[i] -0.5);
                rand2 = Math.Round(rand2, 2);
                rand.Add(rand2);
                toText = System.Convert.ToString(rand2);
                
                if (module[i].Equals("temperature") && counter < 60 && counter>0)
                {            counter = counter + 1;

                    label.Text = oldValue;
                }
                else if ((module[i].Equals("temperature") && counter >=60))
                {
                    counter = 0;
                    label.Text = toText;
                    oldValue = label.Text;
                }
                else if((module[i].Equals("temperature") && counter == 0))
                {

                    counter = counter + 1;

                    label.Text = toText;
                    oldValue = label.Text;
                   
                }
                else
                {
                    label.Text = toText;
                }
                readings.Controls.Add(label);

            }
          
            for (int i = 0; i < min.Count; i++)
            {
                if (rand[i] < min[i] || rand[i] > max[i])
                {
                   
                    string time = DateTime.Now.ToString("HH:mm:ss:tt");

                    SoundPlayer alarm = new SoundPlayer(Resource1.alarm);

                    alarm.Play();
                    DialogResult dialogResult = MessageBox.Show("" + patients[i] + " has abnormal " + module[i] + " reading! email has been sent"
                        , "Some Title", MessageBoxButtons.OKCancel);

                    //adding data of alarm

                    try
                    { //you need to add your server name to connect on your computer
                        String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
                        String Query = "update patientAlarm set module = '" + module[i]
                            + "',time='"+time+"' where patientName ='"+patients[i]+"'";
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
                    foreach (Form f in Application.OpenForms)
                    {
                        if(f.Text=="centralStation")
                        {
                           
                            f.Hide();
                           
                        }
                       
                        
                    }
                    if (dialogResult == DialogResult.OK)
                    {
                        alarm.Stop();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        alarm.Stop();

                    }
                    cntralStation cs = new cntralStation(patients[i],module[i]);
                    cs.Show();
                    string[] emails = email.ToArray();
                    childThread = new Thread(()=>CallToChildThread(patients,email));
                    childThread.Start();
      
                }
            }
            //setting timer to refresh page after every 1 seconds
            
            timer.Start();



        }
        private void monitorPatient_Activated(object sender, EventArgs e)
        {



        }
        private void button1_Click(object sender, EventArgs e)
        {
            AdminPage form = new AdminPage();
            form.Show();
            this.Hide();
        }
        public void CallToChildThread(List<String> patients, List<String> email)
        {
            MailMessage msg = new MailMessage();
            SmtpClient smt = new SmtpClient();
            System.Net.NetworkCredential ntcd = new NetworkCredential();
            msg.From = new MailAddress("enter email");
            for (int i = 0; i < email.Count; i++)
            { msg.To.Add(email[i]); }
                        msg.Subject ="Emergency";
                        msg.Body = "patient needs assisstance";        
                        smt.Host = "smtp.gmail.com";
                        ntcd.UserName = "enter email";
                        ntcd.Password = "enter email password";
                        smt.Credentials = ntcd;
                        smt.EnableSsl = true;
                        smt.Port = 587;
                        smt.Send(msg);
            MessageBox.Show("Your Mail is sended");

        }
       
    }
}
