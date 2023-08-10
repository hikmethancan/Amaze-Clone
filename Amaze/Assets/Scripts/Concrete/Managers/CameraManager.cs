using Abstract.Base_Template;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Concrete.Managers
{
    public class CameraManager : MonoBehaviour
    {
        public GameObject targetObject; // Hedef objenin referansı
        public Camera mainCamera;
        private void OnEnable()
        {
            GameControl.OnNewLevelCamera += HandleCamera;
        }

        private void OnDisable()
        {
            GameControl.OnNewLevelCamera -= HandleCamera;
        }

        private void HandleCamera(Transform levelTransform)
        {
            targetObject = levelTransform.gameObject;
            // CameraFollowerSetup();
            SetCameraPos();
            Debug.Log(levelTransform);
        }

        [Button]
        private void SetCameraPos()
        {
            Debug.Log("hiiads");
            if (targetObject == null)
            {
                Debug.LogError("Target object is not assigned.");
                return;
            }

            Bounds bounds = CalculateObjectBounds(targetObject);
            
            if (mainCamera != null)
            {
                float screenAspect = (float)Screen.width / (float)Screen.height;
                float boundsHeight = bounds.size.y;
                float boundsWidth = bounds.size.x;

                float desiredOrthographicSize = boundsHeight / 2f;

                if (screenAspect > 1f)
                {
                    desiredOrthographicSize /= screenAspect;
                }

                mainCamera.orthographicSize = desiredOrthographicSize;
            }
        }

        private Bounds CalculateObjectBounds(GameObject obj)
        {
            Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

            if (renderers.Length == 0)
            {
                return new Bounds(obj.transform.position, Vector3.zero);
            }

            Bounds bounds = renderers[0].bounds;

            foreach (Renderer renderer in renderers)
            {
                bounds.Encapsulate(renderer.bounds);
            }

            return bounds;
        }
    }
}
