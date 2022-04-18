using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int hiScore;
    public string hiName;
    public string playerName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHiScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int hiScore;
        public string hiName;
    }

    public void SaveHiScore()
    {
        SaveData data = new SaveData();
        data.hiScore = hiScore;
        data.hiName = hiName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            hiScore = data.hiScore;
            hiName = data.hiName;
        }

    }
}
