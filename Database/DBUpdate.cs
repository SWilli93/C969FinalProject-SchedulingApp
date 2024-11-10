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
                lastUpdate = @lastUpdate,
                lastUpdateBy = @lastUpdateBy
            WHERE 
                customerId = @customerId";

            using (var command = new MySqlCommand(updateQuery, DBConnection.Conn, transaction))
            {
                command.Parameters.AddWithValue("@customerName", customerName);
                command.Parameters.AddWithValue("@addressId", addressId);
                command.Parameters.AddWithValue("@active", active);
                command.Parameters.AddWithValue("@customerId", customerId);
                command.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
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
                lastUpdate = @lastUpdate,
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
                command.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                command.Parameters.AddWithValue("@lastUpdateBy", DBClasses.User.CurrentUser);

                command.ExecuteNonQuery();
            }
        }

        public static void UpdateAppointment(int appointmentId, int customerId, string title, string description, string location, string contact, string type, string url, DateTime start, DateTime end, MySqlTransaction transaction)
        {

            string updateQuery = @"
            UPDATE appointment 
            SET 
                customerId = @customerId,
                title = @title,
                description = @description,
                location = @location,
                contact = @contact,
                type = @type,
                url = @url,
                start = @start, 
                end = @end, 
                lastUpdate = @lastUpdate, 
                lastUpdateBy = @lastUpdateBy
            WHERE 
                appointmentId = @appointmentId";

            using (var command = new MySqlCommand(updateQuery, DBConnection.Conn, transaction))
            {
                command.Parameters.AddWithValue("@appointmentId", appointmentId);
                command.Parameters.AddWithValue("@customerId", customerId);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@location", location);
                command.Parameters.AddWithValue("@contact", contact);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@url", url);
                command.Parameters.AddWithValue("@start", start);
                command.Parameters.AddWithValue("@end", end);
                command.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                command.Parameters.AddWithValue("@lastUpdateBy", DBClasses.User.CurrentUser);

                command.ExecuteNonQuery();
            }
        }
    }
}
