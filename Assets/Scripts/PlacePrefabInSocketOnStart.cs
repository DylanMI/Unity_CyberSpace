using CyberSpace;
using UnityEngine;

public class PlacePrefabInSocketOnStart : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabToSpawn;

    private void Start()
    {
        _ = transform.GetComponent<CyberSpaceTerrainObject>().Sockets[0].TrySocketTransform(GameObject.Instantiate(_prefabToSpawn).transform);
    }

}
