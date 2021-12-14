using System.Diagnostics.CodeAnalysis;

namespace PtVzzlePrison.Tests
{
    internal class TripleComparer : IEqualityComparer<(int, int, int[][])> 
    {
        IListIListComparer<int> iListIListComparer = new IListIListComparer<int>();
        public bool Equals((int, int, int[][]) x, (int, int, int[][]) y)
        {
            return x.Item1 == y.Item1 && 
                x.Item2 == y.Item2 && 
                iListIListComparer.Equals(x.Item3, y.Item3);
        }

        public int GetHashCode([DisallowNull] (int, int, int[][]) obj)
        {
            return HashCode.Combine(
                obj.Item1, 
                obj.Item2, 
                iListIListComparer.GetHashCode(obj.Item3));
        }
    }
    internal class IListIListComparer<T> : IEqualityComparer<IList<IList<T>>>
    {
        public bool Equals(IList<IList<T>>? x, IList<IList<T>>? y)
        {
            if (x?.Count != y?.Count) return false;
            for (int i = 0; i < x?.Count; i++)
            {
                var xi = x[i];
                var yi = y[i]; 
                if (xi == null && yi == null) continue;
                if (xi == null) return false;
                if (xi.Count != yi.Count) return false;
                for (int j = 0; j < xi.Count; j++)
                {
                    var xij = xi[j];
                    var jij = yi[j];
                    if (xij == null && jij == null) continue;
                    if (xij == null) return false;
                    if (!xij.Equals(jij)) return false;
                }
            }
            return true;
        }

        public int GetHashCode([DisallowNull] IList<IList<T>> obj)
        {
            int result = 0;
            foreach (var item in obj)
            {
                foreach (var item2 in item)
                {
                    if (item2 != null)
                    {
                        HashCode.Combine(result, item2.GetHashCode());
                    }
                }
            }
            return result;
        }
    }
}
