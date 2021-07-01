using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scorePoint;
    public int topScorePoint;

    public Text printScorePoint;
    public Text printTopScorePoint;

    void Start()
    {
        topScorePoint = PlayerPrefs.GetInt("TopScore", 0);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Ingame"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        scorePoint = PlayerPrefs.GetInt("Score", 0);
    }

    void Update()
    {
        PlayerPrefs.SetInt("Score", scorePoint);
        printScorePoint.text = $"Score : {scorePoint.ToString("0")}";

        if(scorePoint > topScorePoint)
        {
            topScorePoint = scorePoint;

            PlayerPrefs.SetInt("TopScore", topScorePoint);
        }

        printTopScorePoint.text = $"TopScore : {topScorePoint.ToString("0")}";
    }
}
