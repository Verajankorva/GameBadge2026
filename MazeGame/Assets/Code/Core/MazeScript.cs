using UnityEngine;
using MoonSharp.Interpreter;
using System.IO;
using System;

namespace MazeGame.Core
{
    public class MazeScript
    {
        public Script m_script = null;
        private string m_startupScript = "";
        private string m_levelScript = "";

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
            string levelFile = Application.dataPath + "/Resources/Lua/level.lua";
            m_levelScript = File.ReadAllText(levelFile);
            m_script.Options.DebugPrint = s => { Debug.Log(s); };
            m_script.Globals["GetDialogueLine"] =
                (Func<int, string>)GetDialogueLine;
            m_script.Globals["SetIntroText"] =
                (Action<string>)SetIntroText;
        }

        public void RunStartup()
        {
            m_script.DoString(m_startupScript);
        }

        public void RunLevel()
        {
            m_script.DoString(m_levelScript);
            DynValue v = m_script.Globals.Get("OnDialogue");
            DynValue c = m_script.Call(v, DynValue.NewNumber(1));
        }

        private static string GetDialogueLine(int id)
        {
            string s = Game.m_dialogueDatabase.ReadDialogueLine(id);
            return s;
        }

        private static void SetIntroText(string text)
        {
            Game.m_introController.SetIntroText(text);
        }

    }
}