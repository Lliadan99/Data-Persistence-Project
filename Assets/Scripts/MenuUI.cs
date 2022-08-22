using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI displayHighScoreText;

    void Update()
    {
        DisplayHighScore();
    }

    public void DisplayHighScore()
    {
        if(GameManager.Instance.playerName != "ResetData")
        {
            displayHighScoreText.text = "High Score: " + GameManager.Instance.highScore + "   -  " + GameManager.Instance.playerName;
        }
    }

    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitBtn()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
