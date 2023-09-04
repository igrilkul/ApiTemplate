using TextualRPG.DAL.Enums;

namespace TextualRPG.DAL.Models
{
    public class Item
    {
        public int Id { get; private set; }

        public string Title { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public float Price { get; set; }

        public ItemType Type { get; private set; }

        //Relations
        private readonly List<Character> characters = new();
        public IReadOnlyCollection<Character> Characters => characters.AsReadOnly();


        // not mapped
        public string FullText => $"{Title} - {Description}";


        private Item() { }

        public Item(string title, string description, float price, ItemType type)
        {
            Title = title;
            Description = description;
            Price = price;
            Type = type;
        }

        public void UpdateItem(string title, string description, float price, ItemType type)
        {
            Title = title;
            Description = description;
            Price = price;
            Type = type;
        }
    }
}
