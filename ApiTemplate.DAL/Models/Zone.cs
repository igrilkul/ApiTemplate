using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextualRPG.DAL.Models
{
    public class Zone
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int RequiredLevel { get; private set; } = 0;
        public string Description { get; private set; } = string.Empty;

        public Zone(string name, int requiredLevel)
        {
            Name = name;
            RequiredLevel = requiredLevel;
        }

        public void UpdateZone(string Name, int RequiredLevel, string Description)
        {
            this.Name = Name;
            this.RequiredLevel = RequiredLevel;
            this.Description = Description;
        }
    }
}
