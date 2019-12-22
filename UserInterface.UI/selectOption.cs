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
    public partial class selectOption : Form
    {
        public selectOption()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            monitorPatient mp = new monitorPatient();
            mp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patientMnMax pm = new patientMnMax();
            pm.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPage ap = new AdminPage();
            ap.Show();
            this.Hide();
        }
    }
}
