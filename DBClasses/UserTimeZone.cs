using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScottWilliamsC969FinalProject.DBClasses
{
    public class UserTimeZone
    {
        public (string country, string timeZone) GetUserLocation()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            RegionInfo regionInfo = new RegionInfo(currentCulture.Name);

            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

            return (regionInfo.EnglishName, localTimeZone.DisplayName);
        }

        public void SetLanguage(string languageCode)
        {
            CultureInfo culture = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentUICulture = culture;

            ResourceManager rm = new ResourceManager("YourAppNamespace.Messages", typeof(LogInForm).Assembly);

            // Example of setting translated text in UI
            UsernameLabel.Text = rm.GetString("Username");
            PasswordLabel.Text = rm.GetString("Password");
            LogInFormSubmitButton.Text = rm.GetString("Submit");
            errorLabel.Text = rm.GetString("LoginError");
        }
    }


}
