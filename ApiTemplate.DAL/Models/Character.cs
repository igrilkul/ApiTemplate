using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.DAL.Enums;

namespace TextualRPG.DAL.Models
{
    public class Character
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int Level { get; private set; } = 0;
        public ClassType ClassName { get; private set; } = 0;

        public string FullText => $"Lv{Level} {Name}";

        // not mapped
        private Character() { }

        public Character( string name, int level, ClassType className)
        {
            Name = name;
            Level = level;
            ClassName = className;
        }

        public void UpdateCharacter(string name, int level, ClassType className)
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
