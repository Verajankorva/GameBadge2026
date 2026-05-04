using MazeGame.Components;
using StateMachine.Core;
using StateMachine.States.Enemy;
using UnityEngine;

namespace MazeGame.Core
{
    public class Enemy : BaseCharacter
    {
        public StateMachine.Core.StateMachine m_stateMachine = null;
        public EnemyComponent m_comp = null;

        public Enemy(EnemyComponent comp)
        {
            m_comp = comp;
            this.m_characterInstance = comp.gameObject;
            this.m_rb = this.m_characterInstance.GetComponent<Rigidbody>();
            SetupStateMachine();
        }

        private void SetupStateMachine()
        {
            m_stateMachine = new StateMachine.Core.StateMachine();
            InitState initState = new InitState(m_stateMachine);
            RoamingState roamingState = new RoamingState(m_stateMachine);

            RoamingConnection roamingConnection = new RoamingConnection(m_stateMachine);
            roamingConnection.m_state = roamingState;
            initState.AddOutputConnection(roamingConnection);

            m_stateMachine.m_currentState = initState;
        }

        public void Update()
        {
            m_stateMachine.UpdateStateMachine();
        }
    }
}