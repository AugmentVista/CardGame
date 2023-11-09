using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class AI_Controller : MonoBehaviour
{
    public PlayerManager playerManager;
    public WinScreen winScreen;
    public TextMeshProUGUI AI_CountText;
    public TextMeshProUGUI rulesText;
    public AI_ScoreText AIscoreText;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject dropZone;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;


    public int targetScore = 20; // Set the AI's target score
    List<GameObject> AIcards = new List<GameObject>();
    List<GameObject> AIhand = new List<GameObject>();

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        winScreen = FindObjectOfType<WinScreen>();
        AIscoreText = FindObjectOfType<AI_ScoreText>();

        dropZone = GameObject.Find("DropZone");
        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        dropZone = GameObject.Find("DropZone");
        AI_CountText.enabled = false;
        AIscoreText.enabled = true;

        AIcards.Add(Card1);
        AIcards.Add(Card2); 
        AIcards.Add(Card3);
        AIcards.Add(Card4);


       
    }

      
    void InitializeAIHand()
    {
        for (var i = 0; i < 2; i++)  
        {
            //Debug.Log("AIcards card" + AIcards.Count);
            int randomIndex = Random.Range(0, AIcards.Count); 
            GameObject Enemycard = Instantiate(AIcards[randomIndex], new Vector2(0, 0), Quaternion.identity);
            playerManager.DealtCard(Enemycard, "EnemyDealt");
            AIhand.Add(Enemycard);
            //Debug.Log("Enemy has drawn a card");
        }
    }

    void PlayAITurn()
    {
        GameObject selectedCard = SelectCardToPlay();
        selectedCard = // Logic telling the AI to play the highest value card in its hand --
        else if it's health is greater than 0, it plays whichever is the negative most card --
        else it plays the highest value card against the players health.


        // Call the PlayCard method in PlayerManager to play the selected card
        playerManager.PlayCard(selectedCard);

        // End AI's turn
        // Introduce a delay before the player's turn 
        // ...


        // Optional logic to check if the AI wins or loses here. otherwise it plays until the --
        //player wins or loses
    }


    //GameObject highestValueCard = null;
    //int highestValue = 0;

    //foreach (var card in hand)
    //{
    //    int cardValue = EvaluateCardValue(card);

    //    if (cardValue > highestValue)
    //    {
    //        highestValue = cardValue;
    //        highestValueCard = card;
    //    }
    //}


    int CardValueCheck(int i)
    {
        switch (i)
        {
            case 0:
                return AIscoreText.Card1Value;
            case 1:
                return AIscoreText.Card2Value;
            case 2:
                return AIscoreText.Card3Value;
            case 3:
                return AIscoreText.Card4Value;
            default:
                return 0;
        }
    }


    GameObject SelectCardToPlay()
    {
        int highestValue = int.MinValue; // Initialize to the smallest possible integer value
        GameObject highestValueCard = null;
        int currentCardValue = 0;
        for (int i = 0; i < AIcards.Count; i++)
        {
            switch (i)
            {
                case 0:
                    currentCardValue = CardValueCheck(i);
                    break;
                case 1:
                    currentCardValue = CardValueCheck(i);
                    break;
                case 2:
                    currentCardValue = CardValueCheck(i);
                    break;
                case 3:
                    currentCardValue = CardValueCheck(i);
                    break;
                default:
                    Debug.Log("Oppsie");
                    break;
            }
            if (currentCardValue > highestValue)
            {
                highestValue = currentCardValue;
                highestValueCard = AIcards[i].gameObject; // Assuming AIcards is a list of GameObjects
            }
        }
       
        return highestValueCard;

    }

    //int EvaluateCardValue(GameObject card)
    //{
       
    //}
}