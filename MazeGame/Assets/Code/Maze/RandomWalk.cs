using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MazeGame.Maze
{
    public class RandomWalk : MonoBehaviour
    {
        private List<bool> m_cells = new List<bool>();
        public List<int> m_walkers = new List<int>();
        public int m_gridSize = 50;
        public int m_seed = 42389;
        private int[] m_directions = null;
        public int m_iterations = 100;
        public float m_cellSize = 1f;

        private void Start()
        {
            m_directions = new int[4];
            m_directions[0] = -1;
            m_directions[1] = -m_gridSize;
            m_directions[2] = 1;
            m_directions[3] = m_gridSize;

            for (int i = 0; i < m_gridSize * m_gridSize; i++)
            {
                m_cells.Add(true); // True = a wall.
            }
            StartCoroutine(WaitBeginning());
        }

        private IEnumerator WaitBeginning()
        {
            yield return new WaitForSeconds(2f);
            StartCoroutine(Iterate());
            yield return null;
        }

        private IEnumerator Iterate()
        {
            Random.InitState(m_seed);
            for (int j = 0; j < m_iterations; j++)
            {
                for (int i = 0; i < m_walkers.Count; i++)
                {
                    m_cells[m_walkers[i]] = false; // False = a floor.
                    int v = Random.Range(0, 4);
                    int newInd = m_walkers[i] + m_directions[v];
                    if (IsInside(newInd))
                    {
                        m_walkers[i] = newInd;
                    }
                }
                yield return new WaitForSeconds(.1f);
            }
            yield return null;
        }

        private bool IsInside(int v)
        {
            if (v < 0)
            {
                return false;
            }
            if (v > m_gridSize * m_gridSize)
            {
                return false;
            }
            return true;
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i  < m_cells.Count; ++i)
            {
                float x = (i % this.m_gridSize);
                float y = (i / this.m_gridSize);
                Vector3 p = new Vector3(x, 0f, y);
                if (m_cells[i])
                {
                    Gizmos.color = Color.grey;
                }
                else
                {
                    Gizmos.color = Color.white;
                }

                for (int j = 0; j < m_walkers.Count; ++j)
                {
                    if (i == m_walkers[j])
                    {
                        Gizmos.color = Color.yellow;
                    }
                }

                Gizmos.DrawCube(p, new Vector3(m_cellSize, 0.01f, m_cellSize));
            }
        }
    }
}