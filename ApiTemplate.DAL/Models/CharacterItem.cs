using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextualRPG.DAL.Models
{
    public class CharacterItem
    {
        public int Id { get;private set; }
        public Character? Character { get; private set; } = null!;
        public Item? Item { get; private set; } = null!;

        public int EnhancementLevel { get; private set; }
        public int SaleValue { get; private set; }
        public int CurrentDurability { get; private set; }

        public void RepairItem(CharacterItem item)
        {
            item.CurrentDurability = 100;
        }
        public void EnhanceItem (CharacterItem item)
        {
            item.EnhancementLevel += 1;
        }

    }
}
