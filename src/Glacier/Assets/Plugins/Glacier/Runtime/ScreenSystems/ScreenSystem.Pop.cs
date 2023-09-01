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
        /// 手前のスクリーンを取り除く処理。
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async UniTask Pop(CancellationToken cancellation = default)
        {
            cancellation.ThrowIfCancellationRequested();

            // 所持しているスクリーンがない場合は処理を終了する
            if (_screens.Empty())
            {
                return;
            }

            // 現在手前にあるスクリーンを取り除いて処理を一時中断し
            // スクリーンの終了処理を実行する
            var popScreen = _screens.Pop();

            await popScreen.Suspend(cancellation);

            cancellation.ThrowIfCancellationRequested();

            await popScreen.Finalize(cancellation);

            cancellation.ThrowIfCancellationRequested();

            // 所持しているスクリーンがない場合は処理を終了する
            if (_screens.Empty())
            {
                return;
            }

            // 現在手前にあるスクリーンを取得して処理を再開する
            var resumeScreen = _screens.Peek();

            await resumeScreen.Resume(cancellation);

            cancellation.ThrowIfCancellationRequested();
        }

        /// <summary>
        /// 手前にあるスクリーンを取り除く処理。(指定の数分)
        /// </summary>
        /// <param name="count"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async UniTask Pop(int count, CancellationToken cancellation = default)
        {
            for (int num = 0; num < count; ++num)
            {
                await Pop(cancellation);
            }
        }

        /// <summary>
        /// 手前にあるスクリーンを取り除く処理。(指定の数分を並列に処理する)
        /// </summary>
        /// <param name="count"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async UniTask PopInstantly(int count, CancellationToken cancellation = default)
        {
            cancellation.ThrowIfCancellationRequested();

            var pops = new List<ScreenBase>();
            var suspendTasks = new List<UniTask>();
            var finalizeTasks = new List<UniTask>();

            // 指定の数分スクリーンを取り除いて各タスクをリストに追加する
            for (int num = 0; num < count; ++num)
            {
                if (_screens.Empty())
                {
                    break;
                }

                var pop = _screens.Pop();

                suspendTasks.Add(pop.Suspend(cancellation));
                finalizeTasks.Add(pop.Finalize(cancellation));
                pops.Add(pop);
            }

            cancellation.ThrowIfCancellationRequested();

            await UniTask.WhenAll(suspendTasks);

            cancellation.ThrowIfCancellationRequested();

            await UniTask.WhenAll(finalizeTasks);

            cancellation.ThrowIfCancellationRequested();

            // 現時点で所持しているスクリーンがない場合は処理を終了する
            if (_screens.Empty())
            {
                return;
            }

            // 現在手前にあるスクリーンを取得して処理を再開する
            var resumeScreen = _screens.Peek();

            await resumeScreen.Resume(cancellation);

            cancellation.ThrowIfCancellationRequested();
        }

        #endregion
    }
}