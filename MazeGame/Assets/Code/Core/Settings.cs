using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace MazeGame.Core
{
    [Serializable]
    public class Settings
    {
        [NonSerialized] private static Settings instance = null;
        public string m_language = "eng";
        public Color m_color = Color.green;

        private Settings()
        {
        }

        public void Write()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using(TextWriter writer = new StreamWriter(Application.persistentDataPath + "/settings.xml"))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static Settings Read()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof (Settings));
                using (TextReader reader = new StreamReader(Application.persistentDataPath + "/settings.xml"))
                {
                    instance = (Settings)serializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                instance = new Settings();
            }
            return instance;
        }

        public static Settings CreateInstance()
        {
            if(instance == null)
            {
                instance = new Settings();
            }
            return instance;
        }
    }
}