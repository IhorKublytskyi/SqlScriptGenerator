namespace Service.Constants
{
    public static class ApplicationConstants
    {
        public static class Validation
        {
            public const int MinQuantity = 1;
            public const int MaxQuantity = 10000;
            public const int DefaultPageSize = 20;
            public const int MaxPageSize = 100;
        }

        public static class Database
        {
            public const string FakeUsersTableName = "FakeUsers";
            public const int MaxStringLength = 255;
            public const int PhoneNumberLength = 12;
        }

        public static class ErrorMessages
        {
            public const string InvalidQuantity = "Quantity must be between 1 and 10000";
            public const string UnsupportedDialect = "The specified database dialect is not supported";
            public const string InvalidPageSize = "Page size must be between 1 and 100";
        }
    }
} 