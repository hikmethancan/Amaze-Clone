using System.Collections.Generic;
using Concrete.Cells;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Concrete.Managers
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private List<Cell> cells;
        [SerializeField] private Cell cellPrefab;
        [SerializeField] private int cellRow;
        [SerializeField] private int cellCol;

        [Button]
        public void CreateCells()
        {
            cells.Clear();
            for (int x = 0; x < cellRow; x++)
            {
                for (int y = 0; y < cellCol; y++)
                {
                    Vector3 cellPosition = new Vector3(x, y, 0);
                    var gridCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity, transform);
                    cells.Add(gridCell);
                }
            }
        }

        [Button]
        public void DeleteCells()
        {
            foreach (var cell in cells)
            {
                DestroyImmediate(cell.gameObject);
            }
            cells.Clear();
        }
    }
}