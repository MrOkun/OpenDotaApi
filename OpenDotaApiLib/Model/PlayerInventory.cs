namespace OpenDotaApiLib.Model
{
    public class PlayerInventory
    {
        public int? ItemId0 { get; private set; }
        public int? ItemId1 { get; private set; }
        public int? ItemId2 { get; private set; }
        public int? ItemId3 { get; private set; }
        public int? ItemId4 { get; private set; }
        public int? ItemId5 { get; private set; }
        public int? BackpackId0 { get; private set; }
        public int? BackpackId1 { get; private set; }
        public int? BackpackId2 { get; private set; }
        public int? BackpackId3 { get; private set; } //idk what is this, but it exists
        public int? ItemNeutralId { get; private set; }
        public Item? Item0 { get; private set; }
        public Item? Item1 { get; private set; }
        public Item? Item2 { get; private set; }
        public Item? Item3 { get; private set; }
        public Item? Item4 { get; private set; }
        public Item? Item5 { get; private set; }
        public Item? Backpack0 { get; private set; }
        public Item? Backpack1 { get; private set; }
        public Item? Backpack2 { get; private set; }
        public Item? Backpack3 { get; private set; }
        public Item? ItemNeutral { get; private set; }
        public List<Item> Items;
        /// <summary>
        /// Need to load data. (FindItems)
        /// </summary>
        /// <param name="itemId0"></param>
        /// <param name="itemId1"></param>
        /// <param name="itemId2"></param>
        /// <param name="itemId3"></param>
        /// <param name="itemId4"></param>
        /// <param name="itemId5"></param>
        /// <param name="backpackId0"></param>
        /// <param name="backpackId1"></param>
        /// <param name="backpackId2"></param>
        /// <param name="backpackId3"></param>
        /// <param name="itemNeutralId"></param>
        public PlayerInventory(int? itemId0, int? itemId1, int? itemId2, int? itemId3, int? itemId4, int? itemId5, int? backpackId0, int? backpackId1, int? backpackId2, int? backpackId3, int? itemNeutralId)
        {
            ItemId0 = itemId0;
            ItemId1 = itemId1;
            ItemId2 = itemId2;
            ItemId3 = itemId3;
            ItemId4 = itemId4;
            ItemId5 = itemId5;
            BackpackId0 = backpackId0;
            BackpackId1 = backpackId1;
            BackpackId2 = backpackId2;
            BackpackId3 = backpackId3;
            ItemNeutralId = itemNeutralId;
        }

        public void FindItems()
        {
            Item0 = new Item(ItemId0, false);
            Item1 = new Item(ItemId1, false);
            Item2 = new Item(ItemId2, false);
            Item3 = new Item(ItemId3, false);
            Item4 = new Item(ItemId4, false);
            Item5 = new Item(ItemId5, false);
            Backpack0 = new Item(BackpackId0, false);
            Backpack1 = new Item(BackpackId1, false);
            Backpack2 = new Item(BackpackId2, false);
            Backpack3 = new Item(BackpackId3, false);
            ItemNeutral = new Item(ItemNeutralId, true);

            Items = new List<Item>() { Item0, Item1, Item2, Item3, Item4, Item5, Backpack0, Backpack1, Backpack2, Backpack3, ItemNeutral };
        }
    }
}
