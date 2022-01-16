using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _HUDContainer;
    [SerializeField] private GameObject _MenuContainer;
    private static bool _IsGameActive;
    public static bool IsGameActive { get { return _IsGameActive; } }
    // Start is called before the first frame update
    void Start()
    {
        ChangeToPlayMode();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_IsGameActive)
            {
                ChangeToMenuMode();
            } else
            {
                ChangeToPlayMode();
            }
        }
    }

    void ChangeToPlayMode()
    {
        Cursor.visible = false;
        _HUDContainer.SetActive(true);
        _MenuContainer.SetActive(false);
        _IsGameActive = true;
    }

    void ChangeToMenuMode()
    {
        Cursor.visible = true;
        _HUDContainer.SetActive(false);
        _MenuContainer.SetActive(true);
        _IsGameActive = false;
    }

}
