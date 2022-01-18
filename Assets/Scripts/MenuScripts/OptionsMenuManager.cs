using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsMenuManager : MonoBehaviour
{

    // ENCAPSULATION
    [SerializeField] private InputField _spawnRateInput;
    [SerializeField] private Button _saveButton;


    public void Awake()
    {
        _saveButton.interactable = false;
        _spawnRateInput.text = "";
    }


    public void Update()
    {
        if (_spawnRateInput.text != "")
        {
            _saveButton.interactable = true;
        } else
        {
            _saveButton.interactable= false;
        }
    }

    public void OnSaveClick()
    {
        int m_Temp;
        int.TryParse(_spawnRateInput.text, out m_Temp);
        GameDataManager.Instance.SetSpawnRate(m_Temp);
        _spawnRateInput.text = "";
    }
}
