using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Glacier.ScreenSystems
{
    /// <summary>
    /// スクリーン基底クラス。
    /// </summary>
    public abstract class ScreenBase : IDisposable
    {
        #region variables

        private readonly GameObject _screenObject = null;

        #endregion

        #region properties

        public GameObject ScreenObject => this._screenObject;

        #endregion

        #region methods

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="screenObject"></param>
        public ScreenBase(GameObject screenObject)
        {
            _screenObject = screenObject;
        }

        /// <summary>
        /// 初期化処理。
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public abstract UniTask Initialize(CancellationToken cancellation);

        /// <summary>
        /// 一時停止処理。
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public abstract UniTask Suspend(CancellationToken cancellation);

        /// <summary>
        /// 再開処理。
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public abstract UniTask Resume(CancellationToken cancellation);

        /// <summary>
        /// 終了処理。
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public abstract UniTask Finalize(CancellationToken cancellation);

        /// <summary>
        /// 破棄された際の処理。
        /// </summary>
        public void Dispose()
        {
            UnityEngine.Object.Destroy(_screenObject);
        }

        #endregion
    }

    /// <summary>
    /// パラメータありのスクリーン基底クラス。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ScreenBase<T> : ScreenBase
    {
        protected ScreenBase(T parameter, GameObject screenObject)
            : base(screenObject) => Parameter = parameter;


        protected T Parameter { get; }
    }
}