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
        [Header("References")] [SerializeField]
        private Rigidbody rb;

        [SerializeField] private ParticleSystem hitParticle;
        [Header("Values")] [SerializeField] private float playerMoveDuration;

        private Coroutine _moveCoroutine;

        [FormerlySerializedAs("model2")] [SerializeField]
        private GameObject modelX;

        [FormerlySerializedAs("model2")] [SerializeField]
        private GameObject modelY;

        [SerializeField] private GameObject model1;
        
        private Sequence _moveSequence;

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
            GameControl.OnChangeGameState += ChangeState;
            GameControl.OnInputType += HandleInput;
        }

        private void UnSubEvents()
        {
            GameControl.OnChangeGameState -= ChangeState;
            GameControl.OnInputType -= HandleInput;
        }
        

        private void HandleInput(InputType input)
        {
            if (GameManager.Instance.gameState != GameState.Playing) return;
            if (input == InputType.Down || input == InputType.Up)
                model1.transform.DOScaleY(1.7f, playerMoveDuration / 5).SetEase(Ease.Linear);
            else
                model1.transform.DOScaleX(1.7f, playerMoveDuration / 5).SetEase(Ease.Linear);
        }

        private void ChangeState(GameState state)
        {
            if (state == GameState.Success)
            {
                if (_moveSequence.IsActive())
                {
                    _moveSequence.Pause();
                }

                _moveSequence = DOTween.Sequence();
                model1.transform.DOScale(Vector3.one, .1f).SetEase(Ease.Flash);
                _moveSequence.Append(transform.DOMove(new Vector3(1, 1, transform.position.z), .1f)
                    .SetEase(Ease.Flash));
                Debug.Log("Player Succes Event");
            }
        }

        public void Move(Vector3 movementPos)
        {
            if (GameManager.Instance.gameState != GameState.Playing) return;
            if (_moveSequence.IsActive())
            {
                _moveSequence.Pause();
            }

            _moveSequence = DOTween.Sequence();
            _moveSequence.Append(transform.DOMove(movementPos, playerMoveDuration).SetEase(Ease.Linear)).AppendCallback(() =>
            {
                model1.transform.DOScale(new Vector3(1, 1, 1), playerMoveDuration / 3);
            });
        }
    }
}