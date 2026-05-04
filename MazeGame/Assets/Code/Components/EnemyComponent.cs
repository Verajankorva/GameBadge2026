using UnityEngine;
using UnityEngine.AI;

namespace MazeGame.Components
{
    public class EnemyComponent : MonoBehaviour
    {
        [HideInInspector]
        public NavMeshAgent m_agent = null;

        private void Start()
        {
            m_agent = GetComponent<NavMeshAgent>();
        }
    }
}