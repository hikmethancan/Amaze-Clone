using Concrete.Cells;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelData")]
    public class LevelSo : SerializedScriptableObject
    {
        [ShowInInspector]
        public Cell[,] cells;
            
    }
}
