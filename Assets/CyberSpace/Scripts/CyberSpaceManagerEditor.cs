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
        public CyberSpaceTerrainType Type = CyberSpaceTerrainType.Hex;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Size = EditorGUILayout.IntField("Grid size", Size);
            Type = (CyberSpaceTerrainType)EditorGUILayout.EnumPopup("Terrain type", Type);


            if (GUILayout.Button("Generate Terrain"))
            {
                CyberSpaceManager.Instance.TerrainManager.Editor_GenerateTerrain(Type, new Vector3(), Size);
            }
            if (GUILayout.Button($"Apply HeightMap[{Size}PX x {Size}PX]"))
            {
                string path = EditorUtility.OpenFilePanel("Load  Heightmap", "", "");
                var rawData = System.IO.File.ReadAllBytes(path);
                Texture2D tex = new Texture2D(2, 2); // empty tex
                tex.LoadImage(rawData);

                CyberSpaceManager.Instance.TerrainManager.Editor_ApplyHeightMap(tex);
            }
            if (GUILayout.Button("Remove Terrain"))
            {
                CyberSpaceManager.Instance.TerrainManager.Editor_DeepClean();
            }
        }

    }
}
#endif