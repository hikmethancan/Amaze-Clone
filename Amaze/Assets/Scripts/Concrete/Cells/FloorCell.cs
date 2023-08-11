using System;
using Abstract.Interfaces;
using UnityEngine;

namespace Concrete.Cells
{
    public class FloorCel : Cell,IInteractable
    {

        [SerializeField] private Material baseMat;
        [SerializeField] private Material coloredMat;
        public bool IsInteracted { get; set; }

        private void OnEnable()
        {
            meshRenderer.material = baseMat;
        }

        public void Interact()
        {
            IsInteracted = true;
            ChangeColor();
        }
        private void ChangeColor()
        {
            meshRenderer.material = coloredMat;
        }
        
        
    }
}