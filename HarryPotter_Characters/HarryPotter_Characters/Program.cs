using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace HarryPotter_Characters
{
    internal class Program
    {


        public class Child
        {

            public string FullName;

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

            public Spell(string name)
            {
                Name = name;
            }
        }


        public class Character
        {
            public List<Spell> KnownSpells;
            public List<Child> Children;
            public int Index;
            public string FullName;
            public string Nickname;
            public string HogwartsHouse;
            public string InterpretedBy;
            public string Image;
            public DateTime Birthdate;

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


        public void Sorting(List<Character> SerCharacters)
        {
            var sortedChars = SerCharacters.OrderBy(date => date).ToList();
        }

        static void Main(string[] args)
        {
            string[] spells = CsvReader("spells.csv");
            List<Spell> serSpells = new List<Spell>();
            List<string> parts;

            for (int i = 1; i < spells.Length; i++)
            {



                parts = (Regex.Split(spells[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")).ToList();

                serSpells.Add(new Spell(Convert.ToInt32(parts[2]), parts[0], parts[1]));

                parts.Clear();
            }


            string[] characters = CsvReader("characters.csv");
            List<Character> SerCharacters = new List<Character>();

            for (int i = 1; i < characters.Length; i++)
            {
                parts = (Regex.Split(characters[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")).ToList();

                var children = parts[4].Split(',').ToList();
                var serChildren = new List<Child>();

                foreach (var child in children)
                {
                    Child currChild = new Child(child);
                    serChildren.Add(currChild);
                }

                DateTime parsedDate = DateTime.Parse(parts[6]);

                var charSpells = parts[8].Split(';');
                var serSpell = new List<Spell>();

                foreach (var charSpell in charSpells)
                {
                    Spell curSpell = new Spell(charSpell);
                    serSpell.Add(curSpell);
                }


                SerCharacters.Add(new Character(parts[0], parts[1], parts[2], parts[3], serChildren, parts[5], parsedDate, Convert.ToInt32(parts[7]), serSpell));
            }

        }
    }
}
