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


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                if (interactable.GetCellType() == CellType.Floor)
                {
                    interactable.Interact();
                    Debug.Log("Floor");
                }
            }
        }
    }
}