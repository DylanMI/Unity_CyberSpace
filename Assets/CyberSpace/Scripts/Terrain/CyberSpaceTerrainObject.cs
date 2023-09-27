using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberSpaceTerrainObject : MonoBehaviour
{
    public Material TerrainObjectMaterial
    {
        get
        {
            if (_terrainObjectMaterial == null)
                _terrainObjectMaterial = GetComponent<MeshRenderer>().sharedMaterial;

            return _terrainObjectMaterial;
        }
        set
        {
            GetComponent<MeshRenderer>().sharedMaterial = value;
        }
    }
    private Material _terrainObjectMaterial;
}
