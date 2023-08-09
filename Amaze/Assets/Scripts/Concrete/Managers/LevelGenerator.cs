using System;
using Abstract.Enums;
using Concrete.Cells;
using Sirenix.OdinInspector;
using UnityEditor;
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

        static void OnEditorModeStarted()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredEditMode)
            {
                Debug.Log("edit mode");
            }
        }
        private void Start()
        {
            SetupCells();
        }

        [Button]
        public void LoadCellData()
        {
            var path = $"{gameObject.name}.es3";
            if(_cells is null || _cells[0,0] is null)
                if(ES3.FileExists(path))
                    if (ES3.Load<Cell[,]>($"Cell{gameObject.name}",path) is not null)
                        _cells = ES3.Load<Cell[,]>($"Cell{gameObject.name}",path);
        }
        [Button]
        public void CreateCells()
        {
            DeleteCells();
            _cells = new Cell[cellRow, cellCol];
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
            var o = gameObject;
            var path = $"{o.name}.es3";
            ES3.Save($"Cell{o.name}", _cells,path);
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