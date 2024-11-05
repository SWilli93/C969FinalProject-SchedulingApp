using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ScottWilliamsC969FinalProject.Database
{
    public static class DBUpdate
    {
        public static void UpdateCustomer(int customerId, string customerName, int addressId, int active, MySqlTransaction transaction)
        {

            string updateQuery = @"
            UPDATE customers 
            SET 
                customerName = @customerName, 
                addressId = @addressId, 
                active = @active 
            WHERE 
                customerId = @customerId";

            using (var command = new MySqlCommand(updateQuery, DBConnection.Conn, transaction))
            {
                command.Parameters.AddWithValue("@customerName", customerName);
                command.Parameters.AddWithValue("@addressId", addressId);
                command.Parameters.AddWithValue("@active", active);
                command.Parameters.AddWithValue("@customerId", customerId);

                command.ExecuteNonQuery();
            }
        }
    }
}
