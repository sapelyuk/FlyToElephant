using System;

namespace FlyToElephant
{
    /// <summary>
    /// Программа, которая делает из мухи слона.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var finder = new ChainFinder();
            finder.FindAllWords();
            Console.ReadLine();
        }
    }
}
