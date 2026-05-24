namespace LostAndFound
{
    public sealed class ItemReportRequest
    {
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public int ReportedBy { get; set; }
        public string ImagePath { get; set; }
    }
}
