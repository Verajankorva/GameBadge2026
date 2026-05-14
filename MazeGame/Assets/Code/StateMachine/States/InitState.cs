using MazeGame.Core;
using StateMachine.Core;
using System.IO;
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
            Game.m_gameData = new GameData();
            Game.m_script.RunStartup();
            Game.m_gameStateMachine.AddParameter("Load", true);
            if (File.Exists(Application.persistentDataPath + "/settings.xml"))
            {
                Settings set = Settings.Read();
                Debug.Log(set.m_language);
                Debug.Log(set.m_color.ToString());
            }
            else
            {
                Settings set = Settings.CreateInstance();
                set.Write();
            }
        }
    }
}
