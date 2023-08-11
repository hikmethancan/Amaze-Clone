using System;
using Abstract.Base_Template;
using Abstract.Base_Template.enums;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Concrete.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject successPanel;
        [SerializeField] private TMP_Text levelText;

        private void OnEnable()
        {
            successPanel.SetActive(false);
            GameControl.OnChangeGameState += AfterTheSuccess;
            SetLevelText();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameControl.OnChangeGameState -= AfterTheSuccess;
            SetLevelText();
        }

        private void SetLevelText()
        {
            levelText.SetText("Level "+ES3.Load<int>("level",1));
        }

        public void NextLevel()
        {
            CloseSuccessPanel();
            SetLevelText();
        }

        private void AfterTheSuccess(GameState state)
        {
            SetLevelText();
            // if (state != GameState.Success) return;
            // successPanel.SetActive(true);
        }

        private void CloseSuccessPanel()
        {
            GameControl.OnChangeGameState?.Invoke(GameState.Playing);
            successPanel.SetActive(false);
        }
    }
}