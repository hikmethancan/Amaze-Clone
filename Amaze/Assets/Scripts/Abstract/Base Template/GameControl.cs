using System;
using System.Collections.Generic;
using Abstract.Base_Template.enums;
using Concrete.Cells;
using UnityEngine;

namespace Abstract.Base_Template
{
    public static class GameControl
    {
        #region Input

        public static Action<InputType> OnInputType;

        #endregion
        #region Game

        public static Action OnFirstTouch;

        public static Action OnGameStart;
        public static Action OnGameEnd; //Fail and Successful Starter

        public static Action OnFailGame;
        public static Action OnSuccessfulGame;
    
        public static Action OnFinish;
        public static Action OnBeforeFinish;

        #endregion

        #region UI

        public static Action<float> OnScoreChange;
        public static Action OnGamePause;

        #endregion

        #region Base

        public static Action OnMoneyChange;
        public static Action OnLoadLevel;
        public static Action OnLoadScene;
        public static Action OnBeforeLoadLevel;


        #endregion
        
        public static Action<GameState> OnChangeGameState;
        public static Action<Transform> OnNewLevelCamera;
        public static Action<List<FloorCel>> OnCurrentFloors;
    }
}
