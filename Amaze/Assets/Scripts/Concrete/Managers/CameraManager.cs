using System;
using Abstract.Base_Template;
using UnityEngine;

namespace Concrete.Managers
{
    public class CameraManager : MonoBehaviour
    {
        public Transform targetObject; // Hedef objenin referansı
        public float padding = 1.5f; 
        
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }
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
            targetObject = levelTransform;
            CameraFollowerSetup();
        }
       // Kenarda biraz boşluk bırakmak için ekstra alan

        private void CameraFollowerSetup()
        {
            // Hedef objenin merkezini kameraya bakacak şekilde ayarla
            Vector3 targetCenter = targetObject.position + (Vector3.up * padding); // Eğer objenin merkezi farklı bir yükseklikteyse düzeltme yapılabilir.
            transform.LookAt(targetCenter);

            // Hedef objenin hepsini görünecek şekilde kameranın FOV'sunu ayarlar
            float distanceToTarget = Vector3.Distance(targetObject.position, transform.position);
            float halfFov = Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad;
            float requiredDistance = Mathf.Abs(targetObject.localScale.z / (2f * Mathf.Tan(halfFov))) * padding;
            float newFov = Mathf.Rad2Deg * (2f * Mathf.Atan(targetObject.localScale.z / (2f * requiredDistance)));

            Camera.main.fieldOfView = newFov;
        }
    }
}
