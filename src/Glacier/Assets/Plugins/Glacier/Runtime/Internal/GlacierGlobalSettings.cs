using UnityEngine;

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

        public GameObject UncaughtExceptionDialogPrefab;
    }
}