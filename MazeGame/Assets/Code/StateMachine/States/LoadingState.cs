using StateMachine.Core;
using MazeGame.Core;
using MazeGame.Components.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using MazeGame.Components;
using MazeGame.Maze;

namespace StateMachine.States
{
    public class LoadingState : BaseState
    {
        public LoadingState(StateMachine.Core.StateMachine fsm) : base(fsm)
        {
        }

        public override void StartState()
        {
            base.StartState();
            SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive);
        }

        public override void UpdateState()
        {
            Scene s = SceneManager.GetSceneByName("Level");
            if (s.isLoaded)
            {
                Game.m_levelController = (LevelController)Game.GetController(s);
                if (Game.m_levelController != null )
                {
                    PlayerComponent pc = GameObject.FindAnyObjectByType<PlayerComponent>();
                    Game.m_player = new Player(pc);
                    EnemyComponent ec = GameObject.FindAnyObjectByType<EnemyComponent>();
                    Game.m_enemy = new MazeGame.Core.Enemy(ec);
                    Game.m_levelController.Deactive();
                    m_stateMachine.AddParameter("Gameplay", true);

                    SceneManager.SetActiveScene(s);
                    Maze m = Game.m_levelController.m_visualRoot.GetComponentInChildren<Maze>();
                    if (m != null)
                    {
                        Game.m_maze = m;
                        CellComponent[] comps = Game.m_levelController.m_visualRoot.GetComponentsInChildren<CellComponent>();
                        Cell[] cells = new Cell[comps.Length];
                        for (int i=0 ; i<comps.Length; i++)
                        {
                            if (comps[i].m_floor)
                            {
                                cells[i] = new RoomCell();
                            }
                            else
                            {
                                cells[i] = new WallCell();
                            }
                            cells[i].m_instacedGo = comps[i].gameObject;
                        }
                        Game.m_maze.m_maze = cells;
                        Game.m_maze.m_indiciesCount = cells.Length;
                    }
                }
            }
        }
    }
}
