using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject DropZone;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI rulesText;
    public WinScreen winScreen;
    private int Card1inPlay; 
    private int Card2inPlay; 
    private int Card3inPlay;
    public int Card1Value = 1;
    public int Card2Value = 2;
    public int Card3Value = 3;
    public int WinScore;
    public int Score;
    public bool cardFlipBool;

    private void Start()
    {
        rulesText.enabled = false;
        CountText.enabled = false;
    }

    public void OnFlip(CardFlipper cardFlipper)
    {
        if (cardFlipper.timesFlipped < 3)
        { 
            cardFlipBool = true;
        }
        else
        {
            cardFlipBool = false;
        }
        var childGameObject = cardFlipper.gameObject;
        
        if (childGameObject.name.StartsWith("Card1") && cardFlipper.currentSprite == cardFlipper.CardBack && cardFlipBool)
        {
            
            Card1inPlay++;
            Score += Card1Value;
            CountText.text = "Current Score " + Score.ToString();
        }
        if (childGameObject.name.StartsWith("Card2") && cardFlipper.currentSprite == cardFlipper.CardBack && cardFlipBool)
        {
            
            Card2inPlay++;
            Score += Card2Value;
            CountText.text = "Current Score " + Score.ToString();
        }
        if (childGameObject.name.StartsWith("Card3") && cardFlipper.currentSprite == cardFlipper.CardBack && cardFlipBool)
        {

            Card3inPlay++;
            Score += Card3Value;
            CountText.text = "Current Score " + Score.ToString();
        }
        UpdateUI();
    }
    public void UpdateUI()
    {
        WinScore = Score;
        winScreen.Win();
    }
}