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
        public static CharacterClass getRandomCharacterClass()
        {
            CharacterClass Character = new CharacterClass();

            Random random = new Random();
            JObject obj = JObject.Parse(System.IO.File.ReadAllText(@"wwwroot/data/ChrClass.json"));

            IList<string> ChrClassNames = obj.Properties().Select(p => p.Name).ToList();

            Character.ClassName = ChrClassNames[random.Next(ChrClassNames.Count)];
            JObject ChrClassObject = (JObject)obj[Character.ClassName];

            Character.HitDie = (int) ChrClassObject["Hit Die"];
            Character.SavingThrows = ((JArray) ChrClassObject["Saving Throws"]).Select(p => (string)p).ToArray();



            return Character;
        }
    }
}
