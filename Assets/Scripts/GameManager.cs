using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public int highScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadHighScoreData();
    }

    [System.Serializable]
    class HighScoreData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveHighScoreData()
    {
        HighScoreData data = new HighScoreData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
        }
    }

    public void ResetData()
    {
        HighScoreData data = new HighScoreData();
        data.playerName = "ResetData";
        data.highScore = 0;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        LoadHighScoreData();
        SceneManager.LoadScene(0);
    }
}
