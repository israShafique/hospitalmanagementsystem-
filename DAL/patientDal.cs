using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DAL
{
    public class patientDal
    {
        public int fillDropDown()
        {
            
            String conString = "server=DESKTOP-C7FFPE6\\MSSQLSERVER01; database=patientMoniter; Integrated Security=SSPI;";
            String Query = "select * from patient";
            SqlConnection connect = new SqlConnection(conString);
            SqlCommand command = new SqlCommand(Query, connect);
            SqlDataReader reader;
            connect.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                String name = reader.GetString("patientName");
                patientNameCombo.Items.add(name);
            }


        }

    }
}
