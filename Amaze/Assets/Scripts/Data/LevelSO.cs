using System;
using System.Collections.Generic;
using Concrete.Cells;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelData")]
    public class LevelSo : SerializedScriptableObject
    {
        [TableMatrix(SquareCells = true, RespectIndentLevel = true,
            HideColumnIndices = true, HideRowIndices = true, RowHeight = 1)]
        private int[,] _cells;


        [TableMatrix(SquareCells = true, RespectIndentLevel = true,
            HideColumnIndices = true, HideRowIndices = true, RowHeight = 1, DrawElementMethod = "DrawCell")]
        public bool[,] _cellBool;

        public List<FloorCel> FloorCels { get; set; }

        [SerializeField] private FloorCel floorCell;
        [SerializeField] private ObstacleCell obstacleCell;
        [Header("Values")] [SerializeField] private int cellRow;
        [SerializeField] private int cellCol;
        [SerializeField] private List<GameObject> allCellObjects;

        private static bool DrawCell(Rect rect, bool value)
        {
            if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
            {
                value = !value;
                GUI.changed = true;
                Event.current.Use();
            }

            EditorGUI.DrawRect(rect.Padding(1),
                value
                    ? new Color(0.1f, 0.8f, 0.2f)
                    : new Color(0, 0, 0, 0.5f));
            return value;
        }

        [OnInspectorInit]
        private void SetCells()
        {
            Debug.Log("Ins init");
            _cells ??= new int[cellRow, cellCol];
            _cellBool ??= new Boolean[cellRow, cellCol];
        }

        private void SetBordersObstacle()
        {
            _cellBool = new Boolean[cellRow, cellCol];
            for (int x = 0; x < cellRow; x++)
            {
                for (int y = 0; y < cellCol; y++)
                {
                    if (x < (_cellBool.GetLength(0) - 1) && y == 0)
                        _cellBool[x, y] = true;
                    if (y == (_cellBool.GetLength(1) - 1) && x < _cellBool.GetLength(0))
                        _cellBool[x, y] = true;
                    if (x == (_cellBool.GetLength(0) - 1) && y < _cellBool.GetLength(1))
                        _cellBool[x, y] = true;
                    if (x == 0 || y == 0)
                        _cellBool[x, y] = true;
                }
            }
        }


        [Button]
        public void LoadCellData()
        {
            Debug.Log(_cells);
        }

        [Button]
        [GUIColor(0, 1, 0.4f)]
        public void CreateCells(Transform parent)
        {
            FloorCels.Clear();
            FloorCels = new List<FloorCel>();
            DeleteCells();
            allCellObjects = new List<GameObject>();
            for (int x = 0; x < cellRow; x++)
            {
                for (int y = 0; y < cellCol; y++)
                {
                    Vector3 floorCellPos = new Vector3(x, y, 0);
                    Vector3 obstacleCellPos = new Vector3(x, y, -.7f);
                    Cell newCell = null;

                    // Every border and edges have to be obstacle
                    if (_cellBool[x, y])
                    {
                        newCell = Instantiate(obstacleCell, obstacleCellPos, Quaternion.identity, parent);
                        allCellObjects.Add(newCell.gameObject);
                    }
                    else
                    {
                        newCell = Instantiate(floorCell, floorCellPos, Quaternion.identity, parent);
                        FloorCels.Add((FloorCel) newCell);
                        allCellObjects.Add(newCell.gameObject);
                    }
                    // Set the instantiated cell in cells[,] arrays position
                }
            }
        }

        [GUIColor(1, 0.6f, 0.4f)]
        [Button]
        public void DeleteCells()
        {
            DestroyUsingCellsArray();
            if (_cells is not null)
            {
                Array.Clear(_cells, 0, _cells.Length);
            }
        }

        private void DestroyUsingCellsArray()
        {
            if (allCellObjects is null) return;
            foreach (var cell in allCellObjects)
            {
                DestroyImmediate(cell);
            }

            allCellObjects.Clear();
            LoadCellData();
        }

        [Button]
        [GUIColor(0, 1, 0.4f)]
        public void SetupCells()
        {
            _cellBool = new Boolean[cellRow, cellCol];
            SetBordersObstacle();
        }
    }
}