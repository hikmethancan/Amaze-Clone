using Abstract.Interfaces;
using UnityEngine;

namespace Concrete.Cells
{
    public class FloorCel : Cell,IInteractable
    {
        public Color interactedColor;
        public bool IsInteracted { get; set; }

        public void Interact()
        {
            IsInteracted = true;
            ChangeColor();
        }
        private void ChangeColor()
        {
            meshRenderer.material.color = interactedColor;
        }
        
        
    }
}