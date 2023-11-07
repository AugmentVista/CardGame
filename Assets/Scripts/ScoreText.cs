using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject DropZone;
    public TextMeshProUGUI CountText;
    public PlayerManager PlayerManager;
    public TextMeshProUGUI rulesText;
    public WinScreen winScreen;
    private int Card1inPlay; 
    private int Card2inPlay; 
    private int Card3inPlay;
    private int Card4inPlay;
    public int Card1Value = 1;
    public int Card2Value = 2;
    public int Card3Value = 3;
    public int Card4Value = 4;
    public int WinScore;
    public int Score;
    public bool cardFlipBool;

    private void Start()
    {
        rulesText.enabled = false;
        CountText.enabled = false;
        
    }
    // CHANGE TARGET SCORES TO HP, POSTIVE CARDS DAMAGE YOUR OPPONENT NEGATIVE CARDS HEAL YOU.
    public void OnFlip(CardFlipper cardFlipper, PlayerManager playerManager)
    {
        PlayerManager = playerManager;

        if (cardFlipper.timesFlipped <= 10)
        { 
            cardFlipBool = true;
        }
        else
        {
            cardFlipBool = false;
        }
        Debug.Log("OnFlip is being called");
        var childGameObject = cardFlipper.gameObject;
        // when expanding the code below find Card1, Card2, Card3 etc 
        if (childGameObject.name.StartsWith("Card1") && cardFlipper.currentSprite == cardFlipper.CardBack && cardFlipBool)
        {
            Card1inPlay++;
            if (PlayerManager.IsEnemyCard)
            { 
            Score += Card1Value;
            }
            CountText.text = "Current Score " + Score.ToString();
        }
        if (childGameObject.name.StartsWith("Card2") && cardFlipper.currentSprite == cardFlipper.CardBack && cardFlipBool)
        { 
            Card2inPlay++;
            if (PlayerManager.IsEnemyCard)
            {
                Score += Card2Value;
            }
            CountText.text = "Current Score " + Score.ToString();
        }
        if (childGameObject.name.StartsWith("Card3") && cardFlipper.currentSprite == cardFlipper.CardBack && cardFlipBool)
        {
            Card3inPlay++;
            if (PlayerManager.IsEnemyCard)
            {
                Score += Card3Value;
            }
            CountText.text = "Current Score " + Score.ToString();
        }
        if (childGameObject.name.StartsWith("Card4") && cardFlipper.currentSprite == cardFlipper.CardBack && cardFlipBool)
        {
            Card4inPlay++;
            if (PlayerManager.IsEnemyCard)
            {
                Score += Card4Value;
            }
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