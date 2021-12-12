namespace PtVzzlePrison
{
    internal static class IndexConverter
    {
        public static (int, int) ToMatrixIndices(this int index, int columns)
        {
            return Math.DivRem(index, columns);
        }
        public static int ToFlatIndex(this (int, int) matrixIndex, int columns)
        {
            return matrixIndex.Item1 * columns + matrixIndex.Item2;
        }
    }
}
