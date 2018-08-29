namespace _07_DelegatesAndEvents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            return list.Where(element => !predicate(element)).ToList();
        }
    }
}