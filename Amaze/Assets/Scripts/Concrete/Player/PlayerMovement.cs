using System;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody rb;

        [Header("Values")] 
        [SerializeField] private float playerMoveDuration; 
        
        private Coroutine _moveCoroutine;

        
        public bool canMove = true;


        private void Start()
        {
            canMove = true;
        }

        public void Move(Vector3 movementPos)
        {
            if(!canMove) return;
            canMove = false;
            transform.DOMove(movementPos, playerMoveDuration).SetEase(Ease.Linear).OnComplete(()=> canMove = true);
        }
    }
}