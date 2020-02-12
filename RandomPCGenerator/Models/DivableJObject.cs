using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomPCGenerator.Models
{
    public class DivableJObject : JObject
    {
        private Dictionary<String, List<String>> Properties { set; get; } = new Dictionary<string, List<string>>();
        public DivableJObject(JObject jObject)
        {

            JObject propertiesToken = (JObject)jObject["_Prop"];
            foreach (string key in propertiesToken.Properties().Select(p => p.Name))
            {
                Properties.Add(key, ((JArray)propertiesToken[key]).ToObject<List<String>>());
            }
        }
    }
}
