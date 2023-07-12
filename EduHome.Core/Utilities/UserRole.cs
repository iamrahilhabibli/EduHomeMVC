namespace EduHome.Core.Utilities
{
    public static class UserRole
    {
        public enum Roles
        {
            Master,
            Admin,
            Visitor
        }
        const string Master = "Master";
        const string Admin = "Admin";
        const string Visitor = "Visitor";
    }
}
