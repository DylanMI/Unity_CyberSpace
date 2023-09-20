#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace CyberSpace.UnityEditor
{

    [CustomEditor(typeof(CyberSpaceManager))]
    public class CyberSpaceManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (GUILayout.Button("Generate Terrain"))
            {
                CyberSpaceManager.Instance.TerrainManager.Editor_GenerateTerrain(CyberSpaceTerrainType.Cube, new Vector3(), 100);
            }
            if (GUILayout.Button("Apply HeightMap"))
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