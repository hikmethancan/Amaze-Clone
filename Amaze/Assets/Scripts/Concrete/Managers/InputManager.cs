using Abstract.Base_Template;
using Abstract.Base_Template.enums;
using UnityEngine;

namespace Concrete.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        [SerializeField] private float deadZone;
        private Vector3 _initialMousePosition;
        private bool _isDragging = false;

        private void Update()
        {
            TakeInputs();
            WhichWayDecision();
        }

        private void TakeInputs()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _initialMousePosition = Input.mousePosition; // take reference to starting dragging pos
                _isDragging = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
            }
        }

        private void WhichWayDecision()
        {
            if (_isDragging)
            {
                Vector3 currentMousePosition = Input.mousePosition; // Take current mouse pos
                Vector3 dragDirection = currentMousePosition - _initialMousePosition;


                float horizontalDrag = dragDirection.x;
                float verticalDrag = dragDirection.y;

                var absHorizontal =Mathf.InverseLerp(0,1080, Mathf.Abs(horizontalDrag));
                var absVertical = Mathf.InverseLerp(0,1920,Mathf.Abs(verticalDrag));
                if (absHorizontal > absVertical)
                {
                    if (absHorizontal ! > deadZone) return;

                    if (horizontalDrag > 0)
                        GameControl.OnInputType?.Invoke(InputType.Right);
                    else
                        GameControl.OnInputType?.Invoke(InputType.Left);
                    _isDragging = false;
                }
                else if(absHorizontal < absVertical)
                {
                    if (absVertical ! > deadZone) return;

                    if (verticalDrag > 0)
                        GameControl.OnInputType?.Invoke(InputType.Up);
                    else
                        GameControl.OnInputType?.Invoke(InputType.Down);
                    _isDragging = false;
                }
                _initialMousePosition = currentMousePosition; // Başlangıç pozisyonu güncellenir
            }
        }
    }
}