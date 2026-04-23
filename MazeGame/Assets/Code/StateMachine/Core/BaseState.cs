using System.Collections.Generic;
using System;
using UnityEngine;

namespace StateMachine.Core
{
    public class BaseState
    {
        private Guid m_guid = Guid.Empty;
        public List<BaseConnection> m_connections = null;

        public BaseState()
        {
            m_guid = Guid.NewGuid();
            Debug.Log(string.Format("{0} create with a guid {1}.", this.GetType(), this.m_guid.ToString()));
            m_connections = new List<BaseConnection>();
        }

        public void AddOutputConnection(BaseConnection con)
        {
            this.m_connections.Add(con);
            Debug.Log(string.Format("Connection {0} {1} added.", con.m_guid.ToString(), con.GetType()));
        }

        virtual public void StartState()
        {
            Debug.Log(string.Format("{0} {1} StartState().", m_guid.ToString(), this.GetType()));
        }

        virtual public void StopState()
        {
            Debug.Log(string.Format("{0} {1} StopState().", m_guid.ToString(), this.GetType()));
        }

        virtual public void UpdateState()
        {
            //Debug.Log(string.Format("{0} {1} UpdateState().", m_guid.ToString(), this.GetType()));
        }
    }
}