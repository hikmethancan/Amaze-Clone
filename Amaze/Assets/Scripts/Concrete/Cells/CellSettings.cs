using System;
using Abstract.Enums;
using UnityEngine;

namespace Concrete.Cells
{
    [Serializable]
    public class CellSettings
    {
        public CellType cellType;
        public Color cellFloorColor;
        public Color cellObstacleColor;
        public Color cellBaseObstacleColor;
        public Color cellBaseFloorColor;
        
    }
}