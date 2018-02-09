using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vyber_mien
{
    public static class Extensions
    {
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }

        public static void MoveUp<T>(this IList<T> list, T element)
        {
            var index = list.IndexOf(element);
            if (index <= 0)
            {
                return;
            }

            list.Swap<T>(index, index - 1);
        }

        public static void MoveDown<T>(this IList<T> list, T element)
        {
            var index = list.IndexOf(element);
            if (index < 0 || index == list.Count - 1)
            {
                return;
            }

            list.Swap<T>(index, index + 1);
        }
    }
}
