using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public TextMesh playerScoreText;
    public TextMesh highestScoreText;

    void Start()
    {
        // Get player's score from player preferences.
        int score = PlayerPrefs.GetInt("Player Score");
        playerScoreText.text = score.ToString();

        // Get highest score from player preferences.
        int highestScore = PlayerPrefs.GetInt("Highest Score");
        highestScoreText.text = highestScore.ToString();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 6 * 5, 100, 40), "PLAY AGAIN"))
        {
            SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
        }
    }
}