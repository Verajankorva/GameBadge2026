using MazeGame.Core;
using StateMachine.Core;
using UnityEngine;

namespace StateMachine.States
{
    public class GameplayState : BaseState
    {
        public GameplayState(StateMachine.Core.StateMachine fsm) : base(fsm)
        {
        }

        public override void StartState()
        {
            base.StartState();
            Game.m_input.OnMove += M_input_OnMove;
            Game.m_input.OnLook += M_input_OnLook;
            Game.m_levelController.Active();
            Game.m_enemy.m_stateMachine.StartStateMachine();
            Game.m_gameData.m_scene = Game.m_levelController.gameObject.scene;
            // TODO: Handle this in load save game state.
            Game.m_gameData.LoadData();
            Game.m_player.m_rb.transform.position = Game.m_gameData.m_playerPosition;
            Game.m_player.m_rb.transform.rotation = Game.m_gameData.m_playerRotation;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            Game.m_enemy.Update();
        }

        public override void StopState()
        {
            base.StopState();
            Game.m_input.OnMove -= M_input_OnMove;
            Game.m_input.OnLook -= M_input_OnLook;
        }

        private void M_input_OnLook(UnityEngine.Vector2 v)
        {
            Game.m_player.TurnPlayer(v);
        }

        private void M_input_OnMove(UnityEngine.Vector2 v)
        {
            Game.m_player.Move(v);
        }
    }
}