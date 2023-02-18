namespace ConsoleApp1.LangReview
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class Folder
    {
        public int Size { get; set; }

        public static string Name { get; set; }

        static Folder()
        {
            Console.WriteLine("-- Folder static ctor executing -- ");
        }

        public Folder()
        {
        }

        public Folder(int size)
        {
            Size = size;
        }

        ~Folder() 
        {
            Console.WriteLine("-- Folder Finalizer finalizing -- ");
        }
    }
}
