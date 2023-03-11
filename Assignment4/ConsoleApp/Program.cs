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

            public override string ToString()
            {
                return $"User Id: {UserId}, Username: {Username}, Name: {Name}, Email: {Email}";
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
                Console.WriteLine(
                "        _____________________________________________________________\r\n" +
                "       /                                                             \\\r\n" +
                "      /  /~~\\  |\\___/|   WELCOME TO MY GAME PROVIDER!     /~~\\        \\\r\n" +
                "     /  /    \\ |     |                                   /    \\        \\\r\n" +
                "    /  /      \\|.  . |                                  /      \\        \\\r\n" +
                "   /  /        \\ ___ /                                 /        \\        \\\r\n" +
                "  /__/__________\\_____________________________________/__________\\________\\ \r\n\n" +
                "  What would you like to do?\n" +
                "  1 - Create User\n" +
                "  2 - Register for Game\n" +
                "  3 - Get User games\n" +
                "  4 - Get User info\n" +
                "  5 - Get Users by name\n" +
                "  6 - Get Games by name\n" +
                "  7 - Record User session\n" +
                "  8 - Delete User session\n" +
                "  9 - Delete User\n" +
                "  10 - Get User sessions\n" +
                "  11 - Get top scores for game\n" +
                "  12 - Exit\n");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    program.CreateUser();
                }
                if (choice == "2")
                {
                    program.GameRegister();
                }
                if (choice == "3")
                {
                    program.GetUserGames();
                }
                if (choice == "4")
                {
                    program.GetUserInfo();
                }
                if (choice == "5")
                {
                    program.GetUsersByName();
                }
                if (choice == "6")
                {
                    program.GetGamesByName();
                }
                if (choice == "7")
                {
                    program.RecordUserSession();
                }
                if (choice == "8")
                {
                    program.DeleteUserSession();
                }
                if (choice == "9")
                {
                    program.DeleteUser();
                }
                if (choice == "10")
                {
                    program.GetUserSessions();
                }
                if (choice == "11")
                {
                    program.GetTopScoresForGame();
                }
                if (choice == "12")
                {
                    Console.WriteLine("Goodbye!");
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
            Console.WriteLine("Enter game name");
            string gameName = Console.ReadLine();
            Console.WriteLine("Enter game category");
            string gameCategory = Console.ReadLine();
            int gameId = GamesList.Count+1;
            Game game = new Game(gameId, gameName, gameCategory);
            GamesList.Add(game);
            Console.WriteLine(GamesList);
        }

        void GetUserGames()
        {
            Console.WriteLine("Enter user id");
            int userId = Convert.ToInt32(Console.ReadLine());
            var userGames = from game in GamesList
                join gameScore in GameScoresList on game.GameId equals gameScore.GameId
                where gameScore.UserId == userId
                select game;
            foreach (var game in userGames)
            {
                Console.WriteLine(game.Name);
            }
        }

        void GetUserInfo()
        {
            Console.WriteLine("Enter user id");
            int userId = Convert.ToInt32(Console.ReadLine());
            var userInfo = from user in UsersList
                where user.UserId == userId
                select user;
            foreach (var user in userInfo)
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
            }
        }

        void GetUsersByName()
        {
            Console.WriteLine("Enter user name");
            string name = Console.ReadLine();
            var usersByName = from user in UsersList
                where user.Name == name
                select user;
            foreach (var user in usersByName)
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
            }
        }

        void GetGamesByName()
        {
            Console.WriteLine("Enter game name");
            string gameName = Console.ReadLine();
            var gamesByName = from game in GamesList
                where game.Name == gameName
                select game;
            foreach (var game in gamesByName)
            {
                Console.WriteLine(game.Name);
                Console.WriteLine(game.GameCategory);
            }
        }

        void RecordUserSession()
        {
            Console.WriteLine("Enter user id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter game id");
            int gameId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter score");
            int score = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter date");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            GameScore gameScore = new GameScore(gameId, userId, score, date);
            GameScoresList.Add(gameScore);
            Console.WriteLine(GameScoresList);
        }

        void DeleteUserSession()
        {
            Console.WriteLine("Enter user id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter game id");
            int gameId = Convert.ToInt32(Console.ReadLine());
            var userSession = from gameScore in GameScoresList
                where gameScore.UserId == userId && gameScore.GameId == gameId
                select gameScore;
            foreach (var gameScore in userSession)
            {
                GameScoresList.Remove(gameScore);
            }
            Console.WriteLine(GameScoresList);
        }

        void DeleteUser()
        {
            Console.WriteLine("Enter user id");
            int userId = Convert.ToInt32(Console.ReadLine());
            var user = from user1 in UsersList
                where user1.UserId == userId
                select user1;
            foreach (var user1 in user)
            {
                UsersList.Remove(user1);
            }
            Console.WriteLine(UsersList);
        }

        void GetUserSessions()
        {
            Console.WriteLine("Enter user id");
            int userId = Convert.ToInt32(Console.ReadLine());
            var userSessions = from gameScore in GameScoresList
                where gameScore.UserId == userId
                select gameScore;
            foreach (var gameScore in userSessions)
            {
                Console.WriteLine(gameScore.Score);
                Console.WriteLine(gameScore.Date);
            }
        }

        void GetTopScoresForGame()
        {
            Console.WriteLine("Enter game id");
            int gameId = Convert.ToInt32(Console.ReadLine());
            var topScores = from gameScore in GameScoresList
                where gameScore.GameId == gameId
                orderby gameScore.Score descending
                select gameScore;
            foreach (var gameScore in topScores)
            {
                Console.WriteLine(gameScore.Score);
                Console.WriteLine(gameScore.Date);
            }
        }

        
    }
}