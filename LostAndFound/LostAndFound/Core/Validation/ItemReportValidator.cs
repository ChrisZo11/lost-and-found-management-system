namespace LostAndFound
{
    public sealed class ItemReportValidationResult
    {
        public ItemReportValidationResult(
            bool missingItemName,
            bool missingDescription,
            bool missingLocation,
            string message)
        {
            MissingItemName = missingItemName;
            MissingDescription = missingDescription;
            MissingLocation = missingLocation;
            Message = message;
        }

        public bool MissingItemName { get; private set; }
        public bool MissingDescription { get; private set; }
        public bool MissingLocation { get; private set; }
        public string Message { get; private set; }
        public bool IsValid
        {
            get { return !MissingItemName && !MissingDescription && !MissingLocation; }
        }
    }

    public sealed class ItemReportValidator
    {
        public ItemReportValidationResult Validate(string itemName, string description, string location)
        {
            bool missingItemName = string.IsNullOrWhiteSpace(itemName);
            bool missingDescription = string.IsNullOrWhiteSpace(description);
            bool missingLocation = string.IsNullOrWhiteSpace(location);

            return new ItemReportValidationResult(
                missingItemName,
                missingDescription,
                missingLocation,
                "Lengkapi nama, lokasi, dan deskripsi barang.");
        }
    }
}
