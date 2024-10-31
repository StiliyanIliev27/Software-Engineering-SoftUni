namespace Blog.Data.Common.Validation
{
    public static class ApplicationUserValidationConstants
    {
        public const int UsenameMaxLength = 20;
        public const int EmailMaxLength = 50;
        public const int PasswordMaxLength = 256; //DB Encrypted Password
        public const int PasswordSaltMaxLength = 256;
    }
}
