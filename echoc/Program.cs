using System;

namespace echoc
{
    static class Program
    {
        static void Main(string[] args)
        {
            Arguments.CheckArguments(args);
            Colorize.Run(args);
            Environment.Exit(0);
        }
    }
}
