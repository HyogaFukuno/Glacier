using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace Glacier.ScreenSystems
{
    /// <summary>
    /// スクリーンの遷移基底クラス。
    /// ・このクラスが実際のスクリーンの読み込み処理を担当します。
    /// ・スクリーンの生成処理はこのクラスだけで完結するように設計します。
    /// </summary>
    /// <typeparam name="TScreen"></typeparam>
    public class ScreenTransitionBase<TScreen> : IScreenTransition where TScreen : ScreenBase
    {
        #region methods

        /// <summary>
        /// スクリーンを読み込む処理。
        /// ・本基底クラスではスクリーンプレハブの読み込みにAddressablesを使用します。
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        /// <exception cref="LifetimeScopeNotFoundException"></exception>
        /// <exception cref="ContainerResolveException"></exception>
        public virtual async UniTask<ScreenBase> LoadScreen(CancellationToken cancellation)
        {
            cancellation.ThrowIfCancellationRequested();

            // TODO: await Addressables.LoadAsync<GameObject>();

            cancellation.ThrowIfCancellationRequested();

            var instance = GameObject.Instantiate(new GameObject());
            if (!instance.TryGetComponent<LifetimeScope>(out var scope))
            {
                throw new LifetimeScopeNotFoundException();
            }

            InitializeScreenParameter(scope);

            scope.Build();

            if (scope.Container.Resolve(typeof(TScreen)) is not TScreen screen)
            {
                throw new ContainerResolveException();
            }

            return screen;
        }

        protected virtual void InitializeScreenParameter(LifetimeScope scope) { }

        #endregion
    }

    /// <summary>
    /// パラメータ指定がされたスクリーンの遷移基底クラス。
    /// </summary>
    /// <typeparam name="TScreen"></typeparam>
    /// <typeparam name="TParam"></typeparam>
    public class ScreenTransitionBase<TScreen, TParam> : ScreenTransitionBase<TScreen> where TScreen : ScreenBase<TParam>
    {
        #region properties

        public TParam Parameter { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// LifetimeScopeのパラメータを初期化する処理。
        /// </summary>
        /// <param name="scope"></param>
        protected override void InitializeScreenParameter(LifetimeScope scope)
        {
            if (scope is LifetimeScopeParameter<TParam> s)
            {
                s.Parameter = Parameter;
            }
        }

        #endregion
    }
}