using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.UI
{
    public partial class management : Form
    {
        public management()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registerUser rg = new registerUser();
            rg.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            unregister ur = new unregister();
            ur.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            staffDetail sd = new staffDetail();
            sd.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            patientAlarm pa = new patientAlarm();
            pa.Show();
            this.Hide();
        }

        private void management_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            patientDetails pd = new patientDetails();
            pd.Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            consultantLogin cl = new consultantLogin();
            cl.Show();
            this.Hide();
        }
    }
}
