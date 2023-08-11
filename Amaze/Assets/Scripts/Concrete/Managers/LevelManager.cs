using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abstract.Base_Template;
using Abstract.Base_Template.enums;
using Concrete.Cells;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private List<LevelGenerator> levels;
       
        public List<FloorCel> currentFloor;
        
        private int _currentLevel;

        private void OnEnable()
        {
            _currentLevel = ES3.Load<int>("level", 1);
            Debug.Log(_currentLevel);
            LoadLevel(_currentLevel-1);
            GameControl.OnChangeGameState += ChangeLevel;
            GameControl.OnCurrentFloors += NewFloor;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameControl.OnChangeGameState -= ChangeLevel;
            GameControl.OnCurrentFloors -= NewFloor;
        }
        private void Start()
        {
            _currentLevel = ES3.Load<int>("level", 1);
        }
        private void NewFloor(List<FloorCel> obj)
        {
            currentFloor = obj;
            LoadLevel(_currentLevel-1);
        }
        private void ChangeLevel(GameState state)
        {
            if(state != GameState.Success) return;
            if (_currentLevel > levels.Count)
            {
                _currentLevel = 1;
                ES3.Save("level",_currentLevel);
            }
            else
            {
                _currentLevel++;
                ES3.Save("level", _currentLevel);    
            }
            LoadLevel(_currentLevel - 1);
        }
        private void LoadLevel(int index)
        {
            
            for (int i = 0; i < levels.Count; i++)
            {
                if (i == index)
                {
                    levels[i].gameObject.SetActive(true);
                    currentFloor = levels[i].levelData.FloorCels;
                }
                else
                    levels[i].gameObject.SetActive(false);
            }
            StartCoroutine(CellSuccessControl());
        }

        private IEnumerator CellSuccessControl()
        {
            yield return new WaitUntil(() => GameManager.Instance.gameState == GameState.Playing);
            yield return new WaitUntil(() => currentFloor.All(cell => cell.IsInteracted));
            Debug.Log("All Cells Completed");
            GameControl.OnChangeGameState?.Invoke(GameState.Success);
            yield return new WaitForSeconds(1f);
            GameControl.OnChangeGameState?.Invoke(GameState.Playing);
        }
    }
}