namespace LostAndFound
{
    public sealed class ClaimRequest
    {
        public int ItemId { get; set; }
        public string StudentNim { get; set; }
        public string StudentName { get; set; }
        public string ClaimPhotoPath { get; set; }
    }
}
