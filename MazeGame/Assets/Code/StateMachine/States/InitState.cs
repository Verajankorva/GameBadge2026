using MazeGame.Core;
using StateMachine.Core;
using UnityEngine;

namespace StateMachine.States
{
    public class InitState : BaseState
    {
        public InitState(StateMachine.Core.StateMachine fsm) : base(fsm)
        {

        }

        public override void StartState()
        {
            base.StartState();
            Game.m_gameStateMachine.AddParameter("Load", true);
        }
    }
}
