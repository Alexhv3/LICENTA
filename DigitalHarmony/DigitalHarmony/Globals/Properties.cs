using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHarmony.Globals
{
    public class PropertiesSection
    {
        public static T GetParamterValue<T>(string key)
        {
            return (T)Properties.Settings.Default[key];
        }
        public static void SetParamterValue<T>(string key, T value)
        {
            Properties.Settings.Default[key] = value;
        }

        public static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
