namespace ConsoleApp1.LangReview
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;

    public class TaskAsyncIntro
    {
        public async Task TestSimpleTaskFunc()
        {
            Print();

            await PrintAsync();
            var answer = await GetAnswerAsync();
        }

        public async Task TestRunningTasksAndAwait()
        {
            Print(); // thread A is running this

            // option 1 for creating a task
            // creating a task by calling an async function
            var task1 = PrintAsync();       // thread B
            var task2 = GetAnswerAsync();   // thread C

            // thread A
            Print();

            // thread A
            // do some heavy calculations 
            Console.WriteLine("before await");

            // option 1 for awaiting: await on each task individually to complete
            await task2; 
            await task1;
            Console.WriteLine("\n === task1 & task2 are DONE! ===");


            // option 2 for creating a task.
            // creating a Task with an inline function
            Task task3 = Task.Run(() => 
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write($" T:{Task.CurrentId} executing I={i}");
                }
            });

            Task task4 = Task.Run(() =>
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write($" T: {Task.CurrentId} executing J={j}");
                }
            });

            // option 2 for awaiting: we can await on a group of tasks
            await Task.WhenAll(task3, task4); // doesn't complete until all taska have completed

            Console.WriteLine("\n === task3 & task4 are DONE! ===");
        }

        public async Task<int> GetTotalFileSize(string[] uris)
        {
            var downloadTasks = new List<Task<byte[]>>();
            foreach (var uri in uris)
            {
                var t = new WebClient().DownloadDataTaskAsync(uri);
                downloadTasks.Add(t);
            }

            var contents = await Task.WhenAll(downloadTasks);

            var sum = contents.Sum(s => s.Length);

            return sum;
        }

        private void Print()
        {
            int i = 3 * 2;
            Console.WriteLine(i);
        }

        private async Task PrintAsync()
        {
            await Task.Delay(5000);
            int i = 3 * 2;
            Console.WriteLine(i);
        }

        private async Task<int> GetAnswerAsync()
        {
            await Task.Delay(5000);
            int i = 3 * 2;

            return i;
        }
    }
}
