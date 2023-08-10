using Abstract.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Concrete.Cells
{
    public class FloorCel : Cell,IInteractable
    {
        public Color InteractedColor;
        public bool IsInteracted;
        public void Interact()
        {
            IsInteracted = true;
            ChangeColor();
        }
        private void ChangeColor()
        {
            meshRenderer.material.color = InteractedColor;
        }
        
        
    }
}