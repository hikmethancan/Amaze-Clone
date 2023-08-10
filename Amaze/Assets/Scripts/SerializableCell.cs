using Concrete.Cells;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[System.Serializable]
public class SerializableCell
{
    [OdinSerialize,ShowInInspector]
    public Cell[,] cells;
}
