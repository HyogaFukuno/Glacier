using UnityEngine;

namespace Glacier.Internal
{
    /// <summary>
    /// キャッチしていない例外を処理するクラス。
    /// </summary>
    public class UncaughtExceptionHandler : MonoBehaviour
    {
        #region methods

        /// <summary>
        /// 例外をキャッチした際の処理。
        /// </summary>
        /// <param name="log"></param>
        /// <param name="stackTrace"></param>
        /// <param name="type"></param>
        protected virtual void HandleException(string log, string stackTrace, LogType type)
        {
            // 例外以外の場合は処理を終了する
            if (type != LogType.Exception)
            {
                return;
            }

            var instance = GameObject.Instantiate(GlacierGlobalSettings.Instance.UncaughtExceptionDialogPrefab);
            instance.transform.SetParent(transform, false);
        }

        /// <summary>
        /// 有効になった際の処理。
        /// </summary>
        private void OnEnable()
        {
            if (GlacierGlobalSettings.Instance is null
                || GlacierGlobalSettings.Instance.UncaughtExceptionDialogPrefab is null)
            {
                return;
            }

            Application.logMessageReceived += HandleException;
        }

        /// <summary>
        /// 無効になった際の処理。
        /// </summary>
        private void OnDisable()
        {
            if (GlacierGlobalSettings.Instance is null
                || GlacierGlobalSettings.Instance.UncaughtExceptionDialogPrefab is null)
            {
                return;
            }

            Application.logMessageReceived -= HandleException;
        }

        #endregion
    }
}