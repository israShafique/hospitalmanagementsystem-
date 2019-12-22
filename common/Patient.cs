using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace common
{   //This is a common class accessable by both UI and database
    // patient class to store attributes of a patient
    public class Patient
    {
        public String name;
        public String module;
        public double min;
        public double max;

        


        public void showAlert(List<string> patientNames, List<string> modules, List<double> min, List<double> max)
        {

            //creates random value after sometime i.e module reading
            Random random = new Random();
           
            for (int i=0;i<patientNames.Count;i++)
            {
                double rand = random.NextDouble() * ((max[i] +1) - (min[i]-1 )) + (min[i] +1);
                rand = Math.Round(rand, 2);
                if(rand<min[i]||rand>max[i])
                {
                    MessageBox.Show(""+patientNames[i]+" need attention for "+ modules[i]+" !","Emergency!");

                }
            }
        }
    }

   
}
