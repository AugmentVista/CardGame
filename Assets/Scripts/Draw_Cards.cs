using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Draw_Cards : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public WinScreen winScreen;

    public ScoreText ScoreText;

    public void OnClick()
    {
        PlayerManager.DealCards();
        ScoreText.WinScore = ScoreText.Score;
        winScreen.Win();
        Console.WriteLine("Win(); is working in Draw_Cards");
        
    }
}
