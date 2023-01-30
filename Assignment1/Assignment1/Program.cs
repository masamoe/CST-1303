
class Program
{
    class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    class RegularUser : User
    {
        public int AwardedCredit { get; set; }
    }

    class EliteUser : User
    {
        public int OwnedCredit { get; set; }
        public int EarnedCredit { get; set; }
    }

    static void DisplayUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Username);
            Console.WriteLine(user.Password);
            Console.WriteLine(user.Email);
            if (user is RegularUser)
            {
                var regularUser = (RegularUser)user;
                Console.WriteLine(regularUser.AwardedCredit);
            }
            else if (user is EliteUser)
            {
                var eliteUser = (EliteUser)user;
                Console.WriteLine(eliteUser.OwnedCredit);
                Console.WriteLine(eliteUser.EarnedCredit);
            }
        }
    }


    static void Main(string[] args)
    {
        var users = new List<User>
        {
            new RegularUser { Name = "John Johnston", Username = "john23452", Password = "123", Email = "john@email.com", AwardedCredit = 100 },
            new EliteUser { Name = "Mary Merriweather", Username = "marymerry", Password = "password1", Email = "mary@email.com", OwnedCredit = 100, EarnedCredit = 200 }
        };
        DisplayUsers(users);
    }
}