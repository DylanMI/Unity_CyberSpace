using UnityEngine;

namespace CyberSpace
{
    public class CyberSpaceTerrainObjectSocket : MonoBehaviour
    {
        private CyberSpaceTerrainObject _parentTerrainObject = null;
        private Transform _socketedTransform = null;

        /// <summary>
        /// Attempts to set the parentTerrainObject of this socket
        /// </summary>
        /// <param name="parentObject"></param>
        /// <returns>returns false if there is already a parent, returns true if setting the parent was succesfull</returns>
        public bool TrySetParentTerrainObject(CyberSpaceTerrainObject parentObject)
        {
            if (_parentTerrainObject != null)
            {
                Debug.LogWarning($"CyberSpaceTerrainObjectSocket::TrySetParentTerrainObject() -> {parentObject.name} tried taking over from {_parentTerrainObject.name}");
                return false;
            }
            _parentTerrainObject = parentObject;
            transform.parent = _parentTerrainObject.transform;
            return true;
        }

        /// <summary>
        /// Attempts to remove the parentTerrainObject of this socket
        /// </summary>
        /// <returns>returns false if there is no parent, returns true if succesfully orphaned</returns>
        public bool TryRemoveParentTerrainObject()
        {
            if (_parentTerrainObject == null)
            {
                Debug.LogWarning($"CyberSpaceTerrainObjectSocket::TryRemoveParentTerrainObject() -> tried removing null");
                return false;
            }
            _parentTerrainObject = null;
            transform.parent = null;
            return true;
        }

        /// <summary>
        /// Attempts to set the socketed transform
        /// </summary>
        /// <param name="transformToSocket"></param>
        /// <returns>returns false if there is already a socketed transform, returns true if setting the socketed transform was succesfull</returns>
        public bool TrySocketTransform(Transform transformToSocket)
        {
            if (_socketedTransform != null)
            {
                Debug.LogWarning($"CyberSpaceTerrainObjectSocket::TrySocketTransform() -> {transformToSocket.name} tried taking over from {_socketedTransform.name}");
                return false;
            }
            _socketedTransform = transformToSocket;
            _socketedTransform.parent = transform;
            _socketedTransform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            return true;
        }

        /// <summary>
        /// Attempts to remove the socketed transform of this socket
        /// </summary>
        /// <returns>returns false if there is no socketed transform, returns true if succesfully removed</returns>
        public bool TryUnsocketTransform()
        {
            if (_socketedTransform == null)
            {
                Debug.LogWarning($"CyberSpaceTerrainObjectSocket::TryUnsocketTransform() -> tried unsocketing null");
                return false;
            }
            _socketedTransform.parent = transform;
            _socketedTransform = null;
            return true;
        }
    }
}