using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace HarryPotter_Characters
{
    internal class Program
    {
        public class Child
        {

            string FullName;

            public Child(string name)
            {
                FullName = name;
            }
        }


        public class Spell
        {
            public int Index;
            public string Name;
            public string Use;

            public Spell(int index, string name, string use)
            {
                Index = index;
                Name = name;
                Use = use;
            }
        }


        public class Character
        {
            List<Spell> KnownSpells;
            List<Child> Children;
            int Index;
            string FullName;
            string Nickname;
            string HogwartsHouse;
            string InterpretedBy;
            string Image;
            DateTime Birthdate;
           
            public Character(string fullname, string nickname, string hogwartshouse, string interpretedby, List<Child> children, string image, DateTime birthdate, int index, List<Spell> knownspells)
            {
                KnownSpells = knownspells;
                Children = children;
                Nickname = nickname;
                Index = index;
                FullName = fullname;
                HogwartsHouse = hogwartshouse;
                InterpretedBy = interpretedby;
                Image = image;
                Birthdate = birthdate;
            }
        }


        public static string[] CsvReader(string csv)
        {
            string[] lines = File.ReadAllLines(csv);

            return lines;
        }


        static void Main(string[] args)
        {
            string[] spells = CsvReader("spells.csv");
            List<Spell> serSpells = new List<Spell>();
            List<string> parts;
            
                for (int i = 1; i < spells.Length; i++) {

                

                parts = (Regex.Split(spells[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")).ToList();

                serSpells.Add(new Spell(Convert.ToInt32(parts[2]), parts[0], parts[1]));

                parts.Clear();
                }

            Console.WriteLine(serSpells[0].Index);

            string[] characters = CsvReader("characters.csv");
            List<Character> SerCharacters = new List<Character>();

            for(int i = 1;i < characters.Length;i++)
            {
                parts = (Regex.Split(characters[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")).ToList();

                var children = parts[4].Split(',').ToList();
                var serChildren = new List<Child>();

                foreach(var child in children)
                {
                    Child currChild = new Child(child);
                }
                

                SerCharacters.Add(new Character(parts[0], parts[1], parts[2], parts[3], children , parts[5], parts[6], parts[7], parts[8]))
            }

        }
    }
}
