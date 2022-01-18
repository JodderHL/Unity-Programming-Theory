using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{

    [SerializeField] private Text _CurrentScore;
    [SerializeField] private InputField _NameInputField;
    [SerializeField] private Button _RegisterScoreButton;
    [SerializeField] private GameObject _GridLayoutContainer;
    [SerializeField] private GameObject _TextPrefab;


    private bool _NewHighscore;
    private GameDataManager.SaveDataSet _SaveDataSet;

    private int _Score;
    public int Score { get { return _Score; } set { if (ValidateScore(value)) { _Score = value; } } }


    private void Start()
    {
        _NewHighscore = false;
        _SaveDataSet = GameDataManager.Instance.GetSaveDataSet;
        _RegisterScoreButton.interactable = false;

        LoadHighscores();
    }


    private void Update()
    {
        if (_NameInputField.text != "" && _NewHighscore)
        {
            _RegisterScoreButton.interactable = true;
        } else
        {
            _RegisterScoreButton.interactable= false;
        }
    }



    private bool ValidateScore(int i)
    {
        _CurrentScore.text = "Your Score: " + i;
        foreach (GameDataManager.SaveData data in _SaveDataSet.savedHighScores)
        {
            if (_SaveDataSet.savedHighScores.Length<10 || i > data.Highscore)
            {
                _NewHighscore = true;
                return true;
            }
        }
        _NameInputField.interactable = false;
        _NameInputField.placeholder.GetComponent<Text>().text = "Lol you suck";
        return false;
    }

    public void SaveHighScore()
    {
        GameDataManager.Instance.SaveScore(_NameInputField.text, _Score);
        _NewHighscore = false;
        _NameInputField.interactable = false;

        LoadHighscores();
    }


    private void LoadHighscores()
    {

        foreach (Transform child in _GridLayoutContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        int m_Place = 1;
        foreach (GameDataManager.SaveData data in _SaveDataSet.savedHighScores)
        {
            GameObject m_TempTextGO = Instantiate(_TextPrefab, new Vector3(0, 0, 0), Quaternion.identity, _GridLayoutContainer.transform);
            m_TempTextGO.GetComponent<Text>().text = m_Place.ToString();
            GameObject m_TempTextGO2 = Instantiate(_TextPrefab, new Vector3(0, 0, 0), Quaternion.identity, _GridLayoutContainer.transform);
            m_TempTextGO2.GetComponent<Text>().text = data.Name;
            GameObject m_TempTextGO3 = Instantiate(_TextPrefab, new Vector3(0, 0, 0), Quaternion.identity, _GridLayoutContainer.transform);
            m_TempTextGO3.GetComponent<Text>().text = data.Highscore.ToString();
            m_Place++;
        }
    }

}
