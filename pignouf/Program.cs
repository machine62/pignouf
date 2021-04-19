using System;

namespace pignouf
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string cmdString = Console.ReadLine();
                
                if (cmdString != null && cmdString != "")
                {
                    Console.WriteLine(cmdString);
                }

            } while (true);

        }
    }
}
