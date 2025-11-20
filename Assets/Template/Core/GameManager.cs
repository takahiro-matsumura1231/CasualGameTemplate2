using UnityEngine;

namespace Template.Core
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public GameState CurrentState { get; private set; } = GameState.Init;

        protected override void SingletonStarted()
        {
            SetState(GameState.Init);
        }

        public void StartGame()
        {
            SetState(GameState.Playing);
        }

        public void EndGame()
        {
            SetState(GameState.GameOver);
        }

        public void ResetGame()
        {
            SetState(GameState.Init);
        }

        private void SetState(GameState next)
        {
            if (CurrentState == next) return;
            CurrentState = next;
            EventBus.OnGameStateChanged?.Invoke(next);
        }
    }
}


