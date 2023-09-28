#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace CyberSpace.UnityEditor
{

    [CustomEditor(typeof(CyberSpaceManager))]
    public class CyberSpaceManagerEditor : Editor
    {
        public int Size = 100;
        public float HeightScale = 10f;
        public CyberSpaceTerrainType Type = CyberSpaceTerrainType.Hex;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Size = EditorGUILayout.IntField("Grid size", Size);
            HeightScale = EditorGUILayout.FloatField("Grid height scale", HeightScale);
            Type = (CyberSpaceTerrainType)EditorGUILayout.EnumPopup("Terrain type", Type);


            if (GUILayout.Button("Generate Terrain"))
            {
                CyberSpaceManager.Instance.TerrainManager.Editor_GenerateTerrain(Type, new Vector3(), Size);
            }
            if (GUILayout.Button($"Apply HeightMap"))
            {
                string path = EditorUtility.OpenFilePanel("Load  Heightmap", "", "");
                var rawData = System.IO.File.ReadAllBytes(path);
                Texture2D tex = new Texture2D(2, 2); // empty tex
                tex.LoadImage(rawData);

                CyberSpaceManager.Instance.TerrainManager.Editor_ApplyHeightMap(tex, HeightScale);
            }
            if (GUILayout.Button($"Apply Colormap"))
            {
                string path = EditorUtility.OpenFilePanel("Load  Colormap", "", "");
                var rawData = System.IO.File.ReadAllBytes(path);
                Texture2D tex = new Texture2D(2, 2); // empty tex
                tex.LoadImage(rawData);

                CyberSpaceManager.Instance.TerrainManager.Editor_ApplyColorMap(tex);
            }
            if (GUILayout.Button("Remove Terrain"))
            {
                CyberSpaceManager.Instance.TerrainManager.Editor_DeepClean();
            }
        }

    }
}
#endif