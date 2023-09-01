using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Glacier.Internal;

namespace Glacier.ScreenSystems
{
    public partial class ScreenSystem
    {
        #region methods

        /// <summary>
        /// 新しいスクリーンをプッシュする処理。
        /// </summary>
        /// <param name="transition"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async UniTask Push(IScreenTransition transition, CancellationToken cancellation = default)
        {
            cancellation.ThrowIfCancellationRequested();

            var newScreen = await transition.LoadScreen(cancellation);

            cancellation.ThrowIfCancellationRequested();

            if (!_screens.Empty())
            {
                var frontScreen = _screens.Peek();
                await frontScreen.Suspend(cancellation);
            }

            await newScreen.Initialize(cancellation);

            _screens.Push(newScreen);

            cancellation.ThrowIfCancellationRequested();
        }

        #endregion
    }
}