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
            UPDATE customer 
            SET 
                customerName = @customerName, 
                addressId = @addressId, 
                active = @active, 
                lastUpdateBy = @lastUpdateBy
            WHERE 
                customerId = @customerId";

            using (var command = new MySqlCommand(updateQuery, DBConnection.Conn, transaction))
            {
                command.Parameters.AddWithValue("@customerName", customerName);
                command.Parameters.AddWithValue("@addressId", addressId);
                command.Parameters.AddWithValue("@active", active);
                command.Parameters.AddWithValue("@customerId", customerId);
                command.Parameters.AddWithValue("@lastUpdateBy", DBClasses.User.CurrentUser);

                command.ExecuteNonQuery();
            }
        }

        public static void UpdateAddress(int addressId, string address1, string address2, int cityId, string postalCode, string phoneNumber, MySqlTransaction transaction)
        {

            string updateQuery = @"
            UPDATE address 
            SET 
                address = @address1, 
                address2 = @address2, 
                cityId = @cityId,
                postalCode = @postalCode,
                phone = @phoneNumber,
                lastUpdateBy = @lastUpdateBy
            WHERE 
                addressId = @addressId";

            using (var command = new MySqlCommand(updateQuery, DBConnection.Conn, transaction))
            {
                command.Parameters.AddWithValue("@address1", address1);
                command.Parameters.AddWithValue("@address2", address2);
                command.Parameters.AddWithValue("@cityId", cityId);
                command.Parameters.AddWithValue("@postalCode", postalCode);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@addressId", addressId);
                command.Parameters.AddWithValue("@lastUpdateBy", DBClasses.User.CurrentUser);

                command.ExecuteNonQuery();
            }
        }
    }
}
