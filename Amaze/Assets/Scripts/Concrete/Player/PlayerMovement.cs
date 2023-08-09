using System;
using Abstract.Base_Template;
using Abstract.Base_Template.enums;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody rb;

        [SerializeField] private float movementForce;

        private bool _canMove;
        private Coroutine _moveCoroutine;

        public bool CanMove
        {
            get => _canMove;
            set
            {
                _canMove = value;
                if (!_canMove)
                {
                   // rb.velocity = Vector3.zero;
                    Debug.Log("can't Move");
                }
            }
        }
        public void Move(Vector3 movementPos)
        {
            CanMove = false;
            transform.DOMove(movementPos, .5f).SetEase(Ease.Linear).OnComplete(()=> CanMove = true);
        }
    }
}