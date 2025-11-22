using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template.Core
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public GameState CurrentState { get; private set; } = GameState.Menu;

        protected override void SingletonStarted()
        {
            SetState(GameState.Menu);
        }

        public void StartGame()
        {
            SetState(GameState.Game);
        }

        public void WinGame()
        {
            SetState(GameState.Win);
        }

        public void LoseGame()
        {
            SetState(GameState.Lose);
        }

        public void GoToMenu()
        {
            SetState(GameState.Menu);
        }

        public void ResetGame()
        {
            SetState(GameState.Menu);
        }

        public void RestartGame()
        {
            StartGame();
        }

        private void SetState(GameState next)
        {
            if (CurrentState == next) return;
            CurrentState = next;
            EventBus.OnGameStateChanged?.Invoke(next);
        }
    }
}


