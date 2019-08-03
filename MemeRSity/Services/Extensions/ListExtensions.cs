using System;
using System.Collections.Generic;

namespace MemeRSity.Services.Extensions
{
    public static class ListExtensions
    {
        public static void RemoveMatches<T>(this List<T> list, List<T> anotherList, Func<T,T, bool> maxPredicate)
        {
            foreach (var l in anotherList)
            {
                list.RemoveAll(m => maxPredicate.Invoke(l,m));
            }
        }
    }
}