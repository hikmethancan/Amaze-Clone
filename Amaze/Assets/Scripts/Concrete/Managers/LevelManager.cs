using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abstract.Base_Template;
using Abstract.Base_Template.enums;
using Concrete.Cells;
using UnityEngine;

namespace Concrete.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private List<LevelGenerator> levels;
        private int _currentLevel;
        public List<FloorCel> _currentFloor;

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
        private void NewFloor(List<FloorCel> obj)
        {
            _currentFloor = obj;
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
                    _currentFloor = levels[i].levelData.FloorCels;
                    GameControl.OnNewLevelCamera?.Invoke(levels[i].transform);
                    Debug.Log(levels[i].transform);
                }
                else
                    levels[i].gameObject.SetActive(false);
            }
            StartCoroutine(CellSuccessControl());
        }

        private IEnumerator CellSuccessControl()
        {
            yield return new WaitUntil(() => GameManager.Instance.gameState == GameState.Playing);
            yield return new WaitUntil(() => _currentFloor.All(cell => cell.IsInteracted));
            Debug.Log("All Cells Completed");
            GameControl.OnChangeGameState?.Invoke(GameState.Success);
        }

        private void Start()
        {
            _currentLevel = ES3.Load<int>("level", 1);
        }
    }
}