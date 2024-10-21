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
        public static MySqlConnection Conn { get; set; }

        public static void startConnection()
        {

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                Conn = new MySqlConnection(constr);

                Conn.Open();

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
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
