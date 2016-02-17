using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtensionLibrary
{
    public static class ArrayExtensionLib<T>
    {

        public static List<T> Intersect(List<T> firstList, List<T> secondList)
        {
            List<T> result = new List<T>();

            foreach (var item in firstList)
            {
                result.Add(item);
            }
            foreach (var item in firstList)
            {
                if (!secondList.Contains(item))
                {
                    result.Remove(item);
                }
            }
            result.Sort();
            return result;
        }


        public static List<T> UnionAll(List<T> firstList, List<T> secondList)
        {
            List<T> result = new List<T>();

            foreach (var item in firstList)
            {
                result.Add(item);
            }
            foreach (var item in secondList)
            {
                result.Add(item);
            }
            result.Sort();
            return result;
        }

        public static List<T> Union(List<T> firstList, List<T> secondList)
        {
            List<T> result = new List<T>();

            foreach (var item in firstList)
            {
                result.Add(item);
            }
            foreach (var item in secondList)
            {
                if (!firstList.Contains(item))
                {
                    result.Add(item);
                }
            }
            result.Sort();
            return result;

        }

    }
}
