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
        public Character Character { get; private set; }
        public Item Item { get; private set; }
        public int EnhancementLevel { get; private set; } = 0;
        public int CurrentDurability { get; private set; } = 100;

        private CharacterItem() { }

        public CharacterItem(Character character, Item item)
        {
            Character = character;
            Item = item;
            EnhancementLevel = 0;
            CurrentDurability = 100;
        }



        public void RepairItem()
        {
            CurrentDurability = 100;
        }
        public void EnhanceItem ()
        {
            EnhancementLevel += 1;
        }


    }
}
