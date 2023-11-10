using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI AICountText;
    public PlayerManager PlayerManager;
    public TextMeshProUGUI rulesText;
    public WinScreen winScreen;
    public int Card1Value = 1;
    public int Card2Value = 2;
    public int Card3Value = 3;
    public int Card4Value = -4;
    public int WinScore;
    public int Score;
    public int AIscore;
    public bool cardFlipBool;

    // CHANGE TARGET SCORES TO HP, POSTIVE CARDS DAMAGE YOUR OPPONENT NEGATIVE CARDS HEAL YOU.
    public void OnFlip(CardFlipper cardFlipper, PlayerManager playerManager)
    {
        PlayerManager = playerManager;

        cardFlipBool = cardFlipper.timesFlipped <= 10;

        Debug.Log("OnFlip is being called");

        var childGameObject = cardFlipper.gameObject;
        UpdateScore(childGameObject, cardFlipper);

        CountText.text = "Current Score " + Score.ToString();
        AICountText.text = "Current Score " + AIscore.ToString();
        UpdateUI();
    }

    public void UpdateScore(GameObject childGameObject, CardFlipper cardFlipper)
    {
        Debug.Log(childGameObject + " sdtgsrhrdhdsth");
        if (childGameObject.name.StartsWith("Card") && (cardFlipper.currentSprite == cardFlipper.CardBack || cardFlipper.isEnemyCard) && cardFlipBool)
        {
            if (cardFlipper.isEnemyCard)
            {
                AIscore += cardFlipper.valueOfCard;
                AICountText.text = "Current Score " + AIscore.ToString();
            }
            if (cardFlipper.isEnemyCard == false)
            { 
                Score += cardFlipper.valueOfCard;
                CountText.text = "Current Score " + Score.ToString();
            }
        }
    }
    public void UpdateUI()
    {
        WinScore = Score;
        winScreen.Win();
    }
}