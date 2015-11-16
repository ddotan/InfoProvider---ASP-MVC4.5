using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.Utilities

{
    public class AppConfigParser 
    {
        public static T Create<T>() where T : new()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var configurationSettingsInstance = new T();

            var properties = configurationSettingsInstance.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                string key = configurationSettingsInstance.GetType().Name + "." + propertyInfo.Name;
                var v = appSettings[key];

                if (v == null)
                    continue;

                var targetValue = TypeDescriptor.GetConverter(propertyInfo.PropertyType).ConvertFrom(v);
                propertyInfo.SetValue(configurationSettingsInstance, targetValue, null);
            }

            return configurationSettingsInstance;

        }


    }
}
