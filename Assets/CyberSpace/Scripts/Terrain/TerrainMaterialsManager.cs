using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainMaterialsManager
{
    [Serializable]
    public class TerrainMaterials
    {
        public Color BaseColor;
        public Material Material;

        public TerrainMaterials()
        {
            BaseColor = Color.white;
            Material = new Material(Shader.Find("Standard"));
            Material.SetColor("_Color", Color.white);
        }
        public TerrainMaterials(Color baseColor)
        {
            BaseColor = baseColor;
            Material = new Material(Shader.Find("Standard"));
            Material.SetColor("_Color", baseColor);
        }
    }
    private List<TerrainMaterials> _terrainMaterials = new List<TerrainMaterials>();
    public Material GetOrMakeMaterial(Color pixelColor)
    {
        Material retval;
        var terrainMaterial = _terrainMaterials.ToList().Find(x => x.BaseColor == pixelColor);
        // did not find a material in the list
        if (terrainMaterial == null)
        {
            _terrainMaterials.Add(new TerrainMaterials(pixelColor));
            retval = _terrainMaterials[^1].Material;
        }
        // did find a material in the list
        else
            retval = terrainMaterial.Material;

        return retval;
    }
}