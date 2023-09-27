using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CyberSpace
{
    /// <summary>
    /// Handles the CyberSpace terrain, this manager handles the generation of the terrain as well as any terrain changes
    /// </summary>
    public class CyberSpaceTerrainManager
    {
        private CyberSpaceTerrainType _currentTerrainType = CyberSpaceTerrainType.Cube;
        private CyberSpaceTerrain _currentTerrain = null;

        public TerrainMaterialsManager MaterialsManager { get; private set; }

        /// <summary>
        /// Generates the CyberSpaceTerrain, if there is already one it will destroy the previous one
        /// </summary>
        public void GenerateTerrain(Vector3 startPos, int radius)
        {
            MaterialsManager = new();
            if (_currentTerrain != null)
                DestroyTerrain();
            else
            {
                GameObject go = new GameObject("CYS_Terrain");
                _currentTerrain = go.AddComponent<CyberSpaceTerrain>();
            }
            _currentTerrain.Generate(_currentTerrainType, startPos, radius);
        }

        /// <summary>
        /// Generates the CyberSpaceTerrain, if there is already one it will destroy the previous one
        /// </summary>
        /// <param name="terrainType">The requested terrain type</param>
        public void GenerateTerrain(CyberSpaceTerrainType terrainType, Vector3 startPos, int radius)
        {
            _currentTerrainType = terrainType;
            GenerateTerrain(startPos, radius);
        }


        public void ApplyHeightMap(Texture2D tex)
        {
            _currentTerrain.ApplyHeightMap(tex);
        }

        /// <summary>
        /// Destroys the CyberSpaceTerrain
        /// </summary>
        public void DestroyTerrain()
        {
            _currentTerrain?.Destroy();
        }

#if UNITY_EDITOR
        internal void Editor_GenerateTerrain(CyberSpaceTerrainType terrainType, Vector3 startPos, int radius)
        {
            Editor_DeepClean();

            _currentTerrainType = terrainType;
            GenerateTerrain(startPos, radius);
        }
        internal void Editor_ApplyHeightMap(Texture2D tex)
        {
            CyberSpaceTerrain terrain = Editor.FindObjectOfType<CyberSpaceTerrain>();
            terrain.ApplyHeightMap(tex);
        }
        internal void Editor_ApplyColorMap(Texture2D tex)
        {
            CyberSpaceTerrain terrain = Editor.FindObjectOfType<CyberSpaceTerrain>();
            terrain.ApplyColorMap(tex);
        }
        internal void Editor_DeepClean()
        {
            var terrains = Editor.FindObjectsOfType<CyberSpaceTerrain>().ToList();
            foreach (var terrain in terrains)
            {
                GameObject.DestroyImmediate(terrain.gameObject);
            }
            var terrainObjects = Editor.FindObjectsOfType<CyberSpaceTerrainObject>().ToList();
            foreach (var terrainObject in terrainObjects)
            {
                GameObject.DestroyImmediate(terrainObject.gameObject);
            }
        }
#endif
    }
}
