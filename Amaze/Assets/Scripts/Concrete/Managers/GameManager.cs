using Abstract.Base_Template;
using Abstract.Base_Template.enums;

namespace Concrete.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public GameState gameState;

        private void OnEnable()
        {
            gameState = GameState.Playing;
            GameControl.OnChangeGameState += ChangeState;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameControl.OnChangeGameState -= ChangeState;
        }

        private void ChangeState(GameState state)
        {
            gameState = state;
        }
    }
}