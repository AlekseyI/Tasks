using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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