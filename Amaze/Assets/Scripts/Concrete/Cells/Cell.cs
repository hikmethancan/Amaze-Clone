using System;
using Abstract.Enums;
using Abstract.Interfaces;
using UnityEngine;

namespace Concrete.Cells
{
    public class Cell : MonoBehaviour, IInteractable
    {
        [Header("References")] [SerializeField]
        private SkinnedMeshRenderer meshRenderer;

        public CellSettings cellSettings;

        // public Cell Right => 
        public Cell Left { get; set; }
        public Cell Up { get; set; }
        public Cell Down { get; set; }
        public bool IsInteracted { get; set; }

        private void Awake()
        {
            ChangeColor();
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
            meshRenderer.sharedMaterial.color = cellSettings.cellType == CellType.Obstacle
                ? cellSettings.cellObstacleColor
                : cellSettings.cellFloorColor;
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