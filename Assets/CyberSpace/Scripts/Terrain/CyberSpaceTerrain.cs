using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpace
{
    public class CyberSpaceTerrain : MonoBehaviour
    {
        Dictionary<Vector3, CyberSpaceTerrainObject> _grid = new Dictionary<Vector3, CyberSpaceTerrainObject>();

        internal void Generate(CyberSpaceTerrainType currentTerrainType, Vector3 startPos, int radius)
        {
            switch (currentTerrainType)
            {
                case CyberSpaceTerrainType.Cube:
                    GenerateCubeTerrain(startPos, radius);
                    break;

                case CyberSpaceTerrainType.Hex:
                    GenerateHexTerrain(startPos, radius);
                    break;

                default:
                    break;
            }
        }

        internal void ApplyHeightMap(Texture2D tex)
        {
            const int SCALEVARIABLE = 10;
            int counter = 0;
            foreach (var terrainObject in _grid)
            {
                Color pixelColor = tex.GetPixel(Convert.ToInt32(counter % Math.Sqrt(_grid.Count)), Convert.ToInt32(counter / Math.Sqrt(_grid.Count)));
                float avg = (pixelColor.r + pixelColor.g + pixelColor.b) / 3f;
                terrainObject.Value.transform.localScale = new Vector3(1f, SCALEVARIABLE * avg, 1f);

                counter++;
            }

        }

        private void GenerateCubeTerrain(Vector3 startPos, int radius)
        {
            throw new NotImplementedException();
        }

        Vector3 CalculateCubePosition(int x, int y)
        {
            return new Vector3(0f, 0f, 0f);
        }
        private void GenerateHexTerrain(Vector3 startPos, int radius)
        {
            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    Vector3 hexPosition = startPos + CalculateHexPosition(x, y);

                    GameObject gridObj = GameObject.Instantiate(CyberSpaceManager.Instance.Settings.PrimitivesSet._hexPrimitive.gameObject);
                    gridObj.transform.position = hexPosition;
                    gridObj.transform.parent = this.transform;
                    gridObj.name = $"GridObj[{x}|{y}]";
                    _grid[hexPosition] = gridObj.GetComponent<CyberSpaceTerrainObject>();
                }
            }
        }

        Vector3 CalculateHexPosition(int x, int y)
        {
            // Calculate the position of the hex based on its grid coordinates
            float width = 1.752f * CyberSpaceManager.Instance.Settings.PrimitivesSet._hexPrimitive.transform.localScale.x;
            float height = 1.5f * CyberSpaceManager.Instance.Settings.PrimitivesSet._hexPrimitive.transform.localScale.y;

            float xPos = x * width + (y % 2 == 1 ? width / 2f : 0f);
            float yPos = y * height;

            return new Vector3(xPos, -CyberSpaceManager.Instance.Settings.PrimitivesSet._hexPrimitive.transform.localScale.y, yPos);
        }

        internal void Destroy()
        {
            foreach (var item in _grid)
            {
                Destroy(item.Value.gameObject);
            }
            _grid = new();
        }


    }
}