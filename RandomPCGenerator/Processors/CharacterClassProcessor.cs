using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RandomPCGenerator.Models;


namespace RandomPCGenerator.Processors
{
    public class CharacterClassProcessor
    {
        public static CharacterClass getRandomCharacterClass(int ChrLevel)
        {
            CharacterClass Character = new CharacterClass();
            Character.ClassLevel = ChrLevel;
            Random random = new Random();
            JObject obj = JObject.Parse(System.IO.File.ReadAllText(@"wwwroot/data/ChrClass.json"));

            IList<string> ChrClassNames = obj.Properties().Select(p => p.Name).ToList();

            Character.ClassName = ChrClassNames[random.Next(ChrClassNames.Count)];
            JObject ChrClassObject = (JObject)obj[Character.ClassName];

            Character.HitDie = (int) ChrClassObject["Hit Die"];
            Character.SavingThrows = ((JArray) ChrClassObject["Saving Throws"]).Select(p => (string)p).ToArray();
            JObject CoreClassFeatures = (JObject) ChrClassObject["Core Features"];
            for(int i = 1; i <= Character.ClassLevel; i++)
            {
                JArray features = (JArray) CoreClassFeatures[i.ToString()];
                foreach(String feature in features)
                {
                    Character.ClassFeatures.Add(feature);
                }
            }

            JObject JSubclasses = ChrClassObject["Subclasses"];
            IList<string> SubclassOptions = JSubclasses.Properties().Select(p => p.Name).ToList();


            return Character;
        }
    }
}
