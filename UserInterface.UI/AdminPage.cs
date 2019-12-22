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

    public partial class AdminPage : Form
    {   
       
        
        public AdminPage()
        {
            InitializeComponent();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // open the screen of patients and hide the one opened
            selectOption so = new selectOption();
            so.Show();
            this.Hide();


            

        }

        private void timer_Tick(object sender, EventArgs e)
        {
           
           
        }
        private void AdminPage_Load(object sender, EventArgs e)
        {

           
         
        }


        


        private void AdminPage_Activated(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cntralStation cs = new cntralStation("patient","Module");
            cs.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            medicalStaffLogin mdl = new medicalStaffLogin();
            this.Hide();
            mdl.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            managerLogin ml = new managerLogin();
            ml.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            consultantLogin cl = new consultantLogin();
            cl.Show();
            this.Hide();


        }
    }
}
