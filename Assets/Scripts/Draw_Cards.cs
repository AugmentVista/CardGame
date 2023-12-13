using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Draw_Cards : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public WinScreen winScreen;
    public CardFlipper cardflipper;

    public ScoreText ScoreText;
    
    public void OnClick()
    {
        PlayerManager.DealCards();
        ScoreText.WinScore = ScoreText.Score;
        winScreen.Win();  
    }
}
