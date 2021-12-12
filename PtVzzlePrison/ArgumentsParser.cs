namespace PtVzzlePrison
{
    internal class ArgumentsParser
    {
        internal const string WrongNumberOfArguments = "Wrong number of arguments, 1 expected, {0} found";
        internal const string FileDoesNotExist = "File {0} does not found";
        internal const string FileExist = "File {0} found";

        public static bool ValidateArguments(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine(string.Format(WrongNumberOfArguments,args.Length));
                return false;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine(string.Format(FileDoesNotExist, args[0]));
                return false;
            }
            Console.WriteLine(string.Format(FileExist, args[0]));
            return true;
        }
    }
}
