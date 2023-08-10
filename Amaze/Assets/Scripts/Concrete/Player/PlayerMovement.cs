using System;
using Abstract.Base_Template;
using Abstract.Base_Template.enums;
using Concrete.Managers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Concrete.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody rb;

        [SerializeField] private ParticleSystem hitParticle;
        [Header("Values")] 
        [SerializeField] private float playerMoveDuration; 
        
        private Coroutine _moveCoroutine;

        [FormerlySerializedAs("model2")] [SerializeField] private GameObject modelX;
        [FormerlySerializedAs("model2")] [SerializeField] private GameObject modelY;
        [SerializeField] private GameObject model1;
        public bool canMove = true;

        private void OnEnable()
        {
            GameControl.OnChangeGameState += ChangeState;
            GameControl.OnInputType += HandleInput;

        }

        private void HandleInput(InputType input)
        {
            if (input == InputType.Down || input == InputType.Up)
            {
                model1.transform.DOScaleY(1.3f, playerMoveDuration / 5).SetEase(Ease.Linear);

                // model1.SetActive(false);
                // modelX.SetActive(false);
                // modelY.SetActive(true);
            }
            else
            {
                model1.transform.DOScaleX(1.3f, playerMoveDuration / 5).SetEase(Ease.Linear);

                // model1.SetActive(false);
                // modelX.SetActive(true);
                // modelY.SetActive(false);
            }
        }

        private void OnDisable()
        {
            GameControl.OnChangeGameState -= ChangeState;
            GameControl.OnInputType -= HandleInput;

        }
        private void ChangeState(GameState state)
        {
            if (state == GameState.Success)
                transform.position = new Vector3(1, 1, transform.position.z);
        }
        private void Start()
        {
            canMove = true;
        }

        public void Move(Vector3 movementPos)
        {
            if(GameManager.Instance.gameState != GameState.Playing) return;
            if(!canMove) return;
            canMove = false;
            transform.DOMove(movementPos, playerMoveDuration).SetEase(Ease.Linear).OnComplete(()=>
            {
                canMove = true;
                model1.transform.DOScale(new Vector3(1, 1, 1), playerMoveDuration / 4);
                // model1.SetActive(true);
                // modelX.SetActive(false);
                // modelY.SetActive(false);
                // hitParticle.Play();
            });
        }
    }
}