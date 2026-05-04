using StateMachine.Core;

namespace StateMachine.States.Enemy
{
    public class InitState : BaseState
    {
        public InitState(StateMachine.Core.StateMachine fsm) : base(fsm)
        {
            m_stateMachine = fsm;
        }

        public override void StartState()
        {
            base.StartState();
            m_stateMachine.AddParameter("EnemyRoaming", true);
        }
    }
}