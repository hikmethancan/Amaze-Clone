using System;
using Abstract.Base_Template;
using Abstract.Base_Template.enums;
using UnityEngine;

namespace Concrete.Player
{
    public class PlayerMovementDetector : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private PlayerMovement playerMovement;

        [SerializeField] private LayerMask obstacleLayer;

        [Header("Ray Transforms")] [SerializeField]
        private Transform up;

        [SerializeField] private Transform down;
        [SerializeField] private Transform left;
        [SerializeField] private Transform right;

        private Vector3 _movePos;
        private RaycastHit _hit;

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

        private void HandleInput(InputType input)
        {
            switch (input)
            {
                case InputType.Up:
                    if (ObstacleDetection(up))
                    {
                        var currentPos = transform.position;
                        _movePos = new Vector3(currentPos.x, _hit.transform.position.y - 1, currentPos.z);
                    }

                    break;
                case InputType.Down:
                    if (ObstacleDetection(down))
                    {
                        var currentPos = transform.position;
                        _movePos = new Vector3(currentPos.x, _hit.transform.position.y + 1, currentPos.z);
                    }

                    break;
                case InputType.Left:
                    if (ObstacleDetection(left))
                    {
                        var currentPos = transform.position;
                        _movePos = new Vector3(_hit.transform.position.x + 1, currentPos.y, currentPos.z);
                    }

                    break;
                case InputType.Right:
                    if (ObstacleDetection(right))
                    {
                        var currentPos = transform.position;
                        _movePos = new Vector3(_hit.transform.position.x - 1, currentPos.y, currentPos.z);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input), input, null);
            }

            playerMovement.Move(_movePos);
        }

        private bool ObstacleDetection(Transform rayDirection)
        {
            if (Physics.Raycast(transform.position, rayDirection.forward, out _hit, Mathf.Infinity, obstacleLayer))
            {
                Debug.DrawRay(transform.position, rayDirection.forward, Color.yellow);
                Debug.Log("Did Hit" + $"{rayDirection.gameObject.name}");
                return true;
            }

            return false;
        }
    }
}