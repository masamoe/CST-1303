namespace ConsoleApp1
{
    using System;
    using ConsoleApp1.Network;
    using ConsoleApp1.LangReview;
    using System.Collections.Generic;
    using System.Threading;
    using mine = ConsoleApp1.LangReview;
    using System.Threading.Tasks;

    public class Program
    {
        private static object _lock = new object();

        private static bool _done = false;
        static async Task Main(string[] args)
        {
            // var taskAsyncIntro = new TaskAsyncIntro();
            // await taskAsyncIntro.TestSimpleTaskFunc2();

            var fio = new StreamsIntro();
            fio.FileInputOutput("test1.txt");
        }

        private void TestTaskThatThrowsException()
        {
            var program = new Program();

            try
            {
                program.TaskThatThrowsException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void TaskThatThrowsException()
        {
            Task task = Task.Run(() => { throw null; });

            try
            {
                task.Wait();
            }
            catch(AggregateException aex)
            {
                if (aex.InnerException is NullReferenceException)
                {
                    Console.WriteLine("null reference exception");
                    throw new NullReferenceException();
                }
                else
                {
                    throw;
                }
            }
        }

        private void TestThreads()
        {
            var program = new Program();
            Thread t = new Thread(program.Print);
            t.Start("hello from main");

            Thread t2 = new Thread(() => program.Print2("hello from main"));

            Task.Run(() => Console.WriteLine("Task test"));
            new Thread(() => Console.WriteLine("Thread test")).Start();
        }

        void Print2(string message) => Console.WriteLine(message);

        public void Print(object messageObj)
        {
            string message = (string)messageObj; // we need to cast here
            Console.WriteLine(message);
        }

        public static void TestThread()
        {

            Thread t = new Thread(WriteChar);
            t.Start();

            Console.WriteLine($"main by: {Thread.CurrentThread.ManagedThreadId}");
            // main thread
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"x{i} ");
                Thread.Sleep(100);
                Thread.Sleep(0);  // same as Thread.Yield();
                Thread.Yield();
            }

            Thread t2 = new Thread(Do);
            t2.Start();

            Do();

            Console.WriteLine("thread main finished");
            Console.WriteLine("thread main waiting");

            t.Join(); // blocks the current thread and waits for thread t to finish
            Console.WriteLine("thread t has ended");

            t2.Join();
            Console.WriteLine("thread t2 has ended");
        }

        public static void WriteChar()
        {
            Console.WriteLine($"WriteChar by: {Thread.CurrentThread.ManagedThreadId}");
            // new thread
            for (int i = 0; i < 20; i++)
            {
                Console.Write($"Y{i} ");
                Thread.Sleep(200);
            }
        }

        public static void Do()
        {
            lock (_lock)
            {
                if (!_done)
                {
                    _done = true;
                    Console.WriteLine($"=== Done === by: {Thread.CurrentThread.ManagedThreadId}");

                }
            }
        }

        private void TestDictionary()
        {
            var document1 = new Document() { Id = "Envi001", Title = "Enviroment Report 02/03", Author = "Jon Voight", Text = "some text ..." };
            var document2 = new Document() { Id = "News001", Title = "World News 02/03", Author = "Mark Anthony", Text = "news text ..." };

            var documents = new Dictionary<string, Document>();
            documents.Add(document1.Id, document1);
            documents.Add(document2.Id, document2);

            var doc1 = documents[document1.Id];
        }

        private void TestGenericStack()
        {
            try
            {
                var stackInt = new mine.Stack<int>(size: 2);

                stackInt.Push(1);
                stackInt.Push(2);

                stackInt.Push(3);


                var val = stackInt.Pop();
                val = stackInt.Pop();
                val = stackInt.Pop();
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Write("finally executing");
            }
        }

        private void TestSimpleTypes()
        {
            var exploreLang = new ExploreCollections();
            exploreLang.UsePrintNames();

            int x = 123; // 32-bit integer
            long y = x;  // 64-bit intetger - implicit conversion
            short z = (short)x; // explicit conversion to a 16-bit integer

            Point p1 = new Point();
            p1.x = 5;
            p1.y = 10;

            Point p2 = p1; // causes copy of value
            p2.x = 15;

            Dot d1 = new Dot();
            d1.x = 7;
            Dot d2 = d1;  // copies d1 reference

            Console.WriteLine("d1.x: {0} d2.x: {1}", d1.x, d2.x);

            d1.x = 19;
            Console.WriteLine("d1.x: {0} d2.x: {1}", d1.x, d2.x);

            Folder folder1 = new Folder(0);
            Folder.Name = "asd";
        }

        private void TestHostInformation()
        {
            var hostInfo = new HostInformation().GetHostIPAddresses("www.ibm.com");
            Folder folder2 = new Folder();
        }

        private void InheritanceExamples()
        {
            Stock myFirstStock = new Stock()
            {
                Name = "stock1",
                Shares = 5
            };

            House myHouse = new House
            {
                Name = "smallHouse",
                Mortgage = 25000
            };

            this.Display(myFirstStock);
            this.Display(myHouse);

            Stock stock2 = new Stock();
            Asset asset2 = stock2; // implicit Upcase

            Console.WriteLine(asset2.Name);
            // Console.WriteLine(asset2.Shares); // compile error

            Stock stock3 = (Stock)asset2; // explicit Downcast
            Console.WriteLine(stock3.Shares);

            House house2 = new House();
            Asset asset3 = house2;
            // Stock stock4 = (Stock)asset3; // runtime error

            // as operator
            Asset asset5 = new Asset();
            Stock stock5 = asset5 as Stock;
            this.Display(stock5);

            // is operator
            if (asset3 is House)
            {
                Console.WriteLine(((House)asset3).Mortgage);
            }
        }

        /// <summary>
        /// Polymorphism works on the basis that subclasses have all 
        /// the features of the base class
        /// </summary>
        /// <param name="asset"></param>
        public void Display(Asset asset)
        {
            if (asset != null)
            {
                Console.WriteLine("Asset.Name:{0}", asset.Name);
            }
        }
    }

    public struct Point { public int x; public int y; }

    public class Dot
    { 
        public int x; 
        public int y; 
    }
}
