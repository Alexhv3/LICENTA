using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalHarmony.Globals
{
    public class JSONs
    {
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj,
                    new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });
        }

        public static T Deserialize<T>(string strObj)
        {
            return JsonConvert.DeserializeObject<T>(strObj,
                    new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });
        }
    }
}
