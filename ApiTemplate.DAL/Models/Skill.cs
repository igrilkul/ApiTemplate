using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.DAL.Contracts;
using TextualRPG.DAL.Enums;

namespace TextualRPG.DAL.Models
{
    public class Skill : ISkill
    {
        private readonly List<ISkill>? _children;
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

        private Skill() {}

        public Skill(string name, int requiredLevel, string description, int mpUsage, int staminaUsage, int cooldown, SkillType skillType)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Description = description;
            MpUsage = mpUsage;
            StaminaUsage = staminaUsage;
            Cooldown = cooldown;
            SkillType = skillType;
            _children = new List<ISkill>();
        }

        public void AddChild(ISkill child)
        {
            _children.Add(child);
        }

        public void DisplayInfo(string indent = "")
        {
            Console.WriteLine($"{indent}Skill: {Name}");
            Console.WriteLine($"{indent}Description: {Description}");

            foreach (var child in _children)
            {
                child.DisplayInfo(indent + "  ");
            }
        }
    }
}
