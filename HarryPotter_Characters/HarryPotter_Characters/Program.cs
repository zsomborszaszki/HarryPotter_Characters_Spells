using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
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
            int Index;
            string Name;
            string Use;

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
           
            public Character(List<Spell> knownspells, List<Child> children, int index, string fullname, string nickname, string hogwartshouse, string interpretedby, string image, DateTime birthdate)
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
            string[] nigg = CsvReader("characters.csv");

            foreach (string lines in nigg) 
            {
                Console.WriteLine(lines);
            }
        }
    }
}
