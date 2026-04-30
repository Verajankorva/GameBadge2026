using StateMachine.Core;
using MazeGame.Core;
using MazeGame.Components.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine.States
{
    public class LoadingState : BaseState
    {
        public LoadingState(StateMachine.Core.StateMachine fsm) : base(fsm)
        {
        }

        public override void StartState()
        {
            base.StartState();
            SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive);
        }

        public override void UpdateState()
        {
            Scene s = SceneManager.GetSceneByName("Level");
            if (s.isLoaded)
            {
                Game.m_levelController = (LevelController)Game.GetController(s);
                if (Game.m_levelController != null )
                {
                    PlayerComponent pc = GameObject.FindAnyObjectByType<PlayerComponent>();
                    Game.m_player = new Player(pc);
                    Game.m_levelController.Deactive();
                    m_stateMachine.AddParameter("Gameplay", true);
                }
            }
        }
    }
}
