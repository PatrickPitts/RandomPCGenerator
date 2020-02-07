using Newtonsoft.Json.Linq;
using RandomPCGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPCGenerator.Processors
{
    public class PersonalityProcessor
    {
        //Processes any Extra Features options for a Personality. Some Extra Features provide a choice in attribute
        //for that feature; this method will randomly select one of those features, then return a Dictionary of
        //all Extra Features, including the randomly selected options.
        public static Dictionary<string, string> ProcessExtraFeatures(JObject efObject)
        {
            Random random = new Random();
            Dictionary<string, string> featursDict = new Dictionary<string, string>();

            IList<string> keys = efObject.Properties().Select(p => p.Name).ToList();

            foreach(string key in keys)
            {
                var val = efObject[key];
                //only lists of options for a particular feature can be cast as JArray; checks for this, and randomly
                //selects one of those options.
                if(val is JArray)
                {
                    IList<string> featureList = val.ToObject<IList<string>>();
                    featursDict.Add(key, featureList[random.Next(featureList.Count)]);
                } else
                {
                    featursDict.Add(key, val.ToString());
                }
            }


            return featursDict;
        }

        public static Background randomBackground()
        {
            Background background = new Background();
            Random random = new Random();

            JObject obj = JObject.Parse(System.IO.File.ReadAllText(@"wwwroot/data/PersonalityTraits.json"));
            IList<string> names = obj.Properties().Select(p => p.Name).ToList();

            background.Name = names[random.Next(names.Count)];

            JObject JSONBackground = (JObject) obj[background.Name];
            IList<string> bgKeys = JSONBackground.Properties().Select(p => p.Name).ToList();

            JObject JCharacteristics = (JObject)JSONBackground["Characteristics"];

            IList<String> TraitList = JCharacteristics["Personality Trait"].ToObject<IList<String>>();
            background.PersonalityTrait = TraitList[random.Next(TraitList.Count)];

            TraitList = JCharacteristics["Ideal"].ToObject<IList<String>>();
            background.Ideal = TraitList[random.Next(TraitList.Count)];

            TraitList = JCharacteristics["Bond"].ToObject<IList<String>>();
            background.Bond = TraitList[random.Next(TraitList.Count)];

            TraitList = JCharacteristics["Flaw"].ToObject<IList<String>>();
            background.Flaw = TraitList[random.Next(TraitList.Count)];

            background.ExtraFeatures = ProcessExtraFeatures((JObject)JSONBackground["Extra Features"]);







            return background;
        }
    }
}
