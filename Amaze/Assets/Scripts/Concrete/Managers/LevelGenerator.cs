using System;
using Abstract.Enums;
using Concrete.Cells;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Concrete.Managers
{
    [ExecuteInEditMode]
    public class LevelGenerator : MonoBehaviour
    {
        [ShowInInspector] private Cell[,] _cells;

        [SerializeField] private Cell cellPrefab;
        [SerializeField] private int cellRow;
        [SerializeField] private int cellCol;
        
        [Button]
        public void CreateCells()
        {
            DeleteCells();
            _cells = new Cell[cellRow, cellCol];
            Debug.Log(_cells.GetLength(0));
            
            
            Debug.Log(_cells.GetLength(1));
            for (int x = 0; x < cellRow; x++)
            {
                for (int y = 0; y < cellCol; y++)
                {
                    Vector3 cellPosition = new Vector3(x, y, 0);

                    var gridCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity, transform);
                    gridCell.x = x;
                    gridCell.y = y;
                    gridCell.CellSetup();
                    // Every border and edges have to be obstacle
                    if (x < (_cells.GetLength(0) - 1) && y == 0)
                        gridCell.cellSettings.cellType = CellType.Obstacle;
                    if (y == (_cells.GetLength(1) - 1) && x < _cells.GetLength(0))
                        gridCell.cellSettings.cellType = CellType.Obstacle;
                    if (x == (_cells.GetLength(0) - 1) && y < _cells.GetLength(1))
                        gridCell.cellSettings.cellType = CellType.Obstacle;
                    if (x == 0 || y == 0)
                        gridCell.cellSettings.cellType = CellType.Obstacle;
                    // Set the instantiated cell in cells[,] arrays position
                    _cells[x, y] = gridCell;
                }
            }
        }

        [Button]
        public void DeleteCells()
        {
            DestroyUsingCellsArray();
            DestroyUsingChild();

            if (_cells is not null)
                Array.Clear(_cells, 0, _cells.Length);
        }

        private void DestroyUsingCellsArray()
        {
            // **** Destroy with using cells[,] array. It cause that if we change script after the compile,
            // **** cell[,] array might give error but we have also child didnt destroyed yet.
            // **** That's why i didnt use this method.
            
            /*
             for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    Debug.Log(cells[x, y]);
                    if (cells[x, y] is not null && cells[x, y].gameObject.activeInHierarchy)
                        DestroyImmediate(cells[x, y].gameObject);
                }
            }
             */
        }

        private void DestroyUsingChild()
        {
            var parentTransform = transform;

            var childCount = parentTransform.childCount;
            for (var i = childCount - 1; i >= 0; i--)
            {
                Transform childTransform = parentTransform.GetChild(i);
                DestroyImmediate(childTransform.gameObject);
            }
        }

        [Button]
        public void SetupCells()
        {
            if (_cells is null) return;
            foreach (var cell in _cells)
            {
                if (cell is not null)
                    cell.CellSetup();
            }
        }
    }
}