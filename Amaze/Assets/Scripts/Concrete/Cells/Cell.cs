using System;
using System.Collections;
using Abstract.Enums;
using Abstract.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Concrete.Cells
{
    public class Cell : SerializedMonoBehaviour, IInteractable
    {
        public int x;
        public int y;

        [Header("References")] [SerializeField]
        private SkinnedMeshRenderer meshRenderer;

        [TableList] public CellSettings cellSettings;

        public Cell Left { get; set; }
        public Cell Up { get; set; }
        public Cell Down { get; set; }
        public bool IsInteracted { get; set; }

        private Material _tempMaterial;

        private void Awake()
        {
            ChangeLayer();
        }

        private void Start()
        {
            CellSetup();
        }

        private void OnValidate()
        {
            // if (!gameObject.activeInHierarchy) return;
            // BaseColor();
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

        private IEnumerator ColorChanger()
        {
            yield return new WaitForSeconds(1f);
            CellSetup();
        }

        private void BaseColor()
        {
            if (meshRenderer.sharedMaterial is null) return;
            _tempMaterial = new Material(meshRenderer.sharedMaterial);
            if (cellSettings.cellType == CellType.Obstacle)
                _tempMaterial.color = cellSettings.cellBaseObstacleColor;
            else
                _tempMaterial.color = cellSettings.cellBaseFloorColor;
            meshRenderer.material = _tempMaterial;
        }

        private void ChangeLayer()
        {
            Debug.Log(Enum.GetName(typeof(CellType), cellSettings.cellType));
            int layerIgnoreRaycast = LayerMask.NameToLayer(Enum.GetName(typeof(CellType), cellSettings.cellType));
            gameObject.layer = layerIgnoreRaycast;
        }

        private void ChangeColor()
        {
            if (cellSettings.cellType == CellType.Floor)
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
            meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            BaseColor();
            ChangePositionForType();
        }
    }
}