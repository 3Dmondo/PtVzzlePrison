namespace PtVzzlePrison
{
    internal static class FileParser
    {
        internal const string FileTooShort = "File {0} has less the 2 rows";
        internal const string EntryNodeClosed = "File {0} is not valid, node (0, 0) must be open";
        internal const string ExitNodeClosed = "File {0} is not valid, node ({1}, {2}) must be open";
        internal const string InvlaidChars = "File {0} has invalid characters, only \"0\" and \"1\" allowed";
        internal const string AllRowMustBeEqual = "File {0} is not valid, all rows must be of equal lenght";

        public static int[][]? Parse(string fileName)
        {
            var result = new List<int[]>();
            using var sr = new StreamReader(fileName);
            var line = sr.ReadLine();
            while (line != null)
            {
                var elements = line.Split(" ");
                if (elements.Any(e => !(e == "0" || e == "1")))
                {
                    Console.WriteLine(string.Format(InvlaidChars, fileName));
                    return null;
                }
                result.Add(elements.Select(x => int.Parse(x)).ToArray());
                line = sr.ReadLine();
            }
            if (result.Count < 2)
            {
                Console.WriteLine(string.Format(FileTooShort, fileName));
                return null;
            }
            if (result[0][0] == 0)
            {
                Console.WriteLine(string.Format(EntryNodeClosed, fileName));
                return null;
            }
            var rows = result.Count;
            var columns = result[rows - 1].Length;
            if (result[rows - 1][columns - 1] == 0)
            {
                Console.WriteLine(string.Format(ExitNodeClosed, fileName));
                return null;
            }
            for (int i = 1; i < rows; i++)
            {
                if (result[i - 1].Length != result[i].Length)
                {
                    Console.WriteLine(string.Format(AllRowMustBeEqual, fileName));
                    return null;
                }
            }
            return result.ToArray();
        }
    }
}
