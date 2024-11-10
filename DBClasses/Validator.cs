using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottWilliamsC969FinalProject.DBClasses
{
    public static class Validator
    {

        public static bool ValidateCustomer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                
                return false;
            }
            return true;
        }


        public static bool ValidateAddress(string address1, string address2, string postalCode, string city, string country)
        {
            if (string.IsNullOrWhiteSpace(address1) || string.IsNullOrWhiteSpace(address2) || string.IsNullOrWhiteSpace(postalCode) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(country))
            {
                return false;
            }
            return true;
        }


        public static bool ValidatePhoneNumber(string phoneNumber) 
        {
            phoneNumber = phoneNumber.Trim();
            Regex phoneRegex = new Regex(@"^[\d-]+$");
            if (!phoneRegex.IsMatch(phoneNumber))
            {
                return false;
            }
            string digitsOnly = phoneNumber.Replace("-", "");
            return digitsOnly.Length == 10;
        }

        public static bool ValidateAppointment(string title, string description, string location, string contact, string type, string url)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(contact) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(url))
            {
                return false;
            }
            return true;
        }





        // Appointment Validations
        private static readonly TimeZoneInfo EasternStandardTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

        public static bool IsValidAppointment(DateTime startTime, DateTime endTime)
        {
            DateTime startEST = TimeZoneInfo.ConvertTime(startTime, EasternStandardTimeZone);
            DateTime endEST = TimeZoneInfo.ConvertTime(endTime, EasternStandardTimeZone);

            //15min appointment buffer
            DateTime bufferedStart = startEST.AddMinutes(-15);
            DateTime bufferedEnd = endEST.AddMinutes(15);


            if (!IsWithinBusinessOperationHours(startEST, endEST))
            {
                return false;
            }

            if (HasOverlappingAppointments(DBClasses.User.CurrentUser, bufferedStart, bufferedEnd))
            {
                return false;
            }

            return true;
        }

        private static bool IsWithinBusinessOperationHours(DateTime start, DateTime end)
        {
            int businessStartHour = 9;
            int businessEndHour = 17;

            bool isSameDay = start.Date == end.Date;
            bool isStartWeekday = start.DayOfWeek >= DayOfWeek.Monday && start.DayOfWeek <= DayOfWeek.Friday;
            bool isEndWeekday = end.DayOfWeek >= DayOfWeek.Monday && end.DayOfWeek <= DayOfWeek.Friday;
            bool isStartTimeValid = start.Hour >= businessStartHour && (start.Hour < businessEndHour || (start.Hour == businessEndHour && start.Minute == 0));
            bool isEndTimeValid = end.Hour >= businessStartHour && (end.Hour < businessEndHour || (end.Hour == businessEndHour && end.Minute == 0));

            return isSameDay && isStartWeekday && isEndWeekday && isStartTimeValid && isEndTimeValid && start < end;
        }

        public static bool HasOverlappingAppointments(int userId, DateTime start, DateTime end)
        {
            DateTime utcStart = start.Kind == DateTimeKind.Local ? start.ToUniversalTime() : start;
            DateTime utcEnd = end.Kind == DateTimeKind.Local ? end.ToUniversalTime() : end;

            string query = @"
                SELECT 1
                FROM 
                    appointment
                WHERE 
                    appointment.userId = @userId
                  AND 
                    (appointment.start < @newEndTime AND appointment.end > @newStartTime)
                LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@newStartTime", utcStart);
                cmd.Parameters.AddWithValue("@newEndTime", utcEnd);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

    }
}
