using System;
using Concrete.Cells;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Concrete.Managers
{
    [ExecuteInEditMode]
    public class Level : MonoBehaviour
    {
        [TableList,ShowInInspector] private Cell[,] cells = new Cell[15, 15];
        // [ShowInInspector]
        public CellSettings[,] cellsSettings = new CellSettings[15, 15];

        [SerializeField] private Cell cellPrefab;
        [SerializeField] private int cellRow;
        [SerializeField] private int cellCol;

        [Button]
        public void CreateCells()
        {
            DeleteCells();
            cells = new Cell[cellRow, cellCol];
            cellsSettings = new CellSettings[cellRow, cellCol];
            for (int x = 0; x < cellRow; x++)
            {
                for (int y = 0; y < cellCol; y++)
                {
                    Vector3 cellPosition = new Vector3(x, y, 0);
                    var gridCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity, transform);
                    cells[x, y] = gridCell;
                    cellsSettings[x, y] = gridCell.cellSettings;
                }
            }
        }

        [Button]
        public void DeleteCells()
        {
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    Debug.Log(cells[x,y]);
                    if(cells[x,y] is not null && cells[x,y].gameObject.activeInHierarchy)
                        DestroyImmediate(cells[x, y].gameObject);
                }
            }
            if (cells is not null)
                Array.Clear(cells, 0, cells.Length);
            if(cellsSettings is not null)
                Array.Clear(cellsSettings,0,cellsSettings.Length);
        }

        [Button]
        public void SetupCells()
        {
            SetSettingsToCells();
            foreach (var cell in cells)
            {
                if(cell is not null)
                    cell.CellSetup();
            }
        }

        private void SetSettingsToCells()
        {
            
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    if(cells[x,y] is not null)
                        cells[x, y].cellSettings = cellsSettings[x, y];
                }
            }
        }
        
        [TableMatrix(HorizontalTitle = "Read Only Matrix", IsReadOnly = true)]
        public int[,] ReadOnlyMatrix = new int[5, 5];

        [TableMatrix(HorizontalTitle = "X axis", VerticalTitle = "Y axis")]
        public InfoMessageType[,] LabledMatrix = new InfoMessageType[6, 6];
    }
}