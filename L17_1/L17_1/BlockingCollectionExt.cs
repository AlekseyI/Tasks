using System.Collections.Concurrent;

namespace L17_1
{
    public static class BlockingCollectionExt
    {
        public static void Clear<T>(this BlockingCollection<T> collection)
        {
            while (collection.Count > 0)
            {
                collection.Take();
            }
        }
    }
}