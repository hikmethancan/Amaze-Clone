using System;
using Abstract.Enums;
using Abstract.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Concrete.Cells
{
    public class Cell : MonoBehaviour, IInteractable
    {
        public int x;
        public int y;
        
        [Header("References")] [SerializeField]
        private SkinnedMeshRenderer meshRenderer;

        [TableList] public CellSettings cellSettings;

        // public Cell Right => 
        public Cell Left { get; set; }
        public Cell Up { get; set; }
        public Cell Down { get; set; }
        public bool IsInteracted { get; set; }
        

        private void Start()
        {
            CellSetup();
        }

        private void OnValidate()
        {
            Debug.Log("Changed");
            CellSetup();
        }

        public void Interact()
        {
            if (IsInteracted) return;
            Debug.Log(name + " interacted");
            IsInteracted = true;
            ChangeColor();
        }

        public CellType GetCellType()
        {
            return cellSettings.cellType;
        }

        private void ChangeColor()
        {
            if (cellSettings.cellType == CellType.Obstacle)
                meshRenderer.material.color = cellSettings.cellObstacleColor;
            else
                meshRenderer.material.color = cellSettings.cellFloorColor;
        }

        private void ChangePositionForType()
        {
            var pos = transform.position;
            if (cellSettings.cellType == CellType.Obstacle)
                transform.position = new Vector3(pos.x, pos.y, -.70f);
            else
                transform.position = new Vector3(pos.x, pos.y, 0f);
        }

        public void CellSetup()
        {
            ChangeColor();
            ChangePositionForType();
        }
    }
}