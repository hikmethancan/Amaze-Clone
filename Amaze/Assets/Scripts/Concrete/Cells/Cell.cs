using Abstract.Enums;
using Abstract.Interfaces;
using UnityEngine;

namespace Concrete.Cells
{
    public class Cell : MonoBehaviour,IInteractable
    {
        [Header("References")] [SerializeField]
        private MeshRenderer meshRenderer;
        [SerializeField] private CellSettings cellSettings;
        
        public bool IsInteracted { get; set; }

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            if (cellSettings.cellType == CellType.Obstacle)
                meshRenderer.material.color = cellSettings.cellObstacleColor;
        }
        public void Interact()
        {
            if(IsInteracted) return;
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
            meshRenderer.material.color = cellSettings.cellFloorColor;
        }
    }
}