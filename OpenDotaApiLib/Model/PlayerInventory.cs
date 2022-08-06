namespace OpenDotaApiLib.Model
{
    public class PlayerInventory
    {
        public int? Item0 { get; private set; }
        public int? Item1 { get; private set; }
        public int? Item2 { get; private set; }
        public int? Item3 { get; private set; }
        public int? Item4 { get; private set; }
        public int? Item5 { get; private set; }
        public int? Backpack0 { get; private set; }
        public int? Backpack1 { get; private set; }
        public int? Backpack2 { get; private set; }
        public int? Backpack3 { get; private set; } //idk what is this, but it exists
        public int? ItemNeutral { get; private set; }

        public PlayerInventory(int? item0, int? item1, int? item2, int? item3, int? item4, int? item5, int? backpack0, int? backpack1, int? backpack2, int? backpack3, int? itemNeutral)
        {
            Item0 = item0;
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
            Backpack0 = backpack0;
            Backpack1 = backpack1;
            Backpack2 = backpack2;
            Backpack3 = backpack3;
            ItemNeutral = itemNeutral;
        }
    }
}
