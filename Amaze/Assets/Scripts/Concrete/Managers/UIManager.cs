using System;
using Abstract.Base_Template;
using Abstract.Base_Template.enums;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject successPanel;


        private void OnEnable()
        {
            successPanel.SetActive(false);
            GameControl.OnChangeGameState += OpenSuccessPanel;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameControl.OnChangeGameState -= OpenSuccessPanel;
        }

        public void NextLevel()
        {
            CloseSuccessPanel();
        }

        private void OpenSuccessPanel(GameState state)
        {
            if(state != GameState.Success) return;
            successPanel.transform.localScale = Vector3.zero;
            successPanel.SetActive(true);
            successPanel.transform.DOScale(Vector3.one, .5f).SetEase(Ease.Linear);
        }

        private void CloseSuccessPanel()
        {
            successPanel.transform.DOScale(Vector3.zero, .5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                successPanel.SetActive(false);    
                GameControl.OnChangeGameState?.Invoke(GameState.Playing);
            });
            
        }
    }
}