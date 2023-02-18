namespace ConsoleApp1.LangReview
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;

    public class StreamsIntro
    {
        public void FileInputOutput(string filename)
        {
            using (Stream s = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Console.WriteLine($"CanRead: {s.CanRead}");
                Console.WriteLine($"CanWrite: {s.CanWrite}");
                Console.WriteLine($"CanSeek: {s.CanSeek}");

                s.WriteByte(201);
                s.WriteByte(65);
                byte[] byteBlock = { 1, 2, 3, 4, 5 };
                s.Write(byteBlock, 0, byteBlock.Length);

                Console.WriteLine($"Length: {s.Length}");

                s.Position = 0; // move back to starting position
                Console.Write(" [0]: ", s.ReadByte()); // 201
                Console.Write(" [1]: ", s.ReadByte()); // 65
                
                Console.Write('\n');

                byte[] byteBlock2 = new byte[5];
                Console.WriteLine(s.Read(byteBlock2, 0, byteBlock2.Length));

                Console.WriteLine("we are at the end of the stream");
                Console.WriteLine(s.Read(byteBlock2, 0, byteBlock2.Length));
            }
        }
    }
}
