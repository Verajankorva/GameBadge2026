using MazeGame.Core;
using StateMachine.Core;
using StateMachine.States;
using UnityEngine;

namespace StateMachine
{
    public class StateMachineComponent : MonoBehaviour
    {
        private StateMachine.Core.StateMachine m_stateMachine = null;

        private void Start()
        {
            SetupStateMachine();
        }

        private void Update()
        {
            m_stateMachine.UpdateStateMachine();
        }

        private void SetupStateMachine()
        {
            m_stateMachine = new Core.StateMachine();
            Game.m_gameStateMachine = m_stateMachine;
            InitState initState = new InitState();
            LoadingState loadingState = new LoadingState();
            LoadingConnection loadingConnection = new LoadingConnection(m_stateMachine);
            loadingConnection.m_state = loadingState;
            initState.AddOutputConnection(loadingConnection);
            m_stateMachine.m_currentState = initState;
            m_stateMachine.StartStateMachine();
        }
    }
}
