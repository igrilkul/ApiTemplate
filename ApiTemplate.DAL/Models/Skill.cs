using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.DAL.Enums;

namespace TextualRPG.DAL.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RequiredLevel { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int MpUsage { get; set; } = 0;
        public int StaminaUsage { get; set; } = 0;
        public int Cooldown { get; set; } = 0;
        public SkillType SkillType { get; set; }
        public string Effect { get; set; } = string.Empty;
        public int Power { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public string Requirements { get; set; } = string.Empty;
        public string Modifiers { get; set; } = string.Empty;
        public TargetType Target { get; set; }
        public int Accuracy { get; set; } = 100;
        public bool HasBleedDamage { get; set; } = false;
        public bool HasPoisonDamage { get; set; } = false;
        public bool HasStunDamage { get; set; } = false;
        public bool HasMagicDamage { get; set; } = false;
        public string LevelScaling { get; set; } = string.Empty;

    }
}
