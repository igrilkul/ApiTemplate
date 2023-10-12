using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextualRPG.DAL.Models
{
    public class Enemy
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int Level { get; private set; } = 0;
        public string Description { get; private set; } = String.Empty;
        public int Experience { get; private set; } = 0;
        public int Hp { get; private set; } = 100;
        public int Mp { get; private set; } = 100;
        public int Defense { get; private set; } = 0;
        public int MagicResistance { get; private set; } = 0;
        public int BleedResistance { get; private set; } = 0;
        public int PoisonResistance { get; private set; } = 0;
        public int StunResistance { get; private set; }= 0;
        public Zone? Zone { get; private set; }

        public void UpdateEnemy(string name, int level, string description, int experience,
            int hp, int mp, int defense, int magicResistance, int bleedResistance, 
            int poisonResistance, int stunResistance, Zone? zone)
        {
            Name = name;
            Level = level;
            Description = description;
            Experience = experience;
            Hp = hp;
            Mp = mp;
            Defense = defense;
            MagicResistance = magicResistance;
            BleedResistance = bleedResistance;
            PoisonResistance = poisonResistance;
            StunResistance = stunResistance;
            Zone = zone;
        }

    }
}
