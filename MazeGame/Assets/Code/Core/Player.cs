using UnityEngine;

namespace MazeGame.Core
{
    public class Player : BaseCharacter
    {
        public Player(PlayerComponent comp)
        {
            this.m_characterInstance = comp.gameObject;
            this.m_rb = this.m_characterInstance.GetComponent<Rigidbody>();
        }

        public void TurnPlayer(Vector2 mouseDelta)
        {
            m_characterInstance.transform.Rotate(0, mouseDelta.x * 0.2f, 0f);
        }

        public void Move(Vector2 wasd)
        {
            Vector3 v = new Vector3(wasd.x, 0f, wasd.y) * 1000f * Time.deltaTime;
            Vector3 f = m_rb.transform.TransformVector(v);
            if (m_rb.linearVelocity.sqrMagnitude < 100f)
            {
                m_rb.AddForce(f, ForceMode.Force);
            }
        }
    }
}