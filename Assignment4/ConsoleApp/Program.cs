using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        public class User
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public User(int userId, string username, string name, string email)
            {
                UserId = userId;
                Username = username;
                Name = name;
                Email = email;
            }
        }

        public class Game
        {
            public int GameId { get; set; }
            public string Name { get; set; }
            public string GameCategory { get; set; }

            public Game(int gameId, string name, string gameCategory)
            {
                GameId = gameId;
                Name = name;
                GameCategory = gameCategory;
            }
        }

        public class GameScore
        {
            public int GameId { get; set; }
            public int UserId { get; set; }
            public int Score { get; set; }
            public DateTime Date { get; set; }

            public GameScore(int gameId, int userId, int score, DateTime date)
            {
                GameId = gameId;
                UserId = userId;
                Score = score;
                Date = date;
            }
        }

        List<User> UsersList = new List<User>();
        List<Game> GamesList = new List<Game>();
        List<GameScore> GameScoresList = new List<GameScore>();

        static void Main(string[] args)
        {
            Program program = new Program();
            string choice = "0";
            while (choice != "12")
            {
                choice = "0";
                Console.WriteLine("What would you like to do?\n" +
                "1 - Create User\r\n" +
                "2 - Register for Game\r\n" +
                "3 - Get User games\r\n" +
                "4 - Get User info\r\n" +
                "5 - Get Users by name\r\n" +
                "6 - Get Games by name\r\n" +
                "7 - Record User session\r\n" +
                "8 - Delete User session\r\n" +
                "9 - Delete User\r\n" +
                "10 - Get User sessions\r\n" +
                "11 - Get top scores for game" +
                "12 - Exit\r\n");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    program.CreateUser();
                }
                if (choice == "2")
                {
                    program.GameRegister();
                }
            }
        }

        void CreateUser()
        {
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            int userId = UsersList.Count+1;
            User user = new User(userId, username, name, email);
            UsersList.Add(user);
            Console.WriteLine(UsersList);
        }

        void GameRegister()
        {

        }
    }
}