using UnityEngine;
using UnityEditor;

namespace CyberSpace
{
    [CreateAssetMenu(menuName = "CyberSpace/ScriptableObjects/MasterSettings")]
    public class CyberSpaceSettingsSO : ScriptableObject
    {
        public CyberSpacePrimitivesSO PrimitivesSet = null;
    }
}