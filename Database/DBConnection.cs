using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottWilliamsC969FinalProject.Database
{
    public class DBConnection
    {
        public static MySqlConnection conn { get; set; }

        public static void startConnection()
        {

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                conn = new MySqlConnection(constr);

                conn.Open();

                MessageBox.Show("Connection is open");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void closeConnection() 
        {

            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
