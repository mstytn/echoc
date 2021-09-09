using System;

namespace echoc
{
    public static class Arguments
    {
        /// <summary>
        /// Checks the commandline argumnets if not exists exits the process with -1 code,
        /// if exists and the first argument is help then shows help and exits the process with code 0.
        /// </summary>
        /// <param name="args">Just system argumnents to pass.</param>
        public static void CheckArguments(string[] args)
        {
            //Checks if any argument is exists.
            if (args.Length == 0)
                Environment.Exit(-1);
            //Checks if help requested.
            if (args.Length == 1)
            {
                if (string.Equals(args[0], "--help", StringComparison.OrdinalIgnoreCase) || string.Equals(args[0], "-h", StringComparison.OrdinalIgnoreCase) || string.Equals(args[0], "/h", StringComparison.OrdinalIgnoreCase) || string.Equals(args[0], "/?", StringComparison.OrdinalIgnoreCase))
                {
                    HelpDisplay.ShowHelp();
                    Environment.Exit(0);
                }
            }
        }
    }
}
