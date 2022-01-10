using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    
    private static GameDataManager _instance;

    public static GameDataManager Instance { get { return _instance; } }


    public void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        } else
        {
            _instance = new GameDataManager();
            DontDestroyOnLoad(gameObject);
        }
    }
}
