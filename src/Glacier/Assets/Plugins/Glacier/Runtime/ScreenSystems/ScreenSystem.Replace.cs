using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Glacier.Internal;

namespace Glacier.ScreenSystems
{
    public partial class ScreenSystem
    {
        #region methods

        /// <summary>
        /// 手前にあるスクリーンと指定のスクリーンを入れ替える処理。
        /// </summary>
        /// <param name="transition"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async UniTask Replace(IScreenTransition transition, CancellationToken cancellation = default)
        {
            await Pop(cancellation);
            await Push(transition, cancellation);
        }

        /// <summary>
        /// 手前にあるスクリーンと指定のスクリーンを入れ替える処理。(指定の数分)
        /// </summary>
        /// <param name="count"></param>
        /// <param name="transition"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async UniTask Replace(int count, IScreenTransition transition, CancellationToken cancellation = default)
        {
            await Pop(count, cancellation);
            await Push(transition, cancellation);
        }

        /// <summary>
        /// 所持しているスクリーン全てと指定のスクリーンを入れ替える処理。
        /// </summary>
        /// <param name="transition"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async UniTask ReplaceAll(IScreenTransition transition, CancellationToken cancellation = default)
        {
            await PopInstantly(_screens.Count, cancellation);
            await Push(transition, cancellation);
        }

        #endregion
    }
}