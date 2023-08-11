using Abstract.Base_Template;
using Data;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Managers
{
    public class LevelGenerator : MonoBehaviour
    {
        [Header("References")]
        public LevelSo levelData;
        private void OnEnable()
        {
            levelData.CreateCells(transform);
            GameControl.OnNewLevelCamera?.Invoke(transform);
            GameControl.OnCurrentFloors?.Invoke(levelData.FloorCels);
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, .5f).SetEase(Ease.Linear);
        }

    }
}