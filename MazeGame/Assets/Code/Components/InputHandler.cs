using UnityEngine;
using UnityEngine.InputSystem;
using MazeGame.Core;

namespace MazeGame.Components
{
    public class InputHandler : MonoBehaviour
    {
        private bool m_moving = false;
        private Vector2 m_moveVelocity = Vector2.zero;

        private void Start()
        {
        }

        private void Update()
        {
            if (m_moving)
            {
                Game.m_input.InputMove(m_moveVelocity);
                if (m_moveVelocity.magnitude == 0f)
                {
                    m_moving = false;
                }
            }
        }

        public void OnMove(InputValue v)
        {
            m_moveVelocity = v.Get<Vector2>();
            m_moving = true;
        }

        public void OnLook(InputValue v)
        {
            Game.m_input.InputLook(v.Get<Vector2>());
        }
    }
}