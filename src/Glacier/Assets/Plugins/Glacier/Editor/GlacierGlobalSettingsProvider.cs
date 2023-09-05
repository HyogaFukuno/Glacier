#if UNITY_EDITOR

using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

namespace Glacier.Internal
{
    public class GlacierGlobalSettingsProvider : SettingsProvider
    {
        #region variables

        private const string k_settingsPath = "Project/Glacier Global Settings";

        private Editor _editor = null;

        #endregion

        #region methods

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            return new GlacierGlobalSettingsProvider(k_settingsPath, SettingsScope.Project, null);
        }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="scopes"></param>
        /// <param name="keywords"></param>
        public GlacierGlobalSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords = null)
            : base(path, scopes, keywords)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchContext"></param>
        /// <param name="rootElement"></param>
        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            Editor.CreateCachedEditor(GlacierGlobalSettings.Instance, null, ref _editor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchContext"></param>
        public override void OnGUI(string searchContext)
        {
            var instance = GlacierGlobalSettings.Instance;
            if (null == instance)
            {
                if (GUILayout.Button("Initialize Glacier Global Settings",
                    GUILayout.Height(30.0f)))
                {
                    CreateSettings();
                    Editor.CreateCachedEditor(GlacierGlobalSettings.Instance, null, ref _editor);
                }

                return;
            }

            _editor.OnInspectorGUI();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CreateSettings()
        {
            var settings = ScriptableObject.CreateInstance<GlacierGlobalSettings>();
            var parent = "Assets/Resources";
            if (false == AssetDatabase.IsValidFolder(parent))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
            }

            var assetPath = Path.Combine(parent, Path.ChangeExtension(nameof(GlacierGlobalSettings), ".asset"));
            AssetDatabase.CreateAsset(settings, assetPath);
        }

        #endregion
    }
}

#endif