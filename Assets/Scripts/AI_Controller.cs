using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;
using UnityEngine.XR;
using System;
using Unity.VisualScripting;

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
        if (AIhand.Count < 7)
        {
            for (var i = 0; i < 1; i++) // i = # cards to draw
            {
                int randomIndex = UnityEngine.Random.Range(0, AIcards.Count);
                GameObject Enemycard = Instantiate(AIcards[randomIndex], EnemyArea.transform);
                playerManager.DealtCard(Enemycard, "EnemyDealt");
                AIhand.Add(Enemycard);
            }
        }
    }

    Tuple<GameObject, int, int, int> CombThroughAIHand()
    {
        int highestValue = int.MinValue;
        GameObject highestValueCard = null;
        int highestCardScore = 0;
        int highestCardHealth = 0;
        int CardScore = 0;
        int CardHealth = 0;

        for (int i = 0; i < AIhand.Count; i++)
        {
            CardScore = AIhand[i].GetComponent<CardFlipper>().valueOfCard;
            CardHealth = AIhand[i].GetComponent<CardFlipper>().cardHealthModifier;
            int CardValue = CardHealth + CardScore;

            if (CardValue > highestValue)
            {
                highestValue = CardValue;
                highestValueCard = AIhand[i];
                highestCardScore = CardScore;
                highestCardHealth = CardHealth;


                CardFlipper ScoreComponent = highestValueCard.GetComponent<CardFlipper>();
                if (ScoreComponent != null)
                {
                    int score = ScoreComponent.valueOfCard;
                }
                CardFlipper HealthComponent = highestValueCard.GetComponent<CardFlipper>();
                if (HealthComponent != null)
                {
                    int health = HealthComponent.cardHealthModifier;
                }
            }
        }
        return Tuple.Create(highestValueCard, highestValue, highestCardScore, highestCardHealth);
    }


    public void PlayAITurn()
    {
        Tuple<GameObject, int, int, int> cardSelectionResult = CombThroughAIHand();

        GameObject selectedCard = null;
        int targetScore = winScreen.AIrandomWinScore;  

        GameObject highestValueCard = cardSelectionResult.Item1;
        int highestValue = cardSelectionResult.Item2;
        int highestCardScore = cardSelectionResult.Item3;
        int highestCardHealth = cardSelectionResult.Item4;

        if (winScreen.AIrandomWinScore - scoreText.AIscore >= highestValueCard.GetComponent<CardFlipper>().valueOfCard && Health.currentEnemyHealth + highestValueCard.GetComponent<CardFlipper>().cardHealthModifier < 1)
        {
            selectedCard = highestValueCard;
        }
        else if (Health.currentEnemyHealth + highestCardHealth < 1)
        {
            int subHighestValue = int.MinValue;
            int subHighestCardHealth = 0;
            GameObject subHighestValueCard = null;
            int CardHealth = 0;

            for (int i = 0; i < AIhand.Count; i++)
            {
                CardHealth = AIhand[i].GetComponent<CardFlipper>().cardHealthModifier;

                if (CardHealth > subHighestValue)
                {
                    subHighestCardHealth = CardHealth;
                    subHighestValueCard = AIhand[i];
                }
            }
            selectedCard = subHighestValueCard;
        }
        else if (scoreText.AIscore + highestCardScore <= targetScore)
        {
            int subHighestValue = int.MinValue;
            int subHighestCardScore = 0;  
            GameObject subHighestValueCard = null;
            int CardScore = 0;

            for (int i = 0; i < AIhand.Count; i++)
            {
                CardScore = AIhand[i].GetComponent<CardFlipper>().valueOfCard;

                if (CardScore > subHighestValue)
                {
                    subHighestCardScore = CardScore;  
                    subHighestValueCard = AIhand[i];
                }
            }
            selectedCard = subHighestValueCard;
        }
        AICardsInPlay.Add(selectedCard);

        if (selectedCard != null)
        {
            AIhand.Remove(selectedCard);

            Transform currentParent = selectedCard.transform.parent;
            selectedCard.transform.SetParent(dropZone.transform, false);

            scoreText.UpdateScore(selectedCard, selectedCard.GetComponent<CardFlipper>());
            selectedCard.GetComponent<CardFlipper>().UpdateHealthSystem();

            winScreen.Win();
            playerManager.CardsOnBoard.Add(selectedCard);

            if (playerManager.CardsOnBoard.Count > 10)
            {
                Destroy(playerManager.CardsOnBoard[0]);
                playerManager.CardsOnBoard.RemoveAt(0);
            }
        }
    }

}