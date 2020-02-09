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
        public static void AddSpellsToCharacter(CharacterClass Character, JObject JSpellObject)
        {
            for(int i = 1; i <= Character.ClassLevel; i++)
            {
                JArray spellList = (JArray)JSpellObject[i.ToString()];
                if(spellList != null) 
                 {     
                    foreach(String spell in spellList)
                    {
                        Character.Spells.Add(spell);
                    }
                }
            }
        }

        public static string GetRandomKey(JObject jObject)
        {
            Random random = new Random();
            List<string> keys = jObject.Properties().Select(p => p.Name).ToList();
            return keys[random.Next(keys.Count)];
        }

        public static void AddCoreFeaturesToCharacter(CharacterClass Character, JObject JCoreFeatures)
        {
            for (int i = 1; i <= Character.ClassLevel; i++)
            {
                JArray features = (JArray)JCoreFeatures[i.ToString()];
                if (features != null)
                {
                    foreach (String feature in features)
                    {
                        Character.ClassFeatures.Add(feature);
                    }
                }

            }
        }
        public static CharacterClass GetRandomCharacterClass(int ChrLevel)
        {
            CharacterClass Character = new CharacterClass
            {
                ClassLevel = ChrLevel
            };
            Random random = new Random();
            JObject obj = JObject.Parse(System.IO.File.ReadAllText(@"wwwroot/data/ChrClass.json"));

            IList<string> ChrClassNames = obj.Properties().Select(p => p.Name).ToList();
            ChrClassNames.Remove("_Class");

            Character.ClassName = ChrClassNames[random.Next(ChrClassNames.Count)];
            JObject ChrClassObject = (JObject)obj[Character.ClassName];

            Character.HitDie = (int) ChrClassObject["Hit Die"];
            Character.SavingThrows = ((JArray) ChrClassObject["Saving Throws"]).Select(p => (string)p).ToArray();
            JObject CoreClassFeatures = (JObject) ChrClassObject["Core Features"];
            AddCoreFeaturesToCharacter(Character, CoreClassFeatures);


            //JObject JSubclasses = ChrClassObject["Subclasses"];
            IList<string> SubclassOptions = ((JObject) ChrClassObject["Subclasses"]).Properties().Select(p => p.Name).ToList();
            Character.SubclassName = SubclassOptions[random.Next(SubclassOptions.Count)];
            JObject JSubclass = (JObject)((JObject) ChrClassObject["Subclasses"])[Character.SubclassName];
            foreach(String key in JSubclass.Properties().Select(p => p.Name))
            {
                if(key.ToLower().Contains("spell") || key.ToLower().Contains("spells"))
                {
                    JObject jObject = (JObject)JSubclass[key];
                    JToken jt = jObject[jObject.Properties().Select(p => p.Name).FirstOrDefault()];
                    while(jt is JObject && jt !is JArray)
                    {
                        string newKey = GetRandomKey((JObject)jt);
                        jt = jt[newKey];
                    }
                    AddSpellsToCharacter(Character, (JObject)jt);
                }
            }


            return Character;
        }
    }
}
