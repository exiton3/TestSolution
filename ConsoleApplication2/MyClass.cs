using System;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    static class MyClass
    {
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> pred)
        {
            foreach (var item in source)
            {
                if (pred(item))
                {
                    yield return item;
                }
            }   
        }
    }
}