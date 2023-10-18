#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace CyberSpace
{
    public class CyberSpaceManager : Singleton<CyberSpaceManager>
    {
#if UNITY_EDITOR
        [MenuItem("CyberSpace/Create/CyberSpaceManager")]
        static void CreateCyberSpaceManager()
        {
            GameObject go = new GameObject("CYS_CyberSpaceManager");
            go.AddComponent<CyberSpaceManager>();
        }
#endif

        #region Properties
        public CyberSpaceSettingsSO Settings { get => _settings; set => _settings = value; }
        public CyberSpaceTerrainManager TerrainManager { get => _terrainManager ??= new CyberSpaceTerrainManager(); }
        public CyberSpaceSoundManager SoundManager { get => _soundManager ??= new CyberSpaceSoundManager(); }
        public CyberSpaceEffectsManager EffectsManager { get => _effectsManager ??= new CyberSpaceEffectsManager(); }

        #endregion

        #region privates
        [SerializeField] private CyberSpaceSettingsSO _settings = null;
        private CyberSpaceTerrainManager _terrainManager = null;
        private CyberSpaceSoundManager _soundManager = null;
        private CyberSpaceEffectsManager _effectsManager = null;
        #endregion
    }

}
