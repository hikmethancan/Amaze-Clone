using System;
using Abstract.Enums;
using Concrete.Cells;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Concrete.Managers
{
    [ExecuteInEditMode]
    public class Level : MonoBehaviour
    {
        [TableList, ShowInInspector] private Cell[,] cells;

        [SerializeField] private Cell cellPrefab;
        [SerializeField] private int cellRow;
        [SerializeField] private int cellCol;

        [Button]
        public void CreateCells()
        {
            DeleteCells();
            cells = new Cell[cellRow, cellCol];
            for (int x = 0; x < cellRow; x++)
            {
                for (int y = 0; y < cellCol; y++)
                {
                    Vector3 cellPosition = new Vector3(x, y, 0);

                    var gridCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity, transform);
                    gridCell.x = x;
                    gridCell.y = y;
                    gridCell.CellSetup();
                    // Every border have to be obstacle
                    if (x < cells.GetLength(0) && y == 0)
                    {
                        gridCell.cellSettings.cellType = CellType.Obstacle;
                    }
                    if (y == cells.GetLength(1) && x < cells.GetLength(0))
                    {
                        gridCell.cellSettings.cellType = CellType.Obstacle;
                    }

                    if (x == 0 || y == 0)
                        gridCell.cellSettings.cellType = CellType.Obstacle;
                    
                    cells[x, y] = gridCell;
                }
            }
        }

        [Button]
        public void DeleteCells()
        {
            if (cells is null) return;
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    Debug.Log(cells[x, y]);
                    if (cells[x, y] is not null && cells[x, y].gameObject.activeInHierarchy)
                        DestroyImmediate(cells[x, y].gameObject);
                }
            }

            if (cells is not null)
                Array.Clear(cells, 0, cells.Length);
        }

        [Button]
        public void SetupCells()
        {
            if (cells is null) return;
            foreach (var cell in cells)
            {
                if (cell is not null)
                    cell.CellSetup();
            }
        }
    }
}