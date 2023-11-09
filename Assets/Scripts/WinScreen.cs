using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WinScreen : MonoBehaviour
{
    public GameObject WinText;
    public ScoreText ScoreText;
    public int randomWinScore;
    public PlayerManager PlayerManager;
    public TextMeshProUGUI rulesText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI AI_rulesText;

    void Start()
    {
        winText = GameObject.Find("WinText").GetComponent<TextMeshProUGUI>();
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        WinText.SetActive(false);
        ScoreText.WinScore = Random.Range(12, 20);

        randomWinScore = Random.Range(12, 20);
        rulesText.text = "Exact score of " + randomWinScore.ToString() + " to Win ";

        AI_rulesText.text = "Exact score of " + randomWinScore.ToString() + " to Win ";


    }
    public void Win()
    {
        Debug.Log("CardsDrawn = " + PlayerManager.cardsDrawn);
        if (ScoreText.WinScore == randomWinScore)
        {
            WinText.SetActive(true);
        }
        else if (ScoreText.WinScore != randomWinScore && PlayerManager.cardsDrawn > 10)
        {
            WinText.SetActive(true);
            winText.text = "You Lose";
        }
        else
        {
            rulesText.text = "Exact score of " + randomWinScore.ToString() + " to Win ";
        }
        
    }
}
