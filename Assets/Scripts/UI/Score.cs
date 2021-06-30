using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scorePoint;

    public Text printScorePoint;

    void Update()
    {
        printScorePoint.text = $"Score : {scorePoint.ToString("0")}";
    }
}
