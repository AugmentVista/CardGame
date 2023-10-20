using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WinScreen : MonoBehaviour
{
    public GameObject WinText;
    public ScoreText ScoreText;
    public int randomWinScore;
    public TextMeshProUGUI rulesText;

    void Start()
    {
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        WinText.SetActive(false);
        ScoreText.WinScore = Random.Range(12, 25);

        randomWinScore = Random.Range(12, 25);
        rulesText.text = "Exact score of " + randomWinScore.ToString() + " to Win ";
    }
    public void Win()
    {
        if (ScoreText.WinScore == randomWinScore)
        {
            WinText.SetActive(true);
        }
        else 
        {
            rulesText.text = "Exact score of " + randomWinScore.ToString() + " to Win ";
        }
    }
}
