using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WinScreen : MonoBehaviour
{
    public TMP_Text WinText;
    public ScoreText ScoreText;
    public int randomWinScore;
    public int AIrandomWinScore;
    public Health_System Health;
    public PlayerManager PlayerManager;
    public TextMeshProUGUI rulesText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI AI_rulesText;

    void Start()
    {
        winText = GameObject.Find("WinText").GetComponent<TextMeshProUGUI>();
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        Health = FindObjectOfType<Health_System>();
        WinText.enabled = false;
        randomWinScore = Random.Range(15, 31);
        rulesText.text = "Exact score of " + randomWinScore.ToString() + " to Win ";

        AIrandomWinScore = Random.Range(15, 31);
        AI_rulesText.text = "AI needs " + AIrandomWinScore.ToString() + " to Win ";
    }
    public void Win()
    {
        if (ScoreText.WinScore == randomWinScore)
        {
            WinText.enabled = true;
        }
        else if (ScoreText.WinScore != randomWinScore && (PlayerManager.cardsDrawn > 100 || ScoreText.AIscore == AIrandomWinScore || Health.currentPlayerHealth <= 0))
        {
            WinText.enabled = true;
            winText.text = "You Lose";
        }
        else
        {
            rulesText.text = "Exact score of " + randomWinScore.ToString() + " to Win ";
        }
        
    }
}
