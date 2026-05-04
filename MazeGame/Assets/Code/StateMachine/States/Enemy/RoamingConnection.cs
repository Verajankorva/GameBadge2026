using StateMachine.Core;

namespace StateMachine.States.Enemy
{
    public class RoamingConnection : BaseConnection
    {
        public RoamingConnection(StateMachine.Core.StateMachine fsm) : base(fsm)
        {
        }

        public override bool Condition()
        {
            ParameterBool p = (ParameterBool)this.m_fsm.GetParameter("EnemyRoaming");
            if (p == null)
            {
                return false;
            }
            return p.m_value;
        }
    }
}