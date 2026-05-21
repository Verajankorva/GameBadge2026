using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;

namespace StateMachine.Core
{
    public class StateMachine
    {
        private bool m_update = false;
        private List<BaseParameter> m_parameters = null;
        public BaseState m_currentState = null;
        public BaseState m_previousState = null;

        public StateMachine()
        {
            Debug.Log(string.Format("{0} created.", this.GetType()));
            m_parameters = new List<BaseParameter>();
        }

        public void AddParameter(string name, object value)
        {
            // TODO: Fix, check if parameter already exists. If it does, reuse, don't create a new one.
            if (value.GetType() == typeof(string))
            {
                ParameterString p = new ParameterString(name, (string)value);
                m_parameters.Add(p);
            }
            if (value.GetType() == typeof(bool))
            {
                ParameterBool p = new ParameterBool(name, (bool)value);
                m_parameters.Add(p);
            }
        }

        static ProfilerMarker fsmParameter = new ProfilerMarker("Check parameter");

        public BaseParameter GetParameter(string name)
        {
            foreach(BaseParameter p in m_parameters)
            {
                fsmParameter.Begin();
                if (p.m_name == name)
                {
                    fsmParameter.End();
                    return p;
                }
                fsmParameter.End();
            }
            return null;
        }

        public void StartStateMachine()
        {
            m_update = true;
        }

        public void StopStateMachine()
        {
            m_update = false;
        }

        static ProfilerMarker fsmUpdate = new ProfilerMarker("State machine update function");
        static ProfilerMarker fsmConditionCheck = new ProfilerMarker("State condition check");
        static ProfilerMarker fsmUpdateState = new ProfilerMarker("State update");
        static ProfilerMarker fsmStartState = new ProfilerMarker("State start");

        public void UpdateStateMachine()
        {
            fsmUpdate.Begin();
            if (m_update)
            {
                fsmConditionCheck.Begin();
                foreach(BaseConnection connection in m_currentState.m_connections)
                {
                    if (connection.Condition())
                    {
                        m_currentState = connection.m_state;
                        if (m_previousState != null)
                        {
                            m_previousState.StopState();
                        }
                    }
                }
                fsmConditionCheck.End();

                if (m_previousState == m_currentState)
                {
                    fsmUpdateState.Begin();
                    m_currentState.UpdateState();
                    fsmUpdateState.End();
                }
                else
                {
                    fsmStartState.Begin();
                    m_previousState = m_currentState;
                    m_currentState.StartState();
                    fsmStartState.End();
                }
            }
            fsmUpdate.End();
        }
    }
}