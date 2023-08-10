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
            GameControl.OnChangeGameState += OpenSuccessPanel;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameControl.OnChangeGameState -= OpenSuccessPanel;
            SetLevelText();
        }

        private void SetLevelText()
        {
            levelText.SetText(ES3.Load<int>("level",1).ToString());
        }

        public void NextLevel()
        {
            CloseSuccessPanel();
            SetLevelText();
        }

        private void OpenSuccessPanel(GameState state)
        {
            if (state != GameState.Success) return;
            // successPanel.transform.localScale = Vector3.zero;
            successPanel.SetActive(true);
            // successPanel.transform.DOScale(Vector3.one, .5f).SetEase(Ease.Linear);
        }

        private void CloseSuccessPanel()
        {
            GameControl.OnChangeGameState?.Invoke(GameState.Playing);
            GameControl.OnGameStart?.Invoke();
            GameManager.Instance.gameState = GameState.Playing;
            successPanel.SetActive(false);
        }
    }
}