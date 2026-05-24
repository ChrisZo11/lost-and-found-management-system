namespace LostAndFound
{
    internal static class DomainValues
    {
        internal static class Roles
        {
            public const string Admin = "Admin";
            public const string Security = "Security";
        }

        internal static class ItemTypes
        {
            public const string Lost = "Lost";
            public const string Found = "Found";
        }

        internal static class ItemStatuses
        {
            public const string Pending = "Pending";
            public const string Returned = "Returned";
        }

        internal static class ClaimStatuses
        {
            public const string Pending = "Pending";
            public const string Approved = "Approved";
            public const string Rejected = "Rejected";
        }
    }
}
