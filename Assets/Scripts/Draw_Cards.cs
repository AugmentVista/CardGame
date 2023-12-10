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
        int comboCount = 1;
        if (PlayerManager.CardPlayOrder.Count > 0)
        {

            GameObject lastPlayedCard = null;
            GameObject currentPlayedCard = PlayerManager.CardPlayOrder[PlayerManager.CardPlayOrder.Count - 1];
            if (PlayerManager.CardPlayOrder.Count > 1)
            {
                lastPlayedCard = PlayerManager.CardPlayOrder[PlayerManager.CardPlayOrder.Count - 2];
            }
            string lastCardName = (lastPlayedCard != null) ? lastPlayedCard.name : "None";
            Debug.Log("Last card played: " + lastCardName);

            string currentCardName = currentPlayedCard.name;
            Debug.Log("Current card played: " + currentCardName);


            if (lastPlayedCard != null && lastCardName == currentCardName)
            {
                Debug.Log("Last card and current card are the same.");


                Debug.Log("Before incrementing comboCount. Combo count is: " + comboCount);
                comboCount++;
                Debug.Log("After incrementing comboCount. Combo count is: " + comboCount);



                Debug.Log("Combo count is: " +comboCount);

                ScoreText.Score = ScoreText.Score + comboCount;
            }
            else if (lastPlayedCard != null && lastCardName != currentCardName)
            {
                comboCount = 0;
                Debug.Log("Combo count is: " + comboCount);

            }
        }
    }
}
