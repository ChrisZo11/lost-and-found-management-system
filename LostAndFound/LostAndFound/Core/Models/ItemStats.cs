namespace LostAndFound
{
    public sealed class ItemStats
    {
        public int LostCount { get; set; }
        public int FoundCount { get; set; }
        public int ReturnedCount { get; set; }

        public int ActiveCount
        {
            get { return LostCount + FoundCount; }
        }
    }
}
