using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private double _spawnTimer;
    private int _CurrentTargetCount;

    [SerializeField] int _MaximumConcurrentTargetCount;
    [SerializeField] private GameObject _HUDContainer;
    [SerializeField] private GameObject _MenuContainer;
    [SerializeField] private GameObject[] _TargetPrefabs;
    // ENCAPSULATION
    private static bool _IsGameActive;
    public static bool IsGameActive { get { return _IsGameActive; } }
    // Start is called before the first frame update
    void Start()
    {
        ChangeToPlayMode();
        _CurrentTargetCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_IsGameActive)
            {
                ChangeToMenuMode();
            }
            else
            {
                ChangeToPlayMode();
            }
        }

        if (_IsGameActive)
        {
            if (CheckSpawnTimer())
            {
                if (_CurrentTargetCount > _MaximumConcurrentTargetCount)
                {
                    GameOver();
                }
                 else
                {
                    SpawnNewTarget();
                }
            }
        }
    }


    void ChangeToPlayMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _HUDContainer.SetActive(true);
        _MenuContainer.SetActive(false);
        _IsGameActive = true;
    }

    void ChangeToMenuMode()
    {
        _HUDContainer.SetActive(false);
        _MenuContainer.SetActive(true);
        _IsGameActive = false;
        Cursor.lockState = CursorLockMode.Confined;
    }


    private bool CheckSpawnTimer()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= GameDataManager.Instance.GetSpawnRate())
        {
            _spawnTimer = 0;
            return true;
        }
        return false;
    }

    private void SpawnNewTarget()
    {

    }

    private void GameOver()
    {

    }

}
