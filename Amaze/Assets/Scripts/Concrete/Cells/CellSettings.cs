using System;
using Abstract.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Concrete.Cells
{
    [Serializable]
    public class CellSettings
    {
        [ShowInInspector]
        public CellType cellType { get; set; }
        public Color cellFloorColor;
        public Color cellObstacleColor;
        public Color cellBaseObstacleColor;
        public Color cellBaseFloorColor;
        
    }
}