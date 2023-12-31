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

        public CyberSpaceTerrain CurrentTerrain
        {
            get
            {
                if (_currentTerrain == null)
                    _currentTerrain = GameObject.FindObjectOfType<CyberSpaceTerrain>();

                return _currentTerrain;
            }
        }
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


        /// <summary>
        /// Applies a greyscale heightmap to the CyberSpaceTerrain, scaling that terrain
        /// </summary>
        /// <param name="tex"></param>
        public void ApplyHeightMap(Texture2D tex, float heightScale)
        {
            CurrentTerrain.ApplyHeightMap(tex, heightScale);
        }

        /// <summary>
        /// Applies a color to the CyberSpaceTerrain using a color map
        /// </summary>
        /// <param name="tex"></param>
        public void ApplyColorMap(Texture2D tex)
        {
            CurrentTerrain.ApplyColorMap(tex);
        }

        /// <summary>
        /// Destroys the CyberSpaceTerrain
        /// </summary>
        public void DestroyTerrain()
        {
            CurrentTerrain.Destroy();
        }

        public CyberSpaceTerrainObject GetGridObjectAtCoordinate(Vector2Int coordinate)
        {
            return CurrentTerrain.GetGridObjectAtCoordinate(coordinate);
        }

#if UNITY_EDITOR
        internal void Editor_GenerateTerrain(CyberSpaceTerrainType terrainType, Vector3 startPos, int radius)
        {
            Editor_DeepClean();

            _currentTerrainType = terrainType;
            GenerateTerrain(startPos, radius);
        }
        internal void Editor_ApplyHeightMap(Texture2D tex, float heightScale)
        {
            CyberSpaceTerrain terrain = Editor.FindObjectOfType<CyberSpaceTerrain>();
            terrain.ApplyHeightMap(tex, heightScale);
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
