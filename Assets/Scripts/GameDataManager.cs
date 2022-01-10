using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    //Singleton purpose
    private static GameDataManager _instance;
    public static GameDataManager Instance { get { return _instance; } }

    private SaveDataSet _saveDataSet;
    private string _path;



    // Unity defined method calls

    public void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        } else
        {
            _path = Application.persistentDataPath + "/safefile.json";
            LoadFromFile(_path);
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }



    //Custom methods



    //Class used to score Highscoredata
    [System.Serializable]
    public class SaveData
    {
        public string Name;
        public int Highscore;
    }

    [System.Serializable]
    public class SaveDataSet
    {
        public SaveData[] savedHighScores = new SaveData[10];
        public int spawnRate;
    }

    public void UpdateSpawnrate(int newSpawnrate)
    {
        _saveDataSet.spawnRate = newSpawnrate;
        WriteToFile(_saveDataSet);
    }

    public int GetSpawnRate()
    {
        return _saveDataSet.spawnRate;
    }


    public void SetSpawnRate(int i)
    {
        if (i < 1 || i > 300)
        {
            return;
        }
        
        _saveDataSet.spawnRate = i;
        WriteToFile(_saveDataSet);
    }



    public bool SaveScore(string name, int score)
    {

        for (int i = 0; i < _saveDataSet.savedHighScores.Length; i++)
        {
            if (score >= _saveDataSet.savedHighScores[i].Highscore)
            {
               _saveDataSet.savedHighScores = ReplaceHighScore(i, name, score, _saveDataSet.savedHighScores);
                WriteToFile(_saveDataSet);
            }
        }

        return false;
    }

    private SaveData[] ReplaceHighScore(int index, string name, int score, SaveData[] savedHighScores)
    {
        SaveData m_OldData;
        SaveData m_NewData = new SaveData();
        
        m_NewData.Name = name;
        m_NewData.Highscore = score;
        
        
        for (int i = index; i < savedHighScores.Length;  i++ )
        {
            m_OldData = savedHighScores[i];
            savedHighScores[i] = m_NewData;
            m_NewData = m_OldData;
        }
        return savedHighScores;
    }

    // Writing and reading from and to file
    private void WriteToFile(SaveDataSet data)
    {
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(_path, json);
    }

    private void LoadFromFile(string path)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            _saveDataSet = JsonUtility.FromJson<SaveDataSet>(json);
        } else
        {
            _saveDataSet = new SaveDataSet();
            _saveDataSet.spawnRate = 60;
            WriteToFile(_saveDataSet);
        }
    }
}
