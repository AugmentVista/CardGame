using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject DropZone;
    public TextMeshProUGUI CountText;
    public WinScreen winScreen;
    private int Card1inPlay; // Initialize to 0
    private int Card2inPlay; // Initialize to 0
    public int Card1Value = 1;
    public int Card2Value = 2;
    public int WinScore;
    public int Score;
    public int WinThresholdValue = 15;
    public bool cardFlipBool;

    private void Start()
    {
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
        //Debug.Log(childGameObject.name == "Card1");
        if (childGameObject.name.StartsWith("Card1") && cardFlipper.currentSprite == cardFlipper.CardBack && cardFlipBool)
        {
            Debug.Log("We did it");
            Card1inPlay++;
            Score += Card1Value;
            CountText.text = Score.ToString();
        }
        if (childGameObject.name.StartsWith("Card2") && cardFlipper.currentSprite == cardFlipper.CardBack && cardFlipBool)
        {
            Debug.Log("We did it");
            Card2inPlay++;
            Score += Card2Value;
            CountText.text = Score.ToString();
        }
        //Debug.Log("Number of Card1 in play: " + Card1inPlay);
        //Debug.Log("Number of Card2 in play: " + Card2inPlay);
        //Debug.Log(Card1Value);
        //Debug.Log(Card2Value);
        
        UpdateUI();
    }
    public void UpdateUI()
    {
        WinScore = Score;
        winScreen.Win();
    }
}