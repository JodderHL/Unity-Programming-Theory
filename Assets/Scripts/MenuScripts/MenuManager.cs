using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _MainMenuRootObject;
    [SerializeField] private GameObject _OptionsMenuRootObject;


    public void Awake()
    {
        _MainMenuRootObject.SetActive(true);
        _OptionsMenuRootObject.SetActive(false);
    }

    public void SwitchToOptionsMenu()
    {
        _MainMenuRootObject.SetActive(false);
        _OptionsMenuRootObject.SetActive(true);
    }

    public void SwitchToMainMenu()
    {
        _MainMenuRootObject.SetActive(true);
        _OptionsMenuRootObject.SetActive(false);
    }
}
