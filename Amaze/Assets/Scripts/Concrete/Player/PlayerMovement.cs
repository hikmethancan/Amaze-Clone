using System;
using Abstract.Base_Template;
using Abstract.Base_Template.enums;
using UnityEngine;

namespace Concrete.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody rb;

        [SerializeField] private float movementForce;

        private bool _isMoving;

        public bool IsMoving
        {
            get => _isMoving;
            set
            {
                _isMoving = value;
                if (!_isMoving)
                {
                    rb.velocity = Vector3.zero;
                    Debug.Log("Obstacle");
                }
            }
        }
        private void OnEnable()
        {
            SubEvents();
        }
        private void OnDisable()
        {
            UnSubEvents();
        }

        private void SubEvents()
        {
            GameControl.OnInputType += HandleInput;
        }
        
        private void UnSubEvents()
        {
            GameControl.OnInputType -= HandleInput;
        }
        private void HandleInput(InputType inputType)
        {
            ChooseMovementWay(inputType);
        }

        private void ChooseMovementWay(InputType inputType)
        {
            if(IsMoving) return;
            IsMoving = true;
            float horizontal = 0;
            float vertical = 0;
            switch (inputType)
            {
                case InputType.Up:
                    vertical = 1;
                    break;
                case InputType.Down:
                    vertical = -1;
                    break;
                case InputType.Right:
                    horizontal = 1;
                    break;
                case InputType.Left:
                    horizontal = -1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }

            var movementVector = new Vector3(horizontal, vertical, 0);
            Move(movementVector);            
        }

        private void Move(Vector3 moveVector)
        {
            rb.AddForce(moveVector * movementForce);
        }
    }
}