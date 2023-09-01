using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Glacier.Samples
{
    public class ExceptionDialog : MonoBehaviour
    {
        #region variables

        [SerializeField] private Button _exitButton;

        #endregion

        #region methods

        private void Awake()
        {
            _exitButton?.onClick.AddListener(() => OnQuitApplication());
        }

        /// <summary>
        /// アプリケーションを終了する処理。
        /// </summary>
        private void OnQuitApplication()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        #endregion
    }
}