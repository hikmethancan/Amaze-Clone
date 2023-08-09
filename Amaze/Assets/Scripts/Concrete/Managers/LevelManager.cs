using System;
using Abstract.Base_Template;

namespace Concrete.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        private int _currentLevel;

        private void OnEnable()
        {
            GameControl.OnSuccessfulGame += ChangeLevel;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameControl.OnSuccessfulGame -= ChangeLevel;
        }

        private void Awake()
        {
            
        }

        private void ChangeLevel()
        {
            _currentLevel++;
            ES3.Save("level",_currentLevel);
        }

        private void Start()
        {
            _currentLevel = ES3.Load<int>("level",1);
        }
    }
}
