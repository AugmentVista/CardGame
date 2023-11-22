using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;
using Unity.Collections.LowLevel.Unsafe;

public class AI_Controller : MonoBehaviour
{
    public PlayerManager playerManager;
    public WinScreen winScreen;
    public TextMeshProUGUI AI_CountText;
    public ScoreText scoreText;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4; 
    public GameObject CardPlus1Plus5;
    public GameObject CardPlus3Plus2;
    public GameObject CardPlus4Plus1;
    public GameObject CardPlus5Minus2;
    public GameObject CardPlus7Minus2;
    public GameObject CardPlus9Minus5;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject dropZone;
    public Health_System Health;

    // Set the AI's target score
    List<GameObject> AIcards = new List<GameObject>();
    List<GameObject> AIhand = new List<GameObject>();
    List<GameObject> AICardsInPlay = new List<GameObject>();

    void Start()
    {
        InitializeReferences();


        dropZone = GameObject.Find("DropZone");
        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        Health = FindObjectOfType<Health_System>();

        //AIcards.Add(Card1);
        //AIcards.Add(Card2);
        //AIcards.Add(Card3);
        //AIcards.Add(Card4);
        AIcards.Add(CardPlus1Plus5);
        AIcards.Add(CardPlus3Plus2);
        AIcards.Add(CardPlus4Plus1);
        AIcards.Add(CardPlus5Minus2);
        AIcards.Add(CardPlus7Minus2);
        AIcards.Add(CardPlus9Minus5);
    }
    private void InitializeReferences()
    {
        scoreText = FindObjectOfType<ScoreText>();
        if (scoreText == null)
        {
            Debug.LogError("ScoreText not found in AI_Controller.");
            return;
        }
        if (scoreText == null)
        {
            Debug.LogError("ScoreText not found in AI_Controller.");
            return;
        }
        playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("PlayerManager not found in AI_Controller.");
            return;
        }

        winScreen = FindObjectOfType<WinScreen>();
        if (winScreen == null)
        {
            Debug.LogError("WinScreen not found in AI_Controller.");
            return;
        }
        dropZone = GameObject.Find("DropZone");
        if (dropZone == null)
        {
            Debug.LogError("DropZone not found in AI_Controller.");
            return;
        }

        PlayerArea = GameObject.Find("PlayerArea");
        if (PlayerArea == null)
        {
            Debug.LogError("PlayerArea not found in AI_Controller.");
            return;
        }

        EnemyArea = GameObject.Find("EnemyArea");
        if (EnemyArea == null)
        {
            Debug.LogError("EnemyArea not found in AI_Controller.");
        }
    }


    public void InitializeAIHand()
    {
        if (playerManager.cardsPlayed <= 10 && playerManager.cardsDrawn <= 10)
        {
            for (var i = 0; i < 1; i++) // i = # cards to draw
            {
                int randomIndex = Random.Range(0, AIcards.Count);
                GameObject Enemycard = Instantiate(AIcards[randomIndex], EnemyArea.transform);
                playerManager.DealtCard(Enemycard, "EnemyDealt");
                AIhand.Add(Enemycard);
            }
        }
    }

    public void PlayAITurn()
    {
        GameObject selectedCard = SelectCardToPlay();
        AICardsInPlay.Add(selectedCard);
        AIhand.Remove(selectedCard);

        // Ensure the selected card is an instance of a prefab

        if (selectedCard != null)
        {
            // Get the current parent (EnemyArea)
            Transform currentParent = selectedCard.transform.parent;

            // Change the parent to DropZone
            selectedCard.transform.SetParent(dropZone.transform, false);

            scoreText.UpdateScore(selectedCard, selectedCard.GetComponent<CardFlipper>());
            selectedCard.GetComponent<CardFlipper>().UpdateHealthSystem();
            winScreen.Win();
        }
    }

    //int CardValueCheck(int i) 
    //{
    //    switch (i)
    //    {
    //        case 0:
    //            return scoreText.Card1Value;
    //        case 1:
    //            return scoreText.Card2Value;
    //        case 2:
    //            return scoreText.Card3Value;
    //        case 3:
    //            return scoreText.Card4Value;
    //        default:
    //            return 0;
    //    }
    //}

    GameObject SelectCardToPlay()
    {
        int highestValue = int.MinValue;
        GameObject highestValueCard = null;
            if (Health.currentEnemyHealth <= 0)
            {
                for (int i = 0; i < AIhand.Count; i++)
                {
                    int currentCardValue = AIhand[i].GetComponent<CardFlipper>().cardHealthModifier;

                    if (currentCardValue > highestValue && winScreen.AIrandomWinScore - scoreText.AIscore > currentCardValue)
                    {
                        highestValue = currentCardValue;
                        highestValueCard = AIhand[i];
                    }
                }
                return highestValueCard;
            }
        else
        { 
            for (int i = 0; i < AIhand.Count; i++)
            {
                int currentCardValue = AIhand[i].GetComponent<CardFlipper>().valueOfCard;

                if (currentCardValue > highestValue && winScreen.AIrandomWinScore - scoreText.AIscore > currentCardValue)
                {
                    highestValue = currentCardValue;
                    highestValueCard = AIhand[i];
                }
            }
            return highestValueCard;
        }
    }
}