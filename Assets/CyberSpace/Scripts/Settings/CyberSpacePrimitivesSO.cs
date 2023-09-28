using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpace
{
    [CreateAssetMenu(menuName = "CyberSpace/ScriptableObjects/PrimitiveSet")]
    public class CyberSpacePrimitivesSO : ScriptableObject
    {
        public CyberSpaceTerrainObject CubePrimitive;
        public CyberSpaceTerrainObject HexPrimitive;
    }
}