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
    [SerializeField]
    private TextMeshProUGUI ComboCountText;
    public int WinScore;
    public int Score;
    public int AIscore;
    public bool cardFlipBool;

    public void OnFlip(CardFlipper cardFlipper, PlayerManager playerManager)
    {
        PlayerManager = playerManager;
        cardFlipBool = cardFlipper.timesFlipped <= 10;
        var childGameObject = cardFlipper.gameObject;
        UpdateScore(childGameObject, cardFlipper);
        UpdateUI();
    }

    public void UpdateScore(GameObject childGameObject, CardFlipper cardFlipper)
    {
        ComboCountText.text = "Combo Count: " + CardFlipper.comboCount.ToString();
        if (childGameObject.name.StartsWith("Card") && (cardFlipper.currentSprite == cardFlipper.CardBack || cardFlipper.isEnemyCard) && cardFlipBool)
        {
            if (cardFlipper.isEnemyCard)
            {
                AIscore += cardFlipper.valueOfCard;
                AICountText.text = "AI Score: " + AIscore.ToString();
            }
            if (cardFlipper.isEnemyCard == false)
            { 
                Score += cardFlipper.valueOfCard;
                CountText.text = "Score: " + Score.ToString();
            }
        }
    }
    public void UpdateUI()
    {
        WinScore = Score;
        winScreen.Win();
    }
}