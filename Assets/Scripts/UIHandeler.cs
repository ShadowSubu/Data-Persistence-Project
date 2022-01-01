using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class UIHandeler : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    public InputField PlayerNameInput;

    private void Start()
    {
        PersistenceManager.Instance.LoadHightScore();
        string name = PersistenceManager.Instance.PlayerName;
        int score = PersistenceManager.Instance.PlayerScore;

        HighScoreText.text = $"Best Score : {name} : {score}";
        PlayerNameInput.text = name;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        PersistenceManager.Instance.PlayerName = PlayerNameInput.text;
    }

    public void Exit()
    {
        PersistenceManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}