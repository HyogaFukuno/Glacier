using UnityEngine;
using Sirenix.OdinInspector;

namespace Glacier.Internal
{
    public class GlacierGlobalSettings : ScriptableObject
    {
        #region instances

        private static GlacierGlobalSettings _instance;

        public static GlacierGlobalSettings Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = Resources.Load<GlacierGlobalSettings>(nameof(GlacierGlobalSettings));
                }

                return _instance;
            }
        }

        #endregion

        [InfoBox("実行中に予期せぬエラーが発生した際にユーザーに通知するダイアログを指定してください。\nプレハブはCanvasを持ち、子にダイアログを持つプレハブを指定してください。", InfoMessageType.Info)]
        public GameObject UncaughtExceptionDialogPrefab;
    }
}