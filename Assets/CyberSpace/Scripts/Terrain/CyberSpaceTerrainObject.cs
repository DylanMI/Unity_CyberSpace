using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace CyberSpace
{
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

        public List<CyberSpaceTerrainObjectSocket> Sockets
        {
            get
            {
                if (_sockets.Count == 0)
                    _sockets = transform.GetComponentsInChildren<CyberSpaceTerrainObjectSocket>().ToList();

                return _sockets;
            }
        }
        private List<CyberSpaceTerrainObjectSocket> _sockets = new List<CyberSpaceTerrainObjectSocket>();
    }
}