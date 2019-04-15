namespace Constants
{
    public static class Users
    {
        public static readonly User User1 = new User
        {
            Id = "123456",
            UserName = "张三",
            Password = "000000"
        };

        public static readonly User User2 = new User
        {
            Id = "7890ab",
            UserName = "李四",
            Password = "000000"
        };
    }

    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}