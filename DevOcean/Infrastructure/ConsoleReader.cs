using DevOcean.Infrastructure.Interfaces;
using System;

namespace DevOcean.Infrastructure
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
