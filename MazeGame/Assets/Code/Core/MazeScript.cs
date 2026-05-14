using UnityEngine;
using MoonSharp.Interpreter;
using System.IO;

namespace MazeGame.Core
{
    public class MazeScript
    {
        public Script m_script = null;
        private string m_startupScript = "";

        public MazeScript()
        {
            Debug.Log(string.Format("Object {0} creeated", this.GetType().Name));
            m_script = new Script();
        }

        public void LoadScript()
        {
            Debug.Log("Loading scripts.");
            string startupFile = Application.dataPath + "/Resources/Lua/startup.lua";
            m_startupScript = File.ReadAllText(startupFile);
            m_script.Options.DebugPrint = s => { Debug.Log(s); };
        }

        public void RunStartup()
        {
            m_script.DoString(m_startupScript);
        }
    }
}