using System;
using System.Collections.Generic;

namespace Glacier.ScreenSystems
{
    /// <summary>
    /// スクリーンをスタック構造で管理して表示、非表示を扱うシステムクラス。
    /// </summary>
    public partial class ScreenSystem : IScreenSystem, IDisposable
    {
        #region variables

        private static List<ScreenBase> _screens = null;

        #endregion

        #region methods

        /// <summary>
        /// 初期化処理。
        /// </summary>
        public ScreenSystem()
        {
            _screens = new List<ScreenBase>();
        }

        /// <summary>
        /// 終了処理。
        /// </summary>
        public void Dispose()
        {
            _screens.Clear();
            _screens = null;
        }

        #endregion
    }
}