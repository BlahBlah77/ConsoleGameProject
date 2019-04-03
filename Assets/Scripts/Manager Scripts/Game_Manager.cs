using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Game_Manager : MonoBehaviour {

    private static Game_Manager instance = null;

    [Header("Game Bools")]
    public bool isGameOver = false;
    public bool isPaused = false;
    public float volumeValue;

    public static Game_Manager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
        OptionLoad();
    }

    class OptionsFile
    {
        public float volume;
    }

    public void OptionSave()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/OptionFile.dat");
        OptionsFile data = new OptionsFile();
        data.volume = AudioListener.volume;
        volumeValue = AudioListener.volume;

        bf.Serialize(file, data);
        file.Close();
    }

    public void OptionLoad()
    {
        if (File.Exists(Application.persistentDataPath + "/OptionFile.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/OptionFile.dat", FileMode.Open);
            OptionsFile data = (OptionsFile)bf.Deserialize(file);
            file.Close();

            AudioListener.volume = data.volume;
            volumeValue = data.volume;

        }
    }
}
