using StateMachine.Core;
using Unity.Profiling;

namespace StateMachine.States
{
    public class GameplayConnection : BaseConnection
    {
        public GameplayConnection(StateMachine.Core.StateMachine fsm) : base(fsm)
        {}

        static ProfilerMarker stateCondition = new ProfilerMarker("State condition");
        static ProfilerMarker stateParameter = new ProfilerMarker("State parameter");
        public override bool Condition()
        {
            stateCondition.Begin();
            stateParameter.Begin();
            ParameterBool p = (ParameterBool)this.m_fsm.GetParameter("Gameplay");
            stateParameter.End();
            if(p == null)
            {
                stateCondition.End();
                return false;
            }
            stateCondition.End();
            return p.m_value;
        }
    }
}