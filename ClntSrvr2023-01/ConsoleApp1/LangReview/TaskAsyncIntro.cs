namespace ConsoleApp1.LangReview
{
    using System;
    using System.Collections.Generic;
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

        public async Task TestSimpleTaskFunc2()
        {
            Print();
            // thread A
            // 
            var task1 =  PrintAsync();      // thread B
            var task2 = GetAnswerAsync();   // thread C

            // thread A
            // do some heavy calculations 
            Console.WriteLine("before await");

            await task2;
            await task1;
            Console.WriteLine("done task 1 & task2");
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
