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
    public PlayerManager PlayerManager;
    public TextMeshProUGUI rulesText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI AI_rulesText;

    void Start()
    {
        winText = GameObject.Find("WinText").GetComponent<TextMeshProUGUI>();
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        WinText.enabled = false;
        ScoreText.WinScore = Random.Range(12, 20);

        randomWinScore = Random.Range(12, 20);
        rulesText.text = "Exact score of " + randomWinScore.ToString() + " to Win ";

        AIrandomWinScore = Random.Range(12, 20);
        AI_rulesText.text = "AI needs " + AIrandomWinScore.ToString() + " to Win ";
        Debug.Log(rulesText);
        Debug.Log(rulesText.text);
    }
    public void Win()
    {
        Debug.Log("CardsDrawn = " + PlayerManager.cardsDrawn);
        if (ScoreText.WinScore == randomWinScore)
        {
            WinText.enabled = true;
        }
        else if (ScoreText.WinScore != randomWinScore && PlayerManager.cardsDrawn > 10)
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
