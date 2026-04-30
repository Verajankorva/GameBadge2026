using MazeGame.Core;
using StateMachine.Core;
using StateMachine.States;
using UnityEngine;

namespace MazeGame.Components.Controllers
{
    public class GameController : BaseController
    {
        private MazeGame.Core.Input m_input = null;
        private StateMachine.Core.StateMachine m_stateMachine = null;

        public override void Start()
        {
            base.Start();
            m_input = MazeGame.Core.Input.GetInstance();
            Game.m_input = m_input;
            SetupStateMachine();
            Game.m_gameController = this;
        }

        private void SetupStateMachine()
        {
            m_stateMachine = new StateMachine.Core.StateMachine();
            Game.m_gameStateMachine = m_stateMachine;

            InitState initState = new InitState(m_stateMachine);
            LoadingState loadingState = new LoadingState(m_stateMachine);
            GameplayState gameplayState = new GameplayState(m_stateMachine);

            LoadingConnection loadingConnection = new LoadingConnection(m_stateMachine);
            loadingConnection.m_state = loadingState;
            initState.AddOutputConnection(loadingConnection);

            GameplayConnection gameplayConnection = new GameplayConnection(m_stateMachine);
            gameplayConnection.m_state = gameplayState;
            loadingState.AddOutputConnection(gameplayConnection);

            m_stateMachine.m_currentState = initState;
            m_stateMachine.StartStateMachine();
        }

        private void Update()
        {
            m_stateMachine.UpdateStateMachine();
        }
    }
}