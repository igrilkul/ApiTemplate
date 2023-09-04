using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextualRPG.DAL.Models
{
    public class Character
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int Level { get; private set; } = 0;
        public string ClassName { get; private set; } = string.Empty;

        public string FullText => $"Lv{Level} {Name}";

        // not mapped
        private Character() { }

        public Character(int id, string name, int level, string className)
        {
            Id = id;
            Name = name;
            Level = level;
            ClassName = className;
        }

        public void UpdateCharacter(string name, int level, string className)
        {
            Name = name;
            Level = level;
            ClassName = className;
        }

        public void LevelUpCharacter(int id, int levels)
        {
            Level += levels;
        }
    }
}
