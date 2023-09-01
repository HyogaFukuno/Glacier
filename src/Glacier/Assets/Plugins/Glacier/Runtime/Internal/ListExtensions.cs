using System.Collections;
using System.Collections.Generic;

namespace Glacier.Internal
{
    internal static class ListExtensions
    {
        #region methods

        /// <summary>
        /// 要素を最前列にプッシュする処理。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="item"></param>
        public static void Push<T>(this IList<T> self, T item)
        {
            self.Insert(0, item);
        }

        /// <summary>
        /// 最前列の要素を取り除く処理。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static T Pop<T>(this IList<T> self)
        {
            var result = self[0];
            self.RemoveAt(0);
            return result;
        }

        /// <summary>
        /// 最前列の要素を取得する処理。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static T Peek<T>(this IList<T> self)
        {
            return self[0];
        }

        /// <summary>
        /// 空かどうかの有無を取得する処理。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool Empty<T>(this IList<T> self)
        {
            return self.Count <= 0;
        }

        #endregion
    }
}