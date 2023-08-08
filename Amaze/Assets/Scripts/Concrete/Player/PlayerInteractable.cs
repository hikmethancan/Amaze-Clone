using System;
using Abstract.Enums;
using Abstract.Interfaces;
using UnityEngine;

namespace Concrete.Player
{
    public class PlayerInteractable : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private PlayerMovement playerMovement;
        

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IInteractable interactable))
            {
                if (interactable.GetCellType() == CellType.Obstacle)
                {
                    playerMovement.IsMoving = false;
                    Debug.Log("sdasda");
                }
                else
                {
                    interactable.Interact();
                }
            }
        }
    }
}